SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spvrFreightBudgetProjectSelectByID]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spvrFreightBudgetProjectSelectByID]
GO
 
CREATE PROCEDURE [dbo].[spvrFreightBudgetProjectSelectByID]
  @LoginID NVarChar(8),
  @ProjectID NVarChar(6) 
  AS
  SELECT
    [VR_FreightBudgetProject].* ,
    [aspnet_Users1].[UserFullName] AS aspnet_Users1_UserFullName,
    [IDM_Projects2].[Description] AS IDM_Projects2_Description,
    [IDM_Projects3].[Description] AS IDM_Projects3_Description 
  FROM [VR_FreightBudgetProject] 
  INNER JOIN [aspnet_users] AS [aspnet_users1]
    ON [VR_FreightBudgetProject].[CreatedBy] = [aspnet_users1].[LoginID]
  INNER JOIN [IDM_Projects] AS [IDM_Projects2]
    ON [VR_FreightBudgetProject].[ProjectID] = [IDM_Projects2].[ProjectID]
  INNER JOIN [IDM_Projects] AS [IDM_Projects3]
    ON [VR_FreightBudgetProject].[FreightBudgetProjectID] = [IDM_Projects3].[ProjectID]
  WHERE
  [VR_FreightBudgetProject].[ProjectID] = @ProjectID
  GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spvrFreightBudgetProjectSelectListSearch]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spvrFreightBudgetProjectSelectListSearch]
GO
 
CREATE PROCEDURE [dbo].[spvrFreightBudgetProjectSelectListSearch]
  @LoginID NVarChar(8),
  @StartRowIndex int,
  @MaximumRows int,
  @KeyWord VarChar(250),
  @OrderBy NVarChar(50),
  @RecordCount Int = 0 OUTPUT
  AS
  BEGIN
    DECLARE @KeyWord1 VarChar(260)
    SET @KeyWord1 = '%' + LOWER(@KeyWord) + '%'
  CREATE TABLE #PageIndex (
  IndexID INT IDENTITY (1, 1) NOT NULL
 ,ProjectID NVarChar(6) NOT NULL
  )
  INSERT INTO #PageIndex (ProjectID)
  SELECT [VR_FreightBudgetProject].[ProjectID] FROM [VR_FreightBudgetProject]
  INNER JOIN [aspnet_users] AS [aspnet_users1]
    ON [VR_FreightBudgetProject].[CreatedBy] = [aspnet_users1].[LoginID]
  INNER JOIN [IDM_Projects] AS [IDM_Projects2]
    ON [VR_FreightBudgetProject].[ProjectID] = [IDM_Projects2].[ProjectID]
  INNER JOIN [IDM_Projects] AS [IDM_Projects3]
    ON [VR_FreightBudgetProject].[FreightBudgetProjectID] = [IDM_Projects3].[ProjectID]
 WHERE  
   ( 
         LOWER(ISNULL([VR_FreightBudgetProject].[ProjectID],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([VR_FreightBudgetProject].[CreatedBy],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([VR_FreightBudgetProject].[FreightBudgetProjectID],'')) LIKE @KeyWord1
   ) 
  ORDER BY (Select @OrderBy)

    SET @RecordCount = @@RowCount

  SELECT
    [VR_FreightBudgetProject].* ,
    [aspnet_Users1].[UserFullName] AS aspnet_Users1_UserFullName,
    [IDM_Projects2].[Description] AS IDM_Projects2_Description,
    [IDM_Projects3].[Description] AS IDM_Projects3_Description 
  FROM [VR_FreightBudgetProject] 
      INNER JOIN #PageIndex
          ON [VR_FreightBudgetProject].[ProjectID] = #PageIndex.ProjectID
  INNER JOIN [aspnet_users] AS [aspnet_users1]
    ON [VR_FreightBudgetProject].[CreatedBy] = [aspnet_users1].[LoginID]
  INNER JOIN [IDM_Projects] AS [IDM_Projects2]
    ON [VR_FreightBudgetProject].[ProjectID] = [IDM_Projects2].[ProjectID]
  INNER JOIN [IDM_Projects] AS [IDM_Projects3]
    ON [VR_FreightBudgetProject].[FreightBudgetProjectID] = [IDM_Projects3].[ProjectID]
  WHERE
        #PageIndex.IndexID > @StartRowIndex
        AND #PageIndex.IndexID < (@StartRowIndex + @MaximumRows + 1)
  ORDER BY
    #PageIndex.IndexID
  END
  GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spvrFreightBudgetProjectSelectListFilteres]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spvrFreightBudgetProjectSelectListFilteres]
GO
 
CREATE PROCEDURE [dbo].[spvrFreightBudgetProjectSelectListFilteres]
  @Filter_ProjectID NVarChar(6),
  @Filter_CreatedBy NVarChar(8),
  @Filter_FreightBudgetProjectID NVarChar(6),
  @LoginID NVarChar(8),
  @StartRowIndex int,
  @MaximumRows int,
  @OrderBy NVarChar(50),
  @RecordCount Int = 0 OUTPUT
  AS
  BEGIN
  DECLARE @LGSQL VarChar(8000)
  IF (@OrderBy = '')
    SET @OrderBy = 'ProjectID'
  CREATE TABLE #PageIndex (
  IndexID INT IDENTITY (1, 1) NOT NULL
 ,ProjectID NVarChar(6) NOT NULL
  )
  SET @LGSQL = 'INSERT INTO #PageIndex (' 
  SET @LGSQL +=  'ProjectID'
  SET @LGSQL +=  ')'
  SET @LGSQL +=  ' SELECT '
  SET @LGSQL +=  '[VR_FreightBudgetProject].[ProjectID]'
  SET @LGSQL +=  ' FROM [VR_FreightBudgetProject] '
  SET @LGSQL +=  '  INNER JOIN [aspnet_users] AS [aspnet_users1]'
  SET @LGSQL +=  '    ON [VR_FreightBudgetProject].[CreatedBy] = [aspnet_users1].[LoginID]'
  SET @LGSQL +=  '  INNER JOIN [IDM_Projects] AS [IDM_Projects2]'
  SET @LGSQL +=  '    ON [VR_FreightBudgetProject].[ProjectID] = [IDM_Projects2].[ProjectID]'
  SET @LGSQL +=  '  INNER JOIN [IDM_Projects] AS [IDM_Projects3]'
  SET @LGSQL +=  '    ON [VR_FreightBudgetProject].[FreightBudgetProjectID] = [IDM_Projects3].[ProjectID]'
  SET @LGSQL +=  '  WHERE 1 = 1 '
  IF (@Filter_ProjectID > '') 
    SET @LGSQL +=  ' AND [VR_FreightBudgetProject].[ProjectID] = ''' + @Filter_ProjectID + ''''
  IF (@Filter_CreatedBy > '') 
    SET @LGSQL +=  ' AND [VR_FreightBudgetProject].[CreatedBy] = ''' + @Filter_CreatedBy + ''''
  IF (@Filter_FreightBudgetProjectID > '') 
    SET @LGSQL +=  ' AND [VR_FreightBudgetProject].[FreightBudgetProjectID] = ''' + @Filter_FreightBudgetProjectID + ''''
  SET @LGSQL +=  '  ORDER BY ' + @OrderBy
 
 
  EXEC (@LGSQL)

  SET @RecordCount = @@RowCount

  SELECT
    [VR_FreightBudgetProject].* ,
    [aspnet_Users1].[UserFullName] AS aspnet_Users1_UserFullName,
    [IDM_Projects2].[Description] AS IDM_Projects2_Description,
    [IDM_Projects3].[Description] AS IDM_Projects3_Description 
  FROM [VR_FreightBudgetProject] 
      INNER JOIN #PageIndex
          ON [VR_FreightBudgetProject].[ProjectID] = #PageIndex.ProjectID
  INNER JOIN [aspnet_users] AS [aspnet_users1]
    ON [VR_FreightBudgetProject].[CreatedBy] = [aspnet_users1].[LoginID]
  INNER JOIN [IDM_Projects] AS [IDM_Projects2]
    ON [VR_FreightBudgetProject].[ProjectID] = [IDM_Projects2].[ProjectID]
  INNER JOIN [IDM_Projects] AS [IDM_Projects3]
    ON [VR_FreightBudgetProject].[FreightBudgetProjectID] = [IDM_Projects3].[ProjectID]
  WHERE
        #PageIndex.IndexID > @StartRowIndex
        AND #PageIndex.IndexID < (@StartRowIndex + @MaximumRows + 1)
  ORDER BY
    #PageIndex.IndexID
  END
  GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spvrFreightBudgetProjectInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spvrFreightBudgetProjectInsert]
GO
 
CREATE PROCEDURE [dbo].[spvrFreightBudgetProjectInsert]
  @ProjectID NVarChar(6),
  @CreatedBy NVarChar(8),
  @CreatedOn DateTime,
  @Active Bit,
  @FreightBudgetProjectID NVarChar(6),
  @Return_ProjectID NVarChar(6) = null OUTPUT 
  AS
  INSERT [VR_FreightBudgetProject]
  (
   [ProjectID]
  ,[CreatedBy]
  ,[CreatedOn]
  ,[Active]
  ,[FreightBudgetProjectID]
  )
  VALUES
  (
   UPPER(@ProjectID)
  ,@CreatedBy
  ,@CreatedOn
  ,@Active
  ,@FreightBudgetProjectID
  )
  SET @Return_ProjectID = @ProjectID
  GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spvrFreightBudgetProjectUpdate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spvrFreightBudgetProjectUpdate]
GO
 
CREATE PROCEDURE [dbo].[spvrFreightBudgetProjectUpdate]
  @Original_ProjectID NVarChar(6), 
  @ProjectID NVarChar(6),
  @CreatedBy NVarChar(8),
  @CreatedOn DateTime,
  @Active Bit,
  @FreightBudgetProjectID NVarChar(6),
  @RowCount int = null OUTPUT
  AS
  UPDATE [VR_FreightBudgetProject] SET 
   [ProjectID] = @ProjectID
  ,[CreatedBy] = @CreatedBy
  ,[CreatedOn] = @CreatedOn
  ,[Active] = @Active
  ,[FreightBudgetProjectID] = @FreightBudgetProjectID
  WHERE
  [ProjectID] = @Original_ProjectID
  SET @RowCount = @@RowCount
  GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spvrFreightBudgetProjectDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spvrFreightBudgetProjectDelete]
GO
 
CREATE PROCEDURE [dbo].[spvrFreightBudgetProjectDelete]
  @Original_ProjectID NVarChar(6),
  @RowCount int = null OUTPUT
  AS
  DELETE [VR_FreightBudgetProject]
  WHERE
  [VR_FreightBudgetProject].[ProjectID] = @Original_ProjectID
  SET @RowCount = @@RowCount
  GO

SET QUOTED_IDENTIFIER OFF
GO
SET ANSI_NULLS ON
GO
