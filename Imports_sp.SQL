SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sptpisg229SelectByID]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sptpisg229SelectByID]
GO
 
CREATE PROCEDURE [dbo].[sptpisg229SelectByID]
  @LoginID NVarChar(8),
  @t_trdt DateTime,
  @t_bohd VarChar(50),
  @t_indv VarChar(50),
  @t_srno Int 
  AS
  SELECT
    [ttpisg229200].*  
  FROM [ttpisg229200] 
  WHERE
  [ttpisg229200].[t_trdt] = @t_trdt
  AND [ttpisg229200].[t_bohd] = @t_bohd
  AND [ttpisg229200].[t_indv] = @t_indv
  AND [ttpisg229200].[t_srno] = @t_srno
  GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sptpisg229SelectListSearch]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sptpisg229SelectListSearch]
GO
 
CREATE PROCEDURE [dbo].[sptpisg229SelectListSearch]
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
 ,t_trdt DateTime NOT NULL
 ,t_bohd VarChar(50) NOT NULL
 ,t_indv VarChar(50) NOT NULL
 ,t_srno Int NOT NULL
  )
  INSERT INTO #PageIndex (t_trdt, t_bohd, t_indv, t_srno)
  SELECT [ttpisg229200].[t_trdt], [ttpisg229200].[t_bohd], [ttpisg229200].[t_indv], [ttpisg229200].[t_srno] FROM [ttpisg229200]
 WHERE  
   ( 
         LOWER(ISNULL([ttpisg229200].[t_bohd],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ttpisg229200].[t_indv],'')) LIKE @KeyWord1
     OR STR(ISNULL([ttpisg229200].[t_srno], 0)) LIKE @KeyWord1
     OR LOWER(ISNULL([ttpisg229200].[t_stat],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ttpisg229200].[t_proj],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ttpisg229200].[t_elem],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ttpisg229200].[t_user],'')) LIKE @KeyWord1
     OR STR(ISNULL([ttpisg229200].[t_Refcntd], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttpisg229200].[t_Refcntu], 0)) LIKE @KeyWord1
   ) 
  ORDER BY
     CASE @OrderBy WHEN 't_trdt' THEN [ttpisg229200].[t_trdt] END,
     CASE @OrderBy WHEN 't_trdt DESC' THEN [ttpisg229200].[t_trdt] END DESC,
     CASE @OrderBy WHEN 't_bohd' THEN [ttpisg229200].[t_bohd] END,
     CASE @OrderBy WHEN 't_bohd DESC' THEN [ttpisg229200].[t_bohd] END DESC,
     CASE @OrderBy WHEN 't_indv' THEN [ttpisg229200].[t_indv] END,
     CASE @OrderBy WHEN 't_indv DESC' THEN [ttpisg229200].[t_indv] END DESC,
     CASE @OrderBy WHEN 't_srno' THEN [ttpisg229200].[t_srno] END,
     CASE @OrderBy WHEN 't_srno DESC' THEN [ttpisg229200].[t_srno] END DESC,
     CASE @OrderBy WHEN 't_stat' THEN [ttpisg229200].[t_stat] END,
     CASE @OrderBy WHEN 't_stat DESC' THEN [ttpisg229200].[t_stat] END DESC,
     CASE @OrderBy WHEN 't_proj' THEN [ttpisg229200].[t_proj] END,
     CASE @OrderBy WHEN 't_proj DESC' THEN [ttpisg229200].[t_proj] END DESC,
     CASE @OrderBy WHEN 't_elem' THEN [ttpisg229200].[t_elem] END,
     CASE @OrderBy WHEN 't_elem DESC' THEN [ttpisg229200].[t_elem] END DESC,
     CASE @OrderBy WHEN 't_user' THEN [ttpisg229200].[t_user] END,
     CASE @OrderBy WHEN 't_user DESC' THEN [ttpisg229200].[t_user] END DESC,
     CASE @OrderBy WHEN 't_Refcntd' THEN [ttpisg229200].[t_Refcntd] END,
     CASE @OrderBy WHEN 't_Refcntd DESC' THEN [ttpisg229200].[t_Refcntd] END DESC,
     CASE @OrderBy WHEN 't_Refcntu' THEN [ttpisg229200].[t_Refcntu] END,
     CASE @OrderBy WHEN 't_Refcntu DESC' THEN [ttpisg229200].[t_Refcntu] END DESC 

    SET @RecordCount = @@RowCount

  SELECT
    [ttpisg229200].*  
  FROM [ttpisg229200] 
      INNER JOIN #PageIndex
          ON [ttpisg229200].[t_trdt] = #PageIndex.t_trdt
          AND [ttpisg229200].[t_bohd] = #PageIndex.t_bohd
          AND [ttpisg229200].[t_indv] = #PageIndex.t_indv
          AND [ttpisg229200].[t_srno] = #PageIndex.t_srno
  WHERE
        #PageIndex.IndexID > @StartRowIndex
        AND #PageIndex.IndexID < (@StartRowIndex + @MaximumRows + 1)
  ORDER BY
    #PageIndex.IndexID
  END
  GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sptpisg229SelectListFilteres]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sptpisg229SelectListFilteres]
GO
 
CREATE PROCEDURE [dbo].[sptpisg229SelectListFilteres]
  @LoginID NVarChar(8),
  @StartRowIndex int,
  @MaximumRows int,
  @OrderBy NVarChar(50),
  @RecordCount Int = 0 OUTPUT
  AS
  BEGIN
  DECLARE @LGSQL VarChar(8000)
  CREATE TABLE #PageIndex (
  IndexID INT IDENTITY (1, 1) NOT NULL
 ,t_trdt DateTime NOT NULL
 ,t_bohd VarChar(50) NOT NULL
 ,t_indv VarChar(50) NOT NULL
 ,t_srno Int NOT NULL
  )
  SET @LGSQL = 'INSERT INTO #PageIndex (' 
  SET @LGSQL = @LGSQL + 't_trdt'
  SET @LGSQL = @LGSQL + ', t_bohd'
  SET @LGSQL = @LGSQL + ', t_indv'
  SET @LGSQL = @LGSQL + ', t_srno'
  SET @LGSQL = @LGSQL + ')'
  SET @LGSQL = @LGSQL + ' SELECT '
  SET @LGSQL = @LGSQL + '[ttpisg229200].[t_trdt]'
  SET @LGSQL = @LGSQL + ', [ttpisg229200].[t_bohd]'
  SET @LGSQL = @LGSQL + ', [ttpisg229200].[t_indv]'
  SET @LGSQL = @LGSQL + ', [ttpisg229200].[t_srno]'
  SET @LGSQL = @LGSQL + ' FROM [ttpisg229200] '
  SET @LGSQL = @LGSQL + '  WHERE 1 = 1 '
  SET @LGSQL = @LGSQL + '  ORDER BY '
  SET @LGSQL = @LGSQL + CASE @OrderBy
                        WHEN 't_trdt' THEN '[ttpisg229200].[t_trdt]'
                        WHEN 't_trdt DESC' THEN '[ttpisg229200].[t_trdt] DESC'
                        WHEN 't_bohd' THEN '[ttpisg229200].[t_bohd]'
                        WHEN 't_bohd DESC' THEN '[ttpisg229200].[t_bohd] DESC'
                        WHEN 't_indv' THEN '[ttpisg229200].[t_indv]'
                        WHEN 't_indv DESC' THEN '[ttpisg229200].[t_indv] DESC'
                        WHEN 't_srno' THEN '[ttpisg229200].[t_srno]'
                        WHEN 't_srno DESC' THEN '[ttpisg229200].[t_srno] DESC'
                        WHEN 't_stat' THEN '[ttpisg229200].[t_stat]'
                        WHEN 't_stat DESC' THEN '[ttpisg229200].[t_stat] DESC'
                        WHEN 't_proj' THEN '[ttpisg229200].[t_proj]'
                        WHEN 't_proj DESC' THEN '[ttpisg229200].[t_proj] DESC'
                        WHEN 't_elem' THEN '[ttpisg229200].[t_elem]'
                        WHEN 't_elem DESC' THEN '[ttpisg229200].[t_elem] DESC'
                        WHEN 't_user' THEN '[ttpisg229200].[t_user]'
                        WHEN 't_user DESC' THEN '[ttpisg229200].[t_user] DESC'
                        WHEN 't_Refcntd' THEN '[ttpisg229200].[t_Refcntd]'
                        WHEN 't_Refcntd DESC' THEN '[ttpisg229200].[t_Refcntd] DESC'
                        WHEN 't_Refcntu' THEN '[ttpisg229200].[t_Refcntu]'
                        WHEN 't_Refcntu DESC' THEN '[ttpisg229200].[t_Refcntu] DESC'
                        ELSE '[ttpisg229200].[t_trdt],[ttpisg229200].[t_bohd],[ttpisg229200].[t_indv],[ttpisg229200].[t_srno]'
                    END
  EXEC (@LGSQL)

  SET @RecordCount = @@RowCount

  SELECT
    [ttpisg229200].*  
  FROM [ttpisg229200] 
      INNER JOIN #PageIndex
          ON [ttpisg229200].[t_trdt] = #PageIndex.t_trdt
          AND [ttpisg229200].[t_bohd] = #PageIndex.t_bohd
          AND [ttpisg229200].[t_indv] = #PageIndex.t_indv
          AND [ttpisg229200].[t_srno] = #PageIndex.t_srno
  WHERE
        #PageIndex.IndexID > @StartRowIndex
        AND #PageIndex.IndexID < (@StartRowIndex + @MaximumRows + 1)
  ORDER BY
    #PageIndex.IndexID
  END
  GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sptpisg229Insert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sptpisg229Insert]
GO
 
CREATE PROCEDURE [dbo].[sptpisg229Insert]
  @t_trdt DateTime,
  @t_bohd VarChar(50),
  @t_indv VarChar(50),
  @t_srno Int,
  @t_stat VarChar(20),
  @t_proj VarChar(9),
  @t_elem VarChar(8),
  @t_user VarChar(9),
  @t_Refcntd Int,
  @t_Refcntu Int,
  @Return_t_trdt DateTime = null OUTPUT, 
  @Return_t_bohd VarChar(50) = null OUTPUT, 
  @Return_t_indv VarChar(50) = null OUTPUT, 
  @Return_t_srno Int = null OUTPUT 
  AS
  INSERT [ttpisg229200]
  (
   [t_trdt]
  ,[t_bohd]
  ,[t_indv]
  ,[t_srno]
  ,[t_stat]
  ,[t_proj]
  ,[t_elem]
  ,[t_user]
  ,[t_Refcntd]
  ,[t_Refcntu]
  )
  VALUES
  (
   @t_trdt
  ,UPPER(@t_bohd)
  ,UPPER(@t_indv)
  ,@t_srno
  ,@t_stat
  ,@t_proj
  ,@t_elem
  ,@t_user
  ,@t_Refcntd
  ,@t_Refcntu
  )
  SET @Return_t_trdt = @t_trdt
  SET @Return_t_bohd = @t_bohd
  SET @Return_t_indv = @t_indv
  SET @Return_t_srno = @t_srno
  GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sptpisg229Update]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sptpisg229Update]
GO
 
CREATE PROCEDURE [dbo].[sptpisg229Update]
  @Original_t_trdt DateTime, 
  @Original_t_bohd VarChar(50), 
  @Original_t_indv VarChar(50), 
  @Original_t_srno Int, 
  @t_trdt DateTime,
  @t_bohd VarChar(50),
  @t_indv VarChar(50),
  @t_srno Int,
  @t_stat VarChar(20),
  @t_proj VarChar(9),
  @t_elem VarChar(8),
  @t_user VarChar(9),
  @t_Refcntd Int,
  @t_Refcntu Int,
  @RowCount int = null OUTPUT
  AS
  UPDATE [ttpisg229200] SET 
   [t_trdt] = @t_trdt
  ,[t_bohd] = @t_bohd
  ,[t_indv] = @t_indv
  ,[t_srno] = @t_srno
  ,[t_stat] = @t_stat
  ,[t_proj] = @t_proj
  ,[t_elem] = @t_elem
  ,[t_user] = @t_user
  ,[t_Refcntd] = @t_Refcntd
  ,[t_Refcntu] = @t_Refcntu
  WHERE
  [t_trdt] = @Original_t_trdt
  AND [t_bohd] = @Original_t_bohd
  AND [t_indv] = @Original_t_indv
  AND [t_srno] = @Original_t_srno
  SET @RowCount = @@RowCount
  GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sptpisg229Delete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sptpisg229Delete]
GO
 
CREATE PROCEDURE [dbo].[sptpisg229Delete]
  @Original_t_trdt DateTime,
  @Original_t_bohd VarChar(50),
  @Original_t_indv VarChar(50),
  @Original_t_srno Int,
  @RowCount int = null OUTPUT
  AS
  DELETE [ttpisg229200]
  WHERE
  [ttpisg229200].[t_trdt] = @Original_t_trdt
  AND [ttpisg229200].[t_bohd] = @Original_t_bohd
  AND [ttpisg229200].[t_indv] = @Original_t_indv
  AND [ttpisg229200].[t_srno] = @Original_t_srno
  SET @RowCount = @@RowCount
  GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sptpisg230SelectByID]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sptpisg230SelectByID]
GO
 
CREATE PROCEDURE [dbo].[sptpisg230SelectByID]
  @LoginID NVarChar(8),
  @t_trdt DateTime,
  @t_bohd VarChar(50),
  @t_indv VarChar(100),
  @t_srno Int,
  @t_dsno Int 
  AS
  SELECT
    [ttpisg230200].*  
  FROM [ttpisg230200] 
  WHERE
  [ttpisg230200].[t_trdt] = @t_trdt
  AND [ttpisg230200].[t_bohd] = @t_bohd
  AND [ttpisg230200].[t_indv] = @t_indv
  AND [ttpisg230200].[t_srno] = @t_srno
  AND [ttpisg230200].[t_dsno] = @t_dsno
  GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sptpisg230SelectListSearch]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sptpisg230SelectListSearch]
GO
 
CREATE PROCEDURE [dbo].[sptpisg230SelectListSearch]
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
 ,t_trdt DateTime NOT NULL
 ,t_bohd VarChar(50) NOT NULL
 ,t_indv VarChar(100) NOT NULL
 ,t_srno Int NOT NULL
 ,t_dsno Int NOT NULL
  )
  INSERT INTO #PageIndex (t_trdt, t_bohd, t_indv, t_srno, t_dsno)
  SELECT [ttpisg230200].[t_trdt], [ttpisg230200].[t_bohd], [ttpisg230200].[t_indv], [ttpisg230200].[t_srno], [ttpisg230200].[t_dsno] FROM [ttpisg230200]
 WHERE  
   ( 
         LOWER(ISNULL([ttpisg230200].[t_bohd],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ttpisg230200].[t_indv],'')) LIKE @KeyWord1
     OR STR(ISNULL([ttpisg230200].[t_srno], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttpisg230200].[t_dsno], 0)) LIKE @KeyWord1
     OR LOWER(ISNULL([ttpisg230200].[t_stat],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ttpisg230200].[t_proj],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ttpisg230200].[t_elem],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ttpisg230200].[t_dwno],'')) LIKE @KeyWord1
     OR STR(ISNULL([ttpisg230200].[t_pitc], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttpisg230200].[t_wght], 0)) LIKE @KeyWord1
     OR LOWER(ISNULL([ttpisg230200].[t_atcd],'')) LIKE @KeyWord1
     OR STR(ISNULL([ttpisg230200].[t_scup], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttpisg230200].[t_Refcntd], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttpisg230200].[t_Refcntu], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttpisg230200].[t_numo], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttpisg230200].[t_numq], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttpisg230200].[t_numt], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttpisg230200].[t_numv], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttpisg230200].[t_nutc], 0)) LIKE @KeyWord1
   ) 
  ORDER BY
     CASE @OrderBy WHEN 't_trdt' THEN [ttpisg230200].[t_trdt] END,
     CASE @OrderBy WHEN 't_trdt DESC' THEN [ttpisg230200].[t_trdt] END DESC,
     CASE @OrderBy WHEN 't_bohd' THEN [ttpisg230200].[t_bohd] END,
     CASE @OrderBy WHEN 't_bohd DESC' THEN [ttpisg230200].[t_bohd] END DESC,
     CASE @OrderBy WHEN 't_indv' THEN [ttpisg230200].[t_indv] END,
     CASE @OrderBy WHEN 't_indv DESC' THEN [ttpisg230200].[t_indv] END DESC,
     CASE @OrderBy WHEN 't_srno' THEN [ttpisg230200].[t_srno] END,
     CASE @OrderBy WHEN 't_srno DESC' THEN [ttpisg230200].[t_srno] END DESC,
     CASE @OrderBy WHEN 't_dsno' THEN [ttpisg230200].[t_dsno] END,
     CASE @OrderBy WHEN 't_dsno DESC' THEN [ttpisg230200].[t_dsno] END DESC,
     CASE @OrderBy WHEN 't_stat' THEN [ttpisg230200].[t_stat] END,
     CASE @OrderBy WHEN 't_stat DESC' THEN [ttpisg230200].[t_stat] END DESC,
     CASE @OrderBy WHEN 't_proj' THEN [ttpisg230200].[t_proj] END,
     CASE @OrderBy WHEN 't_proj DESC' THEN [ttpisg230200].[t_proj] END DESC,
     CASE @OrderBy WHEN 't_elem' THEN [ttpisg230200].[t_elem] END,
     CASE @OrderBy WHEN 't_elem DESC' THEN [ttpisg230200].[t_elem] END DESC,
     CASE @OrderBy WHEN 't_dwno' THEN [ttpisg230200].[t_dwno] END,
     CASE @OrderBy WHEN 't_dwno DESC' THEN [ttpisg230200].[t_dwno] END DESC,
     CASE @OrderBy WHEN 't_pitc' THEN [ttpisg230200].[t_pitc] END,
     CASE @OrderBy WHEN 't_pitc DESC' THEN [ttpisg230200].[t_pitc] END DESC,
     CASE @OrderBy WHEN 't_wght' THEN [ttpisg230200].[t_wght] END,
     CASE @OrderBy WHEN 't_wght DESC' THEN [ttpisg230200].[t_wght] END DESC,
     CASE @OrderBy WHEN 't_atcd' THEN [ttpisg230200].[t_atcd] END,
     CASE @OrderBy WHEN 't_atcd DESC' THEN [ttpisg230200].[t_atcd] END DESC,
     CASE @OrderBy WHEN 't_scup' THEN [ttpisg230200].[t_scup] END,
     CASE @OrderBy WHEN 't_scup DESC' THEN [ttpisg230200].[t_scup] END DESC,
     CASE @OrderBy WHEN 't_acdt' THEN [ttpisg230200].[t_acdt] END,
     CASE @OrderBy WHEN 't_acdt DESC' THEN [ttpisg230200].[t_acdt] END DESC,
     CASE @OrderBy WHEN 't_acfh' THEN [ttpisg230200].[t_acfh] END,
     CASE @OrderBy WHEN 't_acfh DESC' THEN [ttpisg230200].[t_acfh] END DESC,
     CASE @OrderBy WHEN 't_pper' THEN [ttpisg230200].[t_pper] END,
     CASE @OrderBy WHEN 't_pper DESC' THEN [ttpisg230200].[t_pper] END DESC,
     CASE @OrderBy WHEN 't_lupd' THEN [ttpisg230200].[t_lupd] END,
     CASE @OrderBy WHEN 't_lupd DESC' THEN [ttpisg230200].[t_lupd] END DESC,
     CASE @OrderBy WHEN 't_Refcntd' THEN [ttpisg230200].[t_Refcntd] END,
     CASE @OrderBy WHEN 't_Refcntd DESC' THEN [ttpisg230200].[t_Refcntd] END DESC,
     CASE @OrderBy WHEN 't_Refcntu' THEN [ttpisg230200].[t_Refcntu] END,
     CASE @OrderBy WHEN 't_Refcntu DESC' THEN [ttpisg230200].[t_Refcntu] END DESC,
     CASE @OrderBy WHEN 't_numo' THEN [ttpisg230200].[t_numo] END,
     CASE @OrderBy WHEN 't_numo DESC' THEN [ttpisg230200].[t_numo] END DESC,
     CASE @OrderBy WHEN 't_numq' THEN [ttpisg230200].[t_numq] END,
     CASE @OrderBy WHEN 't_numq DESC' THEN [ttpisg230200].[t_numq] END DESC,
     CASE @OrderBy WHEN 't_numt' THEN [ttpisg230200].[t_numt] END,
     CASE @OrderBy WHEN 't_numt DESC' THEN [ttpisg230200].[t_numt] END DESC,
     CASE @OrderBy WHEN 't_numv' THEN [ttpisg230200].[t_numv] END,
     CASE @OrderBy WHEN 't_numv DESC' THEN [ttpisg230200].[t_numv] END DESC,
     CASE @OrderBy WHEN 't_nutc' THEN [ttpisg230200].[t_nutc] END,
     CASE @OrderBy WHEN 't_nutc DESC' THEN [ttpisg230200].[t_nutc] END DESC 

    SET @RecordCount = @@RowCount

  SELECT
    [ttpisg230200].*  
  FROM [ttpisg230200] 
      INNER JOIN #PageIndex
          ON [ttpisg230200].[t_trdt] = #PageIndex.t_trdt
          AND [ttpisg230200].[t_bohd] = #PageIndex.t_bohd
          AND [ttpisg230200].[t_indv] = #PageIndex.t_indv
          AND [ttpisg230200].[t_srno] = #PageIndex.t_srno
          AND [ttpisg230200].[t_dsno] = #PageIndex.t_dsno
  WHERE
        #PageIndex.IndexID > @StartRowIndex
        AND #PageIndex.IndexID < (@StartRowIndex + @MaximumRows + 1)
  ORDER BY
    #PageIndex.IndexID
  END
  GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sptpisg230SelectListFilteres]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sptpisg230SelectListFilteres]
GO
 
CREATE PROCEDURE [dbo].[sptpisg230SelectListFilteres]
  @LoginID NVarChar(8),
  @StartRowIndex int,
  @MaximumRows int,
  @OrderBy NVarChar(50),
  @RecordCount Int = 0 OUTPUT
  AS
  BEGIN
  DECLARE @LGSQL VarChar(8000)
  CREATE TABLE #PageIndex (
  IndexID INT IDENTITY (1, 1) NOT NULL
 ,t_trdt DateTime NOT NULL
 ,t_bohd VarChar(50) NOT NULL
 ,t_indv VarChar(100) NOT NULL
 ,t_srno Int NOT NULL
 ,t_dsno Int NOT NULL
  )
  SET @LGSQL = 'INSERT INTO #PageIndex (' 
  SET @LGSQL = @LGSQL + 't_trdt'
  SET @LGSQL = @LGSQL + ', t_bohd'
  SET @LGSQL = @LGSQL + ', t_indv'
  SET @LGSQL = @LGSQL + ', t_srno'
  SET @LGSQL = @LGSQL + ', t_dsno'
  SET @LGSQL = @LGSQL + ')'
  SET @LGSQL = @LGSQL + ' SELECT '
  SET @LGSQL = @LGSQL + '[ttpisg230200].[t_trdt]'
  SET @LGSQL = @LGSQL + ', [ttpisg230200].[t_bohd]'
  SET @LGSQL = @LGSQL + ', [ttpisg230200].[t_indv]'
  SET @LGSQL = @LGSQL + ', [ttpisg230200].[t_srno]'
  SET @LGSQL = @LGSQL + ', [ttpisg230200].[t_dsno]'
  SET @LGSQL = @LGSQL + ' FROM [ttpisg230200] '
  SET @LGSQL = @LGSQL + '  WHERE 1 = 1 '
  SET @LGSQL = @LGSQL + '  ORDER BY '
  SET @LGSQL = @LGSQL + CASE @OrderBy
                        WHEN 't_trdt' THEN '[ttpisg230200].[t_trdt]'
                        WHEN 't_trdt DESC' THEN '[ttpisg230200].[t_trdt] DESC'
                        WHEN 't_bohd' THEN '[ttpisg230200].[t_bohd]'
                        WHEN 't_bohd DESC' THEN '[ttpisg230200].[t_bohd] DESC'
                        WHEN 't_indv' THEN '[ttpisg230200].[t_indv]'
                        WHEN 't_indv DESC' THEN '[ttpisg230200].[t_indv] DESC'
                        WHEN 't_srno' THEN '[ttpisg230200].[t_srno]'
                        WHEN 't_srno DESC' THEN '[ttpisg230200].[t_srno] DESC'
                        WHEN 't_dsno' THEN '[ttpisg230200].[t_dsno]'
                        WHEN 't_dsno DESC' THEN '[ttpisg230200].[t_dsno] DESC'
                        WHEN 't_stat' THEN '[ttpisg230200].[t_stat]'
                        WHEN 't_stat DESC' THEN '[ttpisg230200].[t_stat] DESC'
                        WHEN 't_proj' THEN '[ttpisg230200].[t_proj]'
                        WHEN 't_proj DESC' THEN '[ttpisg230200].[t_proj] DESC'
                        WHEN 't_elem' THEN '[ttpisg230200].[t_elem]'
                        WHEN 't_elem DESC' THEN '[ttpisg230200].[t_elem] DESC'
                        WHEN 't_dwno' THEN '[ttpisg230200].[t_dwno]'
                        WHEN 't_dwno DESC' THEN '[ttpisg230200].[t_dwno] DESC'
                        WHEN 't_pitc' THEN '[ttpisg230200].[t_pitc]'
                        WHEN 't_pitc DESC' THEN '[ttpisg230200].[t_pitc] DESC'
                        WHEN 't_wght' THEN '[ttpisg230200].[t_wght]'
                        WHEN 't_wght DESC' THEN '[ttpisg230200].[t_wght] DESC'
                        WHEN 't_atcd' THEN '[ttpisg230200].[t_atcd]'
                        WHEN 't_atcd DESC' THEN '[ttpisg230200].[t_atcd] DESC'
                        WHEN 't_scup' THEN '[ttpisg230200].[t_scup]'
                        WHEN 't_scup DESC' THEN '[ttpisg230200].[t_scup] DESC'
                        WHEN 't_acdt' THEN '[ttpisg230200].[t_acdt]'
                        WHEN 't_acdt DESC' THEN '[ttpisg230200].[t_acdt] DESC'
                        WHEN 't_acfh' THEN '[ttpisg230200].[t_acfh]'
                        WHEN 't_acfh DESC' THEN '[ttpisg230200].[t_acfh] DESC'
                        WHEN 't_pper' THEN '[ttpisg230200].[t_pper]'
                        WHEN 't_pper DESC' THEN '[ttpisg230200].[t_pper] DESC'
                        WHEN 't_lupd' THEN '[ttpisg230200].[t_lupd]'
                        WHEN 't_lupd DESC' THEN '[ttpisg230200].[t_lupd] DESC'
                        WHEN 't_Refcntd' THEN '[ttpisg230200].[t_Refcntd]'
                        WHEN 't_Refcntd DESC' THEN '[ttpisg230200].[t_Refcntd] DESC'
                        WHEN 't_Refcntu' THEN '[ttpisg230200].[t_Refcntu]'
                        WHEN 't_Refcntu DESC' THEN '[ttpisg230200].[t_Refcntu] DESC'
                        WHEN 't_numo' THEN '[ttpisg230200].[t_numo]'
                        WHEN 't_numo DESC' THEN '[ttpisg230200].[t_numo] DESC'
                        WHEN 't_numq' THEN '[ttpisg230200].[t_numq]'
                        WHEN 't_numq DESC' THEN '[ttpisg230200].[t_numq] DESC'
                        WHEN 't_numt' THEN '[ttpisg230200].[t_numt]'
                        WHEN 't_numt DESC' THEN '[ttpisg230200].[t_numt] DESC'
                        WHEN 't_numv' THEN '[ttpisg230200].[t_numv]'
                        WHEN 't_numv DESC' THEN '[ttpisg230200].[t_numv] DESC'
                        WHEN 't_nutc' THEN '[ttpisg230200].[t_nutc]'
                        WHEN 't_nutc DESC' THEN '[ttpisg230200].[t_nutc] DESC'
                        ELSE '[ttpisg230200].[t_trdt],[ttpisg230200].[t_bohd],[ttpisg230200].[t_indv],[ttpisg230200].[t_srno],[ttpisg230200].[t_dsno]'
                    END
  EXEC (@LGSQL)

  SET @RecordCount = @@RowCount

  SELECT
    [ttpisg230200].*  
  FROM [ttpisg230200] 
      INNER JOIN #PageIndex
          ON [ttpisg230200].[t_trdt] = #PageIndex.t_trdt
          AND [ttpisg230200].[t_bohd] = #PageIndex.t_bohd
          AND [ttpisg230200].[t_indv] = #PageIndex.t_indv
          AND [ttpisg230200].[t_srno] = #PageIndex.t_srno
          AND [ttpisg230200].[t_dsno] = #PageIndex.t_dsno
  WHERE
        #PageIndex.IndexID > @StartRowIndex
        AND #PageIndex.IndexID < (@StartRowIndex + @MaximumRows + 1)
  ORDER BY
    #PageIndex.IndexID
  END
  GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sptpisg230Insert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sptpisg230Insert]
GO
 
CREATE PROCEDURE [dbo].[sptpisg230Insert]
  @t_trdt DateTime,
  @t_bohd VarChar(50),
  @t_indv VarChar(100),
  @t_srno Int,
  @t_dsno Int,
  @t_stat VarChar(50),
  @t_proj VarChar(9),
  @t_elem VarChar(8),
  @t_dwno VarChar(32),
  @t_pitc Int,
  @t_wght Float,
  @t_atcd VarChar(8),
  @t_scup Int,
  @t_acdt DateTime,
  @t_acfh DateTime,
  @t_pper Real,
  @t_lupd DateTime,
  @t_Refcntd Int,
  @t_Refcntu Int,
  @t_numo Int,
  @t_numq Int,
  @t_numt Int,
  @t_numv Int,
  @t_nutc Int,
  @Return_t_trdt DateTime = null OUTPUT, 
  @Return_t_bohd VarChar(50) = null OUTPUT, 
  @Return_t_indv VarChar(100) = null OUTPUT, 
  @Return_t_srno Int = null OUTPUT, 
  @Return_t_dsno Int = null OUTPUT 
  AS
  INSERT [ttpisg230200]
  (
   [t_trdt]
  ,[t_bohd]
  ,[t_indv]
  ,[t_srno]
  ,[t_dsno]
  ,[t_stat]
  ,[t_proj]
  ,[t_elem]
  ,[t_dwno]
  ,[t_pitc]
  ,[t_wght]
  ,[t_atcd]
  ,[t_scup]
  ,[t_acdt]
  ,[t_acfh]
  ,[t_pper]
  ,[t_lupd]
  ,[t_Refcntd]
  ,[t_Refcntu]
  ,[t_numo]
  ,[t_numq]
  ,[t_numt]
  ,[t_numv]
  ,[t_nutc]
  )
  VALUES
  (
   @t_trdt
  ,UPPER(@t_bohd)
  ,UPPER(@t_indv)
  ,@t_srno
  ,@t_dsno
  ,@t_stat
  ,@t_proj
  ,@t_elem
  ,@t_dwno
  ,@t_pitc
  ,@t_wght
  ,@t_atcd
  ,@t_scup
  ,@t_acdt
  ,@t_acfh
  ,@t_pper
  ,@t_lupd
  ,@t_Refcntd
  ,@t_Refcntu
  ,@t_numo
  ,@t_numq
  ,@t_numt
  ,@t_numv
  ,@t_nutc
  )
  SET @Return_t_trdt = @t_trdt
  SET @Return_t_bohd = @t_bohd
  SET @Return_t_indv = @t_indv
  SET @Return_t_srno = @t_srno
  SET @Return_t_dsno = @t_dsno
  GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sptpisg230Update]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sptpisg230Update]
GO
 
CREATE PROCEDURE [dbo].[sptpisg230Update]
  @Original_t_trdt DateTime, 
  @Original_t_bohd VarChar(50), 
  @Original_t_indv VarChar(100), 
  @Original_t_srno Int, 
  @Original_t_dsno Int, 
  @t_trdt DateTime,
  @t_bohd VarChar(50),
  @t_indv VarChar(100),
  @t_srno Int,
  @t_dsno Int,
  @t_stat VarChar(50),
  @t_proj VarChar(9),
  @t_elem VarChar(8),
  @t_dwno VarChar(32),
  @t_pitc Int,
  @t_wght Float,
  @t_atcd VarChar(8),
  @t_scup Int,
  @t_acdt DateTime,
  @t_acfh DateTime,
  @t_pper Real,
  @t_lupd DateTime,
  @t_Refcntd Int,
  @t_Refcntu Int,
  @t_numo Int,
  @t_numq Int,
  @t_numt Int,
  @t_numv Int,
  @t_nutc Int,
  @RowCount int = null OUTPUT
  AS
  UPDATE [ttpisg230200] SET 
   [t_trdt] = @t_trdt
  ,[t_bohd] = @t_bohd
  ,[t_indv] = @t_indv
  ,[t_srno] = @t_srno
  ,[t_dsno] = @t_dsno
  ,[t_stat] = @t_stat
  ,[t_proj] = @t_proj
  ,[t_elem] = @t_elem
  ,[t_dwno] = @t_dwno
  ,[t_pitc] = @t_pitc
  ,[t_wght] = @t_wght
  ,[t_atcd] = @t_atcd
  ,[t_scup] = @t_scup
  ,[t_acdt] = @t_acdt
  ,[t_acfh] = @t_acfh
  ,[t_pper] = @t_pper
  ,[t_lupd] = @t_lupd
  ,[t_Refcntd] = @t_Refcntd
  ,[t_Refcntu] = @t_Refcntu
  ,[t_numo] = @t_numo
  ,[t_numq] = @t_numq
  ,[t_numt] = @t_numt
  ,[t_numv] = @t_numv
  ,[t_nutc] = @t_nutc
  WHERE
  [t_trdt] = @Original_t_trdt
  AND [t_bohd] = @Original_t_bohd
  AND [t_indv] = @Original_t_indv
  AND [t_srno] = @Original_t_srno
  AND [t_dsno] = @Original_t_dsno
  SET @RowCount = @@RowCount
  GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sptpisg230Delete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sptpisg230Delete]
GO
 
CREATE PROCEDURE [dbo].[sptpisg230Delete]
  @Original_t_trdt DateTime,
  @Original_t_bohd VarChar(50),
  @Original_t_indv VarChar(100),
  @Original_t_srno Int,
  @Original_t_dsno Int,
  @RowCount int = null OUTPUT
  AS
  DELETE [ttpisg230200]
  WHERE
  [ttpisg230200].[t_trdt] = @Original_t_trdt
  AND [ttpisg230200].[t_bohd] = @Original_t_bohd
  AND [ttpisg230200].[t_indv] = @Original_t_indv
  AND [ttpisg230200].[t_srno] = @Original_t_srno
  AND [ttpisg230200].[t_dsno] = @Original_t_dsno
  SET @RowCount = @@RowCount
  GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sptpisg220SelectByID]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sptpisg220SelectByID]
GO
 
CREATE PROCEDURE [dbo].[sptpisg220SelectByID]
  @LoginID NVarChar(8),
  @t_cprj VarChar(9),
  @t_pcod VarChar(9),
  @t_cact VarChar(30) 
  AS
  SELECT
    [ttpisg220200].*  
  FROM [ttpisg220200] 
  WHERE
  [ttpisg220200].[t_cprj] = @t_cprj
  AND [ttpisg220200].[t_pcod] = @t_pcod
  AND [ttpisg220200].[t_cact] = @t_cact
  GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sptpisg220SelectListSearch]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sptpisg220SelectListSearch]
GO
 
CREATE PROCEDURE [dbo].[sptpisg220SelectListSearch]
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
 ,t_cprj VarChar(9) NOT NULL
 ,t_pcod VarChar(9) NOT NULL
 ,t_cact VarChar(30) NOT NULL
  )
  INSERT INTO #PageIndex (t_cprj, t_pcod, t_cact)
  SELECT [ttpisg220200].[t_cprj], [ttpisg220200].[t_pcod], [ttpisg220200].[t_cact] FROM [ttpisg220200]
 WHERE  
   ( 
         LOWER(ISNULL([ttpisg220200].[t_cprj],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ttpisg220200].[t_pcod],'')) LIKE @KeyWord1
     OR STR(ISNULL([ttpisg220200].[t_schd], 0)) LIKE @KeyWord1
     OR LOWER(ISNULL([ttpisg220200].[t_cact],'')) LIKE @KeyWord1
     OR STR(ISNULL([ttpisg220200].[t_actp], 0)) LIKE @KeyWord1
     OR LOWER(ISNULL([ttpisg220200].[t_pact],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ttpisg220200].[t_bcod],'')) LIKE @KeyWord1
     OR STR(ISNULL([ttpisg220200].[t_dura], 0)) LIKE @KeyWord1
     OR LOWER(ISNULL([ttpisg220200].[t_bohd],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ttpisg220200].[t_pred],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ttpisg220200].[t_succ],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ttpisg220200].[t_desc],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ttpisg220200].[t_acty],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ttpisg220200].[t_dept],'')) LIKE @KeyWord1
     OR STR(ISNULL([ttpisg220200].[t_vali], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttpisg220200].[t_outl], 0)) LIKE @KeyWord1
     OR LOWER(ISNULL([ttpisg220200].[t_sub1],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ttpisg220200].[t_sub2],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ttpisg220200].[t_sub3],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ttpisg220200].[t_sub4],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ttpisg220200].[t_amod],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ttpisg220200].[t_pcbs],'')) LIKE @KeyWord1
     OR STR(ISNULL([ttpisg220200].[t_exdo], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttpisg220200].[t_cpgv], 0)) LIKE @KeyWord1
     OR LOWER(ISNULL([ttpisg220200].[t_rmks],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ttpisg220200].[t_gps1],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ttpisg220200].[t_gps2],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ttpisg220200].[t_gps3],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ttpisg220200].[t_gps4],'')) LIKE @KeyWord1
     OR STR(ISNULL([ttpisg220200].[t_valu], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttpisg220200].[t_sele], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttpisg220200].[t_Refcntd], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttpisg220200].[t_Refcntu], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttpisg220200].[t_numo], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttpisg220200].[t_numq], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttpisg220200].[t_numt], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttpisg220200].[t_numv], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttpisg220200].[t_nutc], 0)) LIKE @KeyWord1
   ) 
  ORDER BY
     CASE @OrderBy WHEN 't_cprj' THEN [ttpisg220200].[t_cprj] END,
     CASE @OrderBy WHEN 't_cprj DESC' THEN [ttpisg220200].[t_cprj] END DESC,
     CASE @OrderBy WHEN 't_pcod' THEN [ttpisg220200].[t_pcod] END,
     CASE @OrderBy WHEN 't_pcod DESC' THEN [ttpisg220200].[t_pcod] END DESC,
     CASE @OrderBy WHEN 't_schd' THEN [ttpisg220200].[t_schd] END,
     CASE @OrderBy WHEN 't_schd DESC' THEN [ttpisg220200].[t_schd] END DESC,
     CASE @OrderBy WHEN 't_cact' THEN [ttpisg220200].[t_cact] END,
     CASE @OrderBy WHEN 't_cact DESC' THEN [ttpisg220200].[t_cact] END DESC,
     CASE @OrderBy WHEN 't_actp' THEN [ttpisg220200].[t_actp] END,
     CASE @OrderBy WHEN 't_actp DESC' THEN [ttpisg220200].[t_actp] END DESC,
     CASE @OrderBy WHEN 't_pact' THEN [ttpisg220200].[t_pact] END,
     CASE @OrderBy WHEN 't_pact DESC' THEN [ttpisg220200].[t_pact] END DESC,
     CASE @OrderBy WHEN 't_bcod' THEN [ttpisg220200].[t_bcod] END,
     CASE @OrderBy WHEN 't_bcod DESC' THEN [ttpisg220200].[t_bcod] END DESC,
     CASE @OrderBy WHEN 't_dura' THEN [ttpisg220200].[t_dura] END,
     CASE @OrderBy WHEN 't_dura DESC' THEN [ttpisg220200].[t_dura] END DESC,
     CASE @OrderBy WHEN 't_sdst' THEN [ttpisg220200].[t_sdst] END,
     CASE @OrderBy WHEN 't_sdst DESC' THEN [ttpisg220200].[t_sdst] END DESC,
     CASE @OrderBy WHEN 't_sdfn' THEN [ttpisg220200].[t_sdfn] END,
     CASE @OrderBy WHEN 't_sdfn DESC' THEN [ttpisg220200].[t_sdfn] END DESC,
     CASE @OrderBy WHEN 't_acsd' THEN [ttpisg220200].[t_acsd] END,
     CASE @OrderBy WHEN 't_acsd DESC' THEN [ttpisg220200].[t_acsd] END DESC,
     CASE @OrderBy WHEN 't_acfn' THEN [ttpisg220200].[t_acfn] END,
     CASE @OrderBy WHEN 't_acfn DESC' THEN [ttpisg220200].[t_acfn] END DESC,
     CASE @OrderBy WHEN 't_bohd' THEN [ttpisg220200].[t_bohd] END,
     CASE @OrderBy WHEN 't_bohd DESC' THEN [ttpisg220200].[t_bohd] END DESC,
     CASE @OrderBy WHEN 't_pred' THEN [ttpisg220200].[t_pred] END,
     CASE @OrderBy WHEN 't_pred DESC' THEN [ttpisg220200].[t_pred] END DESC,
     CASE @OrderBy WHEN 't_succ' THEN [ttpisg220200].[t_succ] END,
     CASE @OrderBy WHEN 't_succ DESC' THEN [ttpisg220200].[t_succ] END DESC,
     CASE @OrderBy WHEN 't_desc' THEN [ttpisg220200].[t_desc] END,
     CASE @OrderBy WHEN 't_desc DESC' THEN [ttpisg220200].[t_desc] END DESC,
     CASE @OrderBy WHEN 't_acty' THEN [ttpisg220200].[t_acty] END,
     CASE @OrderBy WHEN 't_acty DESC' THEN [ttpisg220200].[t_acty] END DESC,
     CASE @OrderBy WHEN 't_dept' THEN [ttpisg220200].[t_dept] END,
     CASE @OrderBy WHEN 't_dept DESC' THEN [ttpisg220200].[t_dept] END DESC,
     CASE @OrderBy WHEN 't_vali' THEN [ttpisg220200].[t_vali] END,
     CASE @OrderBy WHEN 't_vali DESC' THEN [ttpisg220200].[t_vali] END DESC,
     CASE @OrderBy WHEN 't_outl' THEN [ttpisg220200].[t_outl] END,
     CASE @OrderBy WHEN 't_outl DESC' THEN [ttpisg220200].[t_outl] END DESC,
     CASE @OrderBy WHEN 't_sub1' THEN [ttpisg220200].[t_sub1] END,
     CASE @OrderBy WHEN 't_sub1 DESC' THEN [ttpisg220200].[t_sub1] END DESC,
     CASE @OrderBy WHEN 't_sub2' THEN [ttpisg220200].[t_sub2] END,
     CASE @OrderBy WHEN 't_sub2 DESC' THEN [ttpisg220200].[t_sub2] END DESC,
     CASE @OrderBy WHEN 't_sub3' THEN [ttpisg220200].[t_sub3] END,
     CASE @OrderBy WHEN 't_sub3 DESC' THEN [ttpisg220200].[t_sub3] END DESC,
     CASE @OrderBy WHEN 't_sub4' THEN [ttpisg220200].[t_sub4] END,
     CASE @OrderBy WHEN 't_sub4 DESC' THEN [ttpisg220200].[t_sub4] END DESC,
     CASE @OrderBy WHEN 't_amod' THEN [ttpisg220200].[t_amod] END,
     CASE @OrderBy WHEN 't_amod DESC' THEN [ttpisg220200].[t_amod] END DESC,
     CASE @OrderBy WHEN 't_pcbs' THEN [ttpisg220200].[t_pcbs] END,
     CASE @OrderBy WHEN 't_pcbs DESC' THEN [ttpisg220200].[t_pcbs] END DESC,
     CASE @OrderBy WHEN 't_exdo' THEN [ttpisg220200].[t_exdo] END,
     CASE @OrderBy WHEN 't_exdo DESC' THEN [ttpisg220200].[t_exdo] END DESC,
     CASE @OrderBy WHEN 't_cpgv' THEN [ttpisg220200].[t_cpgv] END,
     CASE @OrderBy WHEN 't_cpgv DESC' THEN [ttpisg220200].[t_cpgv] END DESC,
     CASE @OrderBy WHEN 't_otsd' THEN [ttpisg220200].[t_otsd] END,
     CASE @OrderBy WHEN 't_otsd DESC' THEN [ttpisg220200].[t_otsd] END DESC,
     CASE @OrderBy WHEN 't_oted' THEN [ttpisg220200].[t_oted] END,
     CASE @OrderBy WHEN 't_oted DESC' THEN [ttpisg220200].[t_oted] END DESC,
     CASE @OrderBy WHEN 't_rmks' THEN [ttpisg220200].[t_rmks] END,
     CASE @OrderBy WHEN 't_rmks DESC' THEN [ttpisg220200].[t_rmks] END DESC,
     CASE @OrderBy WHEN 't_gps1' THEN [ttpisg220200].[t_gps1] END,
     CASE @OrderBy WHEN 't_gps1 DESC' THEN [ttpisg220200].[t_gps1] END DESC,
     CASE @OrderBy WHEN 't_gps2' THEN [ttpisg220200].[t_gps2] END,
     CASE @OrderBy WHEN 't_gps2 DESC' THEN [ttpisg220200].[t_gps2] END DESC,
     CASE @OrderBy WHEN 't_gps3' THEN [ttpisg220200].[t_gps3] END,
     CASE @OrderBy WHEN 't_gps3 DESC' THEN [ttpisg220200].[t_gps3] END DESC,
     CASE @OrderBy WHEN 't_gps4' THEN [ttpisg220200].[t_gps4] END,
     CASE @OrderBy WHEN 't_gps4 DESC' THEN [ttpisg220200].[t_gps4] END DESC,
     CASE @OrderBy WHEN 't_pper' THEN [ttpisg220200].[t_pper] END,
     CASE @OrderBy WHEN 't_pper DESC' THEN [ttpisg220200].[t_pper] END DESC,
     CASE @OrderBy WHEN 't_valu' THEN [ttpisg220200].[t_valu] END,
     CASE @OrderBy WHEN 't_valu DESC' THEN [ttpisg220200].[t_valu] END DESC,
     CASE @OrderBy WHEN 't_sele' THEN [ttpisg220200].[t_sele] END,
     CASE @OrderBy WHEN 't_sele DESC' THEN [ttpisg220200].[t_sele] END DESC,
     CASE @OrderBy WHEN 't_Refcntd' THEN [ttpisg220200].[t_Refcntd] END,
     CASE @OrderBy WHEN 't_Refcntd DESC' THEN [ttpisg220200].[t_Refcntd] END DESC,
     CASE @OrderBy WHEN 't_Refcntu' THEN [ttpisg220200].[t_Refcntu] END,
     CASE @OrderBy WHEN 't_Refcntu DESC' THEN [ttpisg220200].[t_Refcntu] END DESC,
     CASE @OrderBy WHEN 't_numo' THEN [ttpisg220200].[t_numo] END,
     CASE @OrderBy WHEN 't_numo DESC' THEN [ttpisg220200].[t_numo] END DESC,
     CASE @OrderBy WHEN 't_numq' THEN [ttpisg220200].[t_numq] END,
     CASE @OrderBy WHEN 't_numq DESC' THEN [ttpisg220200].[t_numq] END DESC,
     CASE @OrderBy WHEN 't_numt' THEN [ttpisg220200].[t_numt] END,
     CASE @OrderBy WHEN 't_numt DESC' THEN [ttpisg220200].[t_numt] END DESC,
     CASE @OrderBy WHEN 't_numv' THEN [ttpisg220200].[t_numv] END,
     CASE @OrderBy WHEN 't_numv DESC' THEN [ttpisg220200].[t_numv] END DESC,
     CASE @OrderBy WHEN 't_nutc' THEN [ttpisg220200].[t_nutc] END,
     CASE @OrderBy WHEN 't_nutc DESC' THEN [ttpisg220200].[t_nutc] END DESC 

    SET @RecordCount = @@RowCount

  SELECT
    [ttpisg220200].*  
  FROM [ttpisg220200] 
      INNER JOIN #PageIndex
          ON [ttpisg220200].[t_cprj] = #PageIndex.t_cprj
          AND [ttpisg220200].[t_pcod] = #PageIndex.t_pcod
          AND [ttpisg220200].[t_cact] = #PageIndex.t_cact
  WHERE
        #PageIndex.IndexID > @StartRowIndex
        AND #PageIndex.IndexID < (@StartRowIndex + @MaximumRows + 1)
  ORDER BY
    #PageIndex.IndexID
  END
  GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sptpisg220SelectListFilteres]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sptpisg220SelectListFilteres]
GO
 
CREATE PROCEDURE [dbo].[sptpisg220SelectListFilteres]
  @LoginID NVarChar(8),
  @StartRowIndex int,
  @MaximumRows int,
  @OrderBy NVarChar(50),
  @RecordCount Int = 0 OUTPUT
  AS
  BEGIN
  DECLARE @LGSQL VarChar(8000)
  CREATE TABLE #PageIndex (
  IndexID INT IDENTITY (1, 1) NOT NULL
 ,t_cprj VarChar(9) NOT NULL
 ,t_pcod VarChar(9) NOT NULL
 ,t_cact VarChar(30) NOT NULL
  )
  SET @LGSQL = 'INSERT INTO #PageIndex (' 
  SET @LGSQL = @LGSQL + 't_cprj'
  SET @LGSQL = @LGSQL + ', t_pcod'
  SET @LGSQL = @LGSQL + ', t_cact'
  SET @LGSQL = @LGSQL + ')'
  SET @LGSQL = @LGSQL + ' SELECT '
  SET @LGSQL = @LGSQL + '[ttpisg220200].[t_cprj]'
  SET @LGSQL = @LGSQL + ', [ttpisg220200].[t_pcod]'
  SET @LGSQL = @LGSQL + ', [ttpisg220200].[t_cact]'
  SET @LGSQL = @LGSQL + ' FROM [ttpisg220200] '
  SET @LGSQL = @LGSQL + '  WHERE 1 = 1 '
  SET @LGSQL = @LGSQL + '  ORDER BY '
  SET @LGSQL = @LGSQL + CASE @OrderBy
                        WHEN 't_cprj' THEN '[ttpisg220200].[t_cprj]'
                        WHEN 't_cprj DESC' THEN '[ttpisg220200].[t_cprj] DESC'
                        WHEN 't_pcod' THEN '[ttpisg220200].[t_pcod]'
                        WHEN 't_pcod DESC' THEN '[ttpisg220200].[t_pcod] DESC'
                        WHEN 't_schd' THEN '[ttpisg220200].[t_schd]'
                        WHEN 't_schd DESC' THEN '[ttpisg220200].[t_schd] DESC'
                        WHEN 't_cact' THEN '[ttpisg220200].[t_cact]'
                        WHEN 't_cact DESC' THEN '[ttpisg220200].[t_cact] DESC'
                        WHEN 't_actp' THEN '[ttpisg220200].[t_actp]'
                        WHEN 't_actp DESC' THEN '[ttpisg220200].[t_actp] DESC'
                        WHEN 't_pact' THEN '[ttpisg220200].[t_pact]'
                        WHEN 't_pact DESC' THEN '[ttpisg220200].[t_pact] DESC'
                        WHEN 't_bcod' THEN '[ttpisg220200].[t_bcod]'
                        WHEN 't_bcod DESC' THEN '[ttpisg220200].[t_bcod] DESC'
                        WHEN 't_dura' THEN '[ttpisg220200].[t_dura]'
                        WHEN 't_dura DESC' THEN '[ttpisg220200].[t_dura] DESC'
                        WHEN 't_sdst' THEN '[ttpisg220200].[t_sdst]'
                        WHEN 't_sdst DESC' THEN '[ttpisg220200].[t_sdst] DESC'
                        WHEN 't_sdfn' THEN '[ttpisg220200].[t_sdfn]'
                        WHEN 't_sdfn DESC' THEN '[ttpisg220200].[t_sdfn] DESC'
                        WHEN 't_acsd' THEN '[ttpisg220200].[t_acsd]'
                        WHEN 't_acsd DESC' THEN '[ttpisg220200].[t_acsd] DESC'
                        WHEN 't_acfn' THEN '[ttpisg220200].[t_acfn]'
                        WHEN 't_acfn DESC' THEN '[ttpisg220200].[t_acfn] DESC'
                        WHEN 't_bohd' THEN '[ttpisg220200].[t_bohd]'
                        WHEN 't_bohd DESC' THEN '[ttpisg220200].[t_bohd] DESC'
                        WHEN 't_pred' THEN '[ttpisg220200].[t_pred]'
                        WHEN 't_pred DESC' THEN '[ttpisg220200].[t_pred] DESC'
                        WHEN 't_succ' THEN '[ttpisg220200].[t_succ]'
                        WHEN 't_succ DESC' THEN '[ttpisg220200].[t_succ] DESC'
                        WHEN 't_desc' THEN '[ttpisg220200].[t_desc]'
                        WHEN 't_desc DESC' THEN '[ttpisg220200].[t_desc] DESC'
                        WHEN 't_acty' THEN '[ttpisg220200].[t_acty]'
                        WHEN 't_acty DESC' THEN '[ttpisg220200].[t_acty] DESC'
                        WHEN 't_dept' THEN '[ttpisg220200].[t_dept]'
                        WHEN 't_dept DESC' THEN '[ttpisg220200].[t_dept] DESC'
                        WHEN 't_vali' THEN '[ttpisg220200].[t_vali]'
                        WHEN 't_vali DESC' THEN '[ttpisg220200].[t_vali] DESC'
                        WHEN 't_outl' THEN '[ttpisg220200].[t_outl]'
                        WHEN 't_outl DESC' THEN '[ttpisg220200].[t_outl] DESC'
                        WHEN 't_sub1' THEN '[ttpisg220200].[t_sub1]'
                        WHEN 't_sub1 DESC' THEN '[ttpisg220200].[t_sub1] DESC'
                        WHEN 't_sub2' THEN '[ttpisg220200].[t_sub2]'
                        WHEN 't_sub2 DESC' THEN '[ttpisg220200].[t_sub2] DESC'
                        WHEN 't_sub3' THEN '[ttpisg220200].[t_sub3]'
                        WHEN 't_sub3 DESC' THEN '[ttpisg220200].[t_sub3] DESC'
                        WHEN 't_sub4' THEN '[ttpisg220200].[t_sub4]'
                        WHEN 't_sub4 DESC' THEN '[ttpisg220200].[t_sub4] DESC'
                        WHEN 't_amod' THEN '[ttpisg220200].[t_amod]'
                        WHEN 't_amod DESC' THEN '[ttpisg220200].[t_amod] DESC'
                        WHEN 't_pcbs' THEN '[ttpisg220200].[t_pcbs]'
                        WHEN 't_pcbs DESC' THEN '[ttpisg220200].[t_pcbs] DESC'
                        WHEN 't_exdo' THEN '[ttpisg220200].[t_exdo]'
                        WHEN 't_exdo DESC' THEN '[ttpisg220200].[t_exdo] DESC'
                        WHEN 't_cpgv' THEN '[ttpisg220200].[t_cpgv]'
                        WHEN 't_cpgv DESC' THEN '[ttpisg220200].[t_cpgv] DESC'
                        WHEN 't_otsd' THEN '[ttpisg220200].[t_otsd]'
                        WHEN 't_otsd DESC' THEN '[ttpisg220200].[t_otsd] DESC'
                        WHEN 't_oted' THEN '[ttpisg220200].[t_oted]'
                        WHEN 't_oted DESC' THEN '[ttpisg220200].[t_oted] DESC'
                        WHEN 't_rmks' THEN '[ttpisg220200].[t_rmks]'
                        WHEN 't_rmks DESC' THEN '[ttpisg220200].[t_rmks] DESC'
                        WHEN 't_gps1' THEN '[ttpisg220200].[t_gps1]'
                        WHEN 't_gps1 DESC' THEN '[ttpisg220200].[t_gps1] DESC'
                        WHEN 't_gps2' THEN '[ttpisg220200].[t_gps2]'
                        WHEN 't_gps2 DESC' THEN '[ttpisg220200].[t_gps2] DESC'
                        WHEN 't_gps3' THEN '[ttpisg220200].[t_gps3]'
                        WHEN 't_gps3 DESC' THEN '[ttpisg220200].[t_gps3] DESC'
                        WHEN 't_gps4' THEN '[ttpisg220200].[t_gps4]'
                        WHEN 't_gps4 DESC' THEN '[ttpisg220200].[t_gps4] DESC'
                        WHEN 't_pper' THEN '[ttpisg220200].[t_pper]'
                        WHEN 't_pper DESC' THEN '[ttpisg220200].[t_pper] DESC'
                        WHEN 't_valu' THEN '[ttpisg220200].[t_valu]'
                        WHEN 't_valu DESC' THEN '[ttpisg220200].[t_valu] DESC'
                        WHEN 't_sele' THEN '[ttpisg220200].[t_sele]'
                        WHEN 't_sele DESC' THEN '[ttpisg220200].[t_sele] DESC'
                        WHEN 't_Refcntd' THEN '[ttpisg220200].[t_Refcntd]'
                        WHEN 't_Refcntd DESC' THEN '[ttpisg220200].[t_Refcntd] DESC'
                        WHEN 't_Refcntu' THEN '[ttpisg220200].[t_Refcntu]'
                        WHEN 't_Refcntu DESC' THEN '[ttpisg220200].[t_Refcntu] DESC'
                        WHEN 't_numo' THEN '[ttpisg220200].[t_numo]'
                        WHEN 't_numo DESC' THEN '[ttpisg220200].[t_numo] DESC'
                        WHEN 't_numq' THEN '[ttpisg220200].[t_numq]'
                        WHEN 't_numq DESC' THEN '[ttpisg220200].[t_numq] DESC'
                        WHEN 't_numt' THEN '[ttpisg220200].[t_numt]'
                        WHEN 't_numt DESC' THEN '[ttpisg220200].[t_numt] DESC'
                        WHEN 't_numv' THEN '[ttpisg220200].[t_numv]'
                        WHEN 't_numv DESC' THEN '[ttpisg220200].[t_numv] DESC'
                        WHEN 't_nutc' THEN '[ttpisg220200].[t_nutc]'
                        WHEN 't_nutc DESC' THEN '[ttpisg220200].[t_nutc] DESC'
                        ELSE '[ttpisg220200].[t_cprj],[ttpisg220200].[t_pcod],[ttpisg220200].[t_cact]'
                    END
  EXEC (@LGSQL)

  SET @RecordCount = @@RowCount

  SELECT
    [ttpisg220200].*  
  FROM [ttpisg220200] 
      INNER JOIN #PageIndex
          ON [ttpisg220200].[t_cprj] = #PageIndex.t_cprj
          AND [ttpisg220200].[t_pcod] = #PageIndex.t_pcod
          AND [ttpisg220200].[t_cact] = #PageIndex.t_cact
  WHERE
        #PageIndex.IndexID > @StartRowIndex
        AND #PageIndex.IndexID < (@StartRowIndex + @MaximumRows + 1)
  ORDER BY
    #PageIndex.IndexID
  END
  GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sptpisg220Insert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sptpisg220Insert]
GO
 
CREATE PROCEDURE [dbo].[sptpisg220Insert]
  @t_cprj VarChar(9),
  @t_pcod VarChar(9),
  @t_schd Int,
  @t_cact VarChar(30),
  @t_actp Int,
  @t_pact VarChar(30),
  @t_bcod VarChar(9),
  @t_dura Int,
  @t_sdst DateTime,
  @t_sdfn DateTime,
  @t_acsd DateTime,
  @t_acfn DateTime,
  @t_bohd VarChar(20),
  @t_pred VarChar(200),
  @t_succ VarChar(200),
  @t_desc VarChar(256),
  @t_acty VarChar(9),
  @t_dept VarChar(9),
  @t_vali Int,
  @t_outl Int,
  @t_sub1 VarChar(200),
  @t_sub2 VarChar(150),
  @t_sub3 VarChar(150),
  @t_sub4 VarChar(150),
  @t_amod VarChar(20),
  @t_pcbs VarChar(20),
  @t_exdo Int,
  @t_cpgv Float,
  @t_otsd DateTime,
  @t_oted DateTime,
  @t_rmks VarChar(500),
  @t_gps1 VarChar(100),
  @t_gps2 VarChar(100),
  @t_gps3 VarChar(100),
  @t_gps4 VarChar(250),
  @t_pper Real,
  @t_valu Float,
  @t_sele Int,
  @t_Refcntd Int,
  @t_Refcntu Int,
  @t_numo Int,
  @t_numq Int,
  @t_numt Int,
  @t_numv Int,
  @t_nutc Int,
  @Return_t_cprj VarChar(9) = null OUTPUT, 
  @Return_t_pcod VarChar(9) = null OUTPUT, 
  @Return_t_cact VarChar(30) = null OUTPUT 
  AS
  INSERT [ttpisg220200]
  (
   [t_cprj]
  ,[t_pcod]
  ,[t_schd]
  ,[t_cact]
  ,[t_actp]
  ,[t_pact]
  ,[t_bcod]
  ,[t_dura]
  ,[t_sdst]
  ,[t_sdfn]
  ,[t_acsd]
  ,[t_acfn]
  ,[t_bohd]
  ,[t_pred]
  ,[t_succ]
  ,[t_desc]
  ,[t_acty]
  ,[t_dept]
  ,[t_vali]
  ,[t_outl]
  ,[t_sub1]
  ,[t_sub2]
  ,[t_sub3]
  ,[t_sub4]
  ,[t_amod]
  ,[t_pcbs]
  ,[t_exdo]
  ,[t_cpgv]
  ,[t_otsd]
  ,[t_oted]
  ,[t_rmks]
  ,[t_gps1]
  ,[t_gps2]
  ,[t_gps3]
  ,[t_gps4]
  ,[t_pper]
  ,[t_valu]
  ,[t_sele]
  ,[t_Refcntd]
  ,[t_Refcntu]
  ,[t_numo]
  ,[t_numq]
  ,[t_numt]
  ,[t_numv]
  ,[t_nutc]
  )
  VALUES
  (
   UPPER(@t_cprj)
  ,UPPER(@t_pcod)
  ,@t_schd
  ,UPPER(@t_cact)
  ,@t_actp
  ,@t_pact
  ,@t_bcod
  ,@t_dura
  ,@t_sdst
  ,@t_sdfn
  ,@t_acsd
  ,@t_acfn
  ,@t_bohd
  ,@t_pred
  ,@t_succ
  ,@t_desc
  ,@t_acty
  ,@t_dept
  ,@t_vali
  ,@t_outl
  ,@t_sub1
  ,@t_sub2
  ,@t_sub3
  ,@t_sub4
  ,@t_amod
  ,@t_pcbs
  ,@t_exdo
  ,@t_cpgv
  ,@t_otsd
  ,@t_oted
  ,@t_rmks
  ,@t_gps1
  ,@t_gps2
  ,@t_gps3
  ,@t_gps4
  ,@t_pper
  ,@t_valu
  ,@t_sele
  ,@t_Refcntd
  ,@t_Refcntu
  ,@t_numo
  ,@t_numq
  ,@t_numt
  ,@t_numv
  ,@t_nutc
  )
  SET @Return_t_cprj = @t_cprj
  SET @Return_t_pcod = @t_pcod
  SET @Return_t_cact = @t_cact
  GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sptpisg220Update]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sptpisg220Update]
GO
 
CREATE PROCEDURE [dbo].[sptpisg220Update]
  @Original_t_cprj VarChar(9), 
  @Original_t_pcod VarChar(9), 
  @Original_t_cact VarChar(30), 
  @t_cprj VarChar(9),
  @t_pcod VarChar(9),
  @t_schd Int,
  @t_cact VarChar(30),
  @t_actp Int,
  @t_pact VarChar(30),
  @t_bcod VarChar(9),
  @t_dura Int,
  @t_sdst DateTime,
  @t_sdfn DateTime,
  @t_acsd DateTime,
  @t_acfn DateTime,
  @t_bohd VarChar(20),
  @t_pred VarChar(200),
  @t_succ VarChar(200),
  @t_desc VarChar(256),
  @t_acty VarChar(9),
  @t_dept VarChar(9),
  @t_vali Int,
  @t_outl Int,
  @t_sub1 VarChar(200),
  @t_sub2 VarChar(150),
  @t_sub3 VarChar(150),
  @t_sub4 VarChar(150),
  @t_amod VarChar(20),
  @t_pcbs VarChar(20),
  @t_exdo Int,
  @t_cpgv Float,
  @t_otsd DateTime,
  @t_oted DateTime,
  @t_rmks VarChar(500),
  @t_gps1 VarChar(100),
  @t_gps2 VarChar(100),
  @t_gps3 VarChar(100),
  @t_gps4 VarChar(250),
  @t_pper Real,
  @t_valu Float,
  @t_sele Int,
  @t_Refcntd Int,
  @t_Refcntu Int,
  @t_numo Int,
  @t_numq Int,
  @t_numt Int,
  @t_numv Int,
  @t_nutc Int,
  @RowCount int = null OUTPUT
  AS
  UPDATE [ttpisg220200] SET 
   [t_cprj] = @t_cprj
  ,[t_pcod] = @t_pcod
  ,[t_schd] = @t_schd
  ,[t_cact] = @t_cact
  ,[t_actp] = @t_actp
  ,[t_pact] = @t_pact
  ,[t_bcod] = @t_bcod
  ,[t_dura] = @t_dura
  ,[t_sdst] = @t_sdst
  ,[t_sdfn] = @t_sdfn
  ,[t_acsd] = @t_acsd
  ,[t_acfn] = @t_acfn
  ,[t_bohd] = @t_bohd
  ,[t_pred] = @t_pred
  ,[t_succ] = @t_succ
  ,[t_desc] = @t_desc
  ,[t_acty] = @t_acty
  ,[t_dept] = @t_dept
  ,[t_vali] = @t_vali
  ,[t_outl] = @t_outl
  ,[t_sub1] = @t_sub1
  ,[t_sub2] = @t_sub2
  ,[t_sub3] = @t_sub3
  ,[t_sub4] = @t_sub4
  ,[t_amod] = @t_amod
  ,[t_pcbs] = @t_pcbs
  ,[t_exdo] = @t_exdo
  ,[t_cpgv] = @t_cpgv
  ,[t_otsd] = @t_otsd
  ,[t_oted] = @t_oted
  ,[t_rmks] = @t_rmks
  ,[t_gps1] = @t_gps1
  ,[t_gps2] = @t_gps2
  ,[t_gps3] = @t_gps3
  ,[t_gps4] = @t_gps4
  ,[t_pper] = @t_pper
  ,[t_valu] = @t_valu
  ,[t_sele] = @t_sele
  ,[t_Refcntd] = @t_Refcntd
  ,[t_Refcntu] = @t_Refcntu
  ,[t_numo] = @t_numo
  ,[t_numq] = @t_numq
  ,[t_numt] = @t_numt
  ,[t_numv] = @t_numv
  ,[t_nutc] = @t_nutc
  WHERE
  [t_cprj] = @Original_t_cprj
  AND [t_pcod] = @Original_t_pcod
  AND [t_cact] = @Original_t_cact
  SET @RowCount = @@RowCount
  GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sptpisg220Delete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sptpisg220Delete]
GO
 
CREATE PROCEDURE [dbo].[sptpisg220Delete]
  @Original_t_cprj VarChar(9),
  @Original_t_pcod VarChar(9),
  @Original_t_cact VarChar(30),
  @RowCount int = null OUTPUT
  AS
  DELETE [ttpisg220200]
  WHERE
  [ttpisg220200].[t_cprj] = @Original_t_cprj
  AND [ttpisg220200].[t_pcod] = @Original_t_pcod
  AND [ttpisg220200].[t_cact] = @Original_t_cact
  SET @RowCount = @@RowCount
  GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spdmisg140SelectByID]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spdmisg140SelectByID]
GO
 
CREATE PROCEDURE [dbo].[spdmisg140SelectByID]
  @LoginID NVarChar(8),
  @t_pcod VarChar(9),
  @t_cprj VarChar(9),
  @t_uidn VarChar(25) 
  AS
  SELECT
    [tdmisg140200].*  
  FROM [tdmisg140200] 
  WHERE
  [tdmisg140200].[t_pcod] = @t_pcod
  AND [tdmisg140200].[t_cprj] = @t_cprj
  AND [tdmisg140200].[t_uidn] = @t_uidn
  GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spdmisg140SelectListSearch]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spdmisg140SelectListSearch]
GO
 
CREATE PROCEDURE [dbo].[spdmisg140SelectListSearch]
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
 ,t_pcod VarChar(9) NOT NULL
 ,t_cprj VarChar(9) NOT NULL
 ,t_uidn VarChar(25) NOT NULL
  )
  INSERT INTO #PageIndex (t_pcod, t_cprj, t_uidn)
  SELECT [tdmisg140200].[t_pcod], [tdmisg140200].[t_cprj], [tdmisg140200].[t_uidn] FROM [tdmisg140200]
 WHERE  
   ( 
         LOWER(ISNULL([tdmisg140200].[t_pcod],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([tdmisg140200].[t_cprj],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([tdmisg140200].[t_uidn],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([tdmisg140200].[t_revn],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([tdmisg140200].[t_docn],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([tdmisg140200].[t_dsca],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([tdmisg140200].[t_aldo],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([tdmisg140200].[t_alre],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([tdmisg140200].[t_cspa],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([tdmisg140200].[t_type],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([tdmisg140200].[t_resp],'')) LIKE @KeyWord1
     OR STR(ISNULL([tdmisg140200].[t_size], 0)) LIKE @KeyWord1
     OR LOWER(ISNULL([tdmisg140200].[t_orgn],'')) LIKE @KeyWord1
     OR STR(ISNULL([tdmisg140200].[t_subm], 0)) LIKE @KeyWord1
     OR STR(ISNULL([tdmisg140200].[t_intr], 0)) LIKE @KeyWord1
     OR STR(ISNULL([tdmisg140200].[t_prod], 0)) LIKE @KeyWord1
     OR STR(ISNULL([tdmisg140200].[t_erec], 0)) LIKE @KeyWord1
     OR STR(ISNULL([tdmisg140200].[t_info], 0)) LIKE @KeyWord1
     OR LOWER(ISNULL([tdmisg140200].[t_remk],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([tdmisg140200].[t_soft],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([tdmisg140200].[t_drwn],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([tdmisg140200].[t_chec],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([tdmisg140200].[t_engg],'')) LIKE @KeyWord1
     OR STR(ISNULL([tdmisg140200].[t_dhrs], 0)) LIKE @KeyWord1
     OR STR(ISNULL([tdmisg140200].[t_chrs], 0)) LIKE @KeyWord1
     OR STR(ISNULL([tdmisg140200].[t_ehrs], 0)) LIKE @KeyWord1
     OR STR(ISNULL([tdmisg140200].[t_lmhr], 0)) LIKE @KeyWord1
     OR LOWER(ISNULL([tdmisg140200].[t_upby],'')) LIKE @KeyWord1
     OR STR(ISNULL([tdmisg140200].[t_dwgs], 0)) LIKE @KeyWord1
     OR LOWER(ISNULL([tdmisg140200].[t_genm],'')) LIKE @KeyWord1
     OR STR(ISNULL([tdmisg140200].[t_inpt], 0)) LIKE @KeyWord1
     OR STR(ISNULL([tdmisg140200].[t_seqn], 0)) LIKE @KeyWord1
     OR LOWER(ISNULL([tdmisg140200].[t_rfsv],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([tdmisg140200].[t_irst],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([tdmisg140200].[t_drep],'')) LIKE @KeyWord1
     OR STR(ISNULL([tdmisg140200].[t_oscd], 0)) LIKE @KeyWord1
     OR STR(ISNULL([tdmisg140200].[t_Refcntd], 0)) LIKE @KeyWord1
     OR STR(ISNULL([tdmisg140200].[t_Refcntu], 0)) LIKE @KeyWord1
     OR LOWER(ISNULL([tdmisg140200].[t_pled],'')) LIKE @KeyWord1
     OR STR(ISNULL([tdmisg140200].[t_appr], 0)) LIKE @KeyWord1
     OR STR(ISNULL([tdmisg140200].[t_selc], 0)) LIKE @KeyWord1
     OR LOWER(ISNULL([tdmisg140200].[t_acty],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([tdmisg140200].[t_iref],'')) LIKE @KeyWord1
     OR STR(ISNULL([tdmisg140200].[t_dpct], 0)) LIKE @KeyWord1
     OR STR(ISNULL([tdmisg140200].[t_dpwt], 0)) LIKE @KeyWord1
     OR STR(ISNULL([tdmisg140200].[t_idct], 0)) LIKE @KeyWord1
     OR STR(ISNULL([tdmisg140200].[t_idwt], 0)) LIKE @KeyWord1
     OR STR(ISNULL([tdmisg140200].[t_popt], 0)) LIKE @KeyWord1
     OR STR(ISNULL([tdmisg140200].[t_posw], 0)) LIKE @KeyWord1
     OR STR(ISNULL([tdmisg140200].[t_powt], 0)) LIKE @KeyWord1
     OR STR(ISNULL([tdmisg140200].[t_pspt], 0)) LIKE @KeyWord1
     OR STR(ISNULL([tdmisg140200].[t_upct], 0)) LIKE @KeyWord1
     OR STR(ISNULL([tdmisg140200].[t_piwt], 0)) LIKE @KeyWord1
     OR STR(ISNULL([tdmisg140200].[t_poic], 0)) LIKE @KeyWord1
     OR STR(ISNULL([tdmisg140200].[t_numo], 0)) LIKE @KeyWord1
     OR STR(ISNULL([tdmisg140200].[t_numq], 0)) LIKE @KeyWord1
     OR STR(ISNULL([tdmisg140200].[t_numt], 0)) LIKE @KeyWord1
     OR STR(ISNULL([tdmisg140200].[t_numv], 0)) LIKE @KeyWord1
     OR STR(ISNULL([tdmisg140200].[t_nutc], 0)) LIKE @KeyWord1
   ) 
  ORDER BY
     CASE @OrderBy WHEN 't_pcod' THEN [tdmisg140200].[t_pcod] END,
     CASE @OrderBy WHEN 't_pcod DESC' THEN [tdmisg140200].[t_pcod] END DESC,
     CASE @OrderBy WHEN 't_cprj' THEN [tdmisg140200].[t_cprj] END,
     CASE @OrderBy WHEN 't_cprj DESC' THEN [tdmisg140200].[t_cprj] END DESC,
     CASE @OrderBy WHEN 't_uidn' THEN [tdmisg140200].[t_uidn] END,
     CASE @OrderBy WHEN 't_uidn DESC' THEN [tdmisg140200].[t_uidn] END DESC,
     CASE @OrderBy WHEN 't_revn' THEN [tdmisg140200].[t_revn] END,
     CASE @OrderBy WHEN 't_revn DESC' THEN [tdmisg140200].[t_revn] END DESC,
     CASE @OrderBy WHEN 't_docn' THEN [tdmisg140200].[t_docn] END,
     CASE @OrderBy WHEN 't_docn DESC' THEN [tdmisg140200].[t_docn] END DESC,
     CASE @OrderBy WHEN 't_dsca' THEN [tdmisg140200].[t_dsca] END,
     CASE @OrderBy WHEN 't_dsca DESC' THEN [tdmisg140200].[t_dsca] END DESC,
     CASE @OrderBy WHEN 't_aldo' THEN [tdmisg140200].[t_aldo] END,
     CASE @OrderBy WHEN 't_aldo DESC' THEN [tdmisg140200].[t_aldo] END DESC,
     CASE @OrderBy WHEN 't_alre' THEN [tdmisg140200].[t_alre] END,
     CASE @OrderBy WHEN 't_alre DESC' THEN [tdmisg140200].[t_alre] END DESC,
     CASE @OrderBy WHEN 't_cspa' THEN [tdmisg140200].[t_cspa] END,
     CASE @OrderBy WHEN 't_cspa DESC' THEN [tdmisg140200].[t_cspa] END DESC,
     CASE @OrderBy WHEN 't_type' THEN [tdmisg140200].[t_type] END,
     CASE @OrderBy WHEN 't_type DESC' THEN [tdmisg140200].[t_type] END DESC,
     CASE @OrderBy WHEN 't_resp' THEN [tdmisg140200].[t_resp] END,
     CASE @OrderBy WHEN 't_resp DESC' THEN [tdmisg140200].[t_resp] END DESC,
     CASE @OrderBy WHEN 't_size' THEN [tdmisg140200].[t_size] END,
     CASE @OrderBy WHEN 't_size DESC' THEN [tdmisg140200].[t_size] END DESC,
     CASE @OrderBy WHEN 't_orgn' THEN [tdmisg140200].[t_orgn] END,
     CASE @OrderBy WHEN 't_orgn DESC' THEN [tdmisg140200].[t_orgn] END DESC,
     CASE @OrderBy WHEN 't_subm' THEN [tdmisg140200].[t_subm] END,
     CASE @OrderBy WHEN 't_subm DESC' THEN [tdmisg140200].[t_subm] END DESC,
     CASE @OrderBy WHEN 't_intr' THEN [tdmisg140200].[t_intr] END,
     CASE @OrderBy WHEN 't_intr DESC' THEN [tdmisg140200].[t_intr] END DESC,
     CASE @OrderBy WHEN 't_prod' THEN [tdmisg140200].[t_prod] END,
     CASE @OrderBy WHEN 't_prod DESC' THEN [tdmisg140200].[t_prod] END DESC,
     CASE @OrderBy WHEN 't_erec' THEN [tdmisg140200].[t_erec] END,
     CASE @OrderBy WHEN 't_erec DESC' THEN [tdmisg140200].[t_erec] END DESC,
     CASE @OrderBy WHEN 't_info' THEN [tdmisg140200].[t_info] END,
     CASE @OrderBy WHEN 't_info DESC' THEN [tdmisg140200].[t_info] END DESC,
     CASE @OrderBy WHEN 't_remk' THEN [tdmisg140200].[t_remk] END,
     CASE @OrderBy WHEN 't_remk DESC' THEN [tdmisg140200].[t_remk] END DESC,
     CASE @OrderBy WHEN 't_soft' THEN [tdmisg140200].[t_soft] END,
     CASE @OrderBy WHEN 't_soft DESC' THEN [tdmisg140200].[t_soft] END DESC,
     CASE @OrderBy WHEN 't_drwn' THEN [tdmisg140200].[t_drwn] END,
     CASE @OrderBy WHEN 't_drwn DESC' THEN [tdmisg140200].[t_drwn] END DESC,
     CASE @OrderBy WHEN 't_chec' THEN [tdmisg140200].[t_chec] END,
     CASE @OrderBy WHEN 't_chec DESC' THEN [tdmisg140200].[t_chec] END DESC,
     CASE @OrderBy WHEN 't_engg' THEN [tdmisg140200].[t_engg] END,
     CASE @OrderBy WHEN 't_engg DESC' THEN [tdmisg140200].[t_engg] END DESC,
     CASE @OrderBy WHEN 't_dhrs' THEN [tdmisg140200].[t_dhrs] END,
     CASE @OrderBy WHEN 't_dhrs DESC' THEN [tdmisg140200].[t_dhrs] END DESC,
     CASE @OrderBy WHEN 't_chrs' THEN [tdmisg140200].[t_chrs] END,
     CASE @OrderBy WHEN 't_chrs DESC' THEN [tdmisg140200].[t_chrs] END DESC,
     CASE @OrderBy WHEN 't_ehrs' THEN [tdmisg140200].[t_ehrs] END,
     CASE @OrderBy WHEN 't_ehrs DESC' THEN [tdmisg140200].[t_ehrs] END DESC,
     CASE @OrderBy WHEN 't_lmhr' THEN [tdmisg140200].[t_lmhr] END,
     CASE @OrderBy WHEN 't_lmhr DESC' THEN [tdmisg140200].[t_lmhr] END DESC,
     CASE @OrderBy WHEN 't_acdt' THEN [tdmisg140200].[t_acdt] END,
     CASE @OrderBy WHEN 't_acdt DESC' THEN [tdmisg140200].[t_acdt] END DESC,
     CASE @OrderBy WHEN 't_upby' THEN [tdmisg140200].[t_upby] END,
     CASE @OrderBy WHEN 't_upby DESC' THEN [tdmisg140200].[t_upby] END DESC,
     CASE @OrderBy WHEN 't_updt' THEN [tdmisg140200].[t_updt] END,
     CASE @OrderBy WHEN 't_updt DESC' THEN [tdmisg140200].[t_updt] END DESC,
     CASE @OrderBy WHEN 't_dwgs' THEN [tdmisg140200].[t_dwgs] END,
     CASE @OrderBy WHEN 't_dwgs DESC' THEN [tdmisg140200].[t_dwgs] END DESC,
     CASE @OrderBy WHEN 't_genm' THEN [tdmisg140200].[t_genm] END,
     CASE @OrderBy WHEN 't_genm DESC' THEN [tdmisg140200].[t_genm] END DESC,
     CASE @OrderBy WHEN 't_inpt' THEN [tdmisg140200].[t_inpt] END,
     CASE @OrderBy WHEN 't_inpt DESC' THEN [tdmisg140200].[t_inpt] END DESC,
     CASE @OrderBy WHEN 't_seqn' THEN [tdmisg140200].[t_seqn] END,
     CASE @OrderBy WHEN 't_seqn DESC' THEN [tdmisg140200].[t_seqn] END DESC,
     CASE @OrderBy WHEN 't_bssd' THEN [tdmisg140200].[t_bssd] END,
     CASE @OrderBy WHEN 't_bssd DESC' THEN [tdmisg140200].[t_bssd] END DESC,
     CASE @OrderBy WHEN 't_bsfd' THEN [tdmisg140200].[t_bsfd] END,
     CASE @OrderBy WHEN 't_bsfd DESC' THEN [tdmisg140200].[t_bsfd] END DESC,
     CASE @OrderBy WHEN 't_rssd' THEN [tdmisg140200].[t_rssd] END,
     CASE @OrderBy WHEN 't_rssd DESC' THEN [tdmisg140200].[t_rssd] END DESC,
     CASE @OrderBy WHEN 't_rsfd' THEN [tdmisg140200].[t_rsfd] END,
     CASE @OrderBy WHEN 't_rsfd DESC' THEN [tdmisg140200].[t_rsfd] END DESC,
     CASE @OrderBy WHEN 't_lrrd' THEN [tdmisg140200].[t_lrrd] END,
     CASE @OrderBy WHEN 't_lrrd DESC' THEN [tdmisg140200].[t_lrrd] END DESC,
     CASE @OrderBy WHEN 't_rfsv' THEN [tdmisg140200].[t_rfsv] END,
     CASE @OrderBy WHEN 't_rfsv DESC' THEN [tdmisg140200].[t_rfsv] END DESC,
     CASE @OrderBy WHEN 't_irst' THEN [tdmisg140200].[t_irst] END,
     CASE @OrderBy WHEN 't_irst DESC' THEN [tdmisg140200].[t_irst] END DESC,
     CASE @OrderBy WHEN 't_dref' THEN [tdmisg140200].[t_dref] END,
     CASE @OrderBy WHEN 't_dref DESC' THEN [tdmisg140200].[t_dref] END DESC,
     CASE @OrderBy WHEN 't_chef' THEN [tdmisg140200].[t_chef] END,
     CASE @OrderBy WHEN 't_chef DESC' THEN [tdmisg140200].[t_chef] END DESC,
     CASE @OrderBy WHEN 't_leef' THEN [tdmisg140200].[t_leef] END,
     CASE @OrderBy WHEN 't_leef DESC' THEN [tdmisg140200].[t_leef] END DESC,
     CASE @OrderBy WHEN 't_lmef' THEN [tdmisg140200].[t_lmef] END,
     CASE @OrderBy WHEN 't_lmef DESC' THEN [tdmisg140200].[t_lmef] END DESC,
     CASE @OrderBy WHEN 't_drep' THEN [tdmisg140200].[t_drep] END,
     CASE @OrderBy WHEN 't_drep DESC' THEN [tdmisg140200].[t_drep] END DESC,
     CASE @OrderBy WHEN 't_oscd' THEN [tdmisg140200].[t_oscd] END,
     CASE @OrderBy WHEN 't_oscd DESC' THEN [tdmisg140200].[t_oscd] END DESC,
     CASE @OrderBy WHEN 't_Refcntd' THEN [tdmisg140200].[t_Refcntd] END,
     CASE @OrderBy WHEN 't_Refcntd DESC' THEN [tdmisg140200].[t_Refcntd] END DESC,
     CASE @OrderBy WHEN 't_Refcntu' THEN [tdmisg140200].[t_Refcntu] END,
     CASE @OrderBy WHEN 't_Refcntu DESC' THEN [tdmisg140200].[t_Refcntu] END DESC,
     CASE @OrderBy WHEN 't_pled' THEN [tdmisg140200].[t_pled] END,
     CASE @OrderBy WHEN 't_pled DESC' THEN [tdmisg140200].[t_pled] END DESC,
     CASE @OrderBy WHEN 't_appr' THEN [tdmisg140200].[t_appr] END,
     CASE @OrderBy WHEN 't_appr DESC' THEN [tdmisg140200].[t_appr] END DESC,
     CASE @OrderBy WHEN 't_rdat' THEN [tdmisg140200].[t_rdat] END,
     CASE @OrderBy WHEN 't_rdat DESC' THEN [tdmisg140200].[t_rdat] END DESC,
     CASE @OrderBy WHEN 't_selc' THEN [tdmisg140200].[t_selc] END,
     CASE @OrderBy WHEN 't_selc DESC' THEN [tdmisg140200].[t_selc] END DESC,
     CASE @OrderBy WHEN 't_acty' THEN [tdmisg140200].[t_acty] END,
     CASE @OrderBy WHEN 't_acty DESC' THEN [tdmisg140200].[t_acty] END DESC,
     CASE @OrderBy WHEN 't_fadt' THEN [tdmisg140200].[t_fadt] END,
     CASE @OrderBy WHEN 't_fadt DESC' THEN [tdmisg140200].[t_fadt] END DESC,
     CASE @OrderBy WHEN 't_iadt' THEN [tdmisg140200].[t_iadt] END,
     CASE @OrderBy WHEN 't_iadt DESC' THEN [tdmisg140200].[t_iadt] END DESC,
     CASE @OrderBy WHEN 't_iref' THEN [tdmisg140200].[t_iref] END,
     CASE @OrderBy WHEN 't_iref DESC' THEN [tdmisg140200].[t_iref] END DESC,
     CASE @OrderBy WHEN 't_itdt' THEN [tdmisg140200].[t_itdt] END,
     CASE @OrderBy WHEN 't_itdt DESC' THEN [tdmisg140200].[t_itdt] END DESC,
     CASE @OrderBy WHEN 't_padt' THEN [tdmisg140200].[t_padt] END,
     CASE @OrderBy WHEN 't_padt DESC' THEN [tdmisg140200].[t_padt] END DESC,
     CASE @OrderBy WHEN 't_pcdt' THEN [tdmisg140200].[t_pcdt] END,
     CASE @OrderBy WHEN 't_pcdt DESC' THEN [tdmisg140200].[t_pcdt] END DESC,
     CASE @OrderBy WHEN 't_podt' THEN [tdmisg140200].[t_podt] END,
     CASE @OrderBy WHEN 't_podt DESC' THEN [tdmisg140200].[t_podt] END DESC,
     CASE @OrderBy WHEN 't_prdt' THEN [tdmisg140200].[t_prdt] END,
     CASE @OrderBy WHEN 't_prdt DESC' THEN [tdmisg140200].[t_prdt] END DESC,
     CASE @OrderBy WHEN 't_psdt' THEN [tdmisg140200].[t_psdt] END,
     CASE @OrderBy WHEN 't_psdt DESC' THEN [tdmisg140200].[t_psdt] END DESC,
     CASE @OrderBy WHEN 't_dpct' THEN [tdmisg140200].[t_dpct] END,
     CASE @OrderBy WHEN 't_dpct DESC' THEN [tdmisg140200].[t_dpct] END DESC,
     CASE @OrderBy WHEN 't_dpwt' THEN [tdmisg140200].[t_dpwt] END,
     CASE @OrderBy WHEN 't_dpwt DESC' THEN [tdmisg140200].[t_dpwt] END DESC,
     CASE @OrderBy WHEN 't_idct' THEN [tdmisg140200].[t_idct] END,
     CASE @OrderBy WHEN 't_idct DESC' THEN [tdmisg140200].[t_idct] END DESC,
     CASE @OrderBy WHEN 't_idwt' THEN [tdmisg140200].[t_idwt] END,
     CASE @OrderBy WHEN 't_idwt DESC' THEN [tdmisg140200].[t_idwt] END DESC,
     CASE @OrderBy WHEN 't_popt' THEN [tdmisg140200].[t_popt] END,
     CASE @OrderBy WHEN 't_popt DESC' THEN [tdmisg140200].[t_popt] END DESC,
     CASE @OrderBy WHEN 't_posw' THEN [tdmisg140200].[t_posw] END,
     CASE @OrderBy WHEN 't_posw DESC' THEN [tdmisg140200].[t_posw] END DESC,
     CASE @OrderBy WHEN 't_powt' THEN [tdmisg140200].[t_powt] END,
     CASE @OrderBy WHEN 't_powt DESC' THEN [tdmisg140200].[t_powt] END DESC,
     CASE @OrderBy WHEN 't_pspt' THEN [tdmisg140200].[t_pspt] END,
     CASE @OrderBy WHEN 't_pspt DESC' THEN [tdmisg140200].[t_pspt] END DESC,
     CASE @OrderBy WHEN 't_posd' THEN [tdmisg140200].[t_posd] END,
     CASE @OrderBy WHEN 't_posd DESC' THEN [tdmisg140200].[t_posd] END DESC,
     CASE @OrderBy WHEN 't_upct' THEN [tdmisg140200].[t_upct] END,
     CASE @OrderBy WHEN 't_upct DESC' THEN [tdmisg140200].[t_upct] END DESC,
     CASE @OrderBy WHEN 't_bgdt' THEN [tdmisg140200].[t_bgdt] END,
     CASE @OrderBy WHEN 't_bgdt DESC' THEN [tdmisg140200].[t_bgdt] END DESC,
     CASE @OrderBy WHEN 't_vpdt' THEN [tdmisg140200].[t_vpdt] END,
     CASE @OrderBy WHEN 't_vpdt DESC' THEN [tdmisg140200].[t_vpdt] END DESC,
     CASE @OrderBy WHEN 't_vrdt' THEN [tdmisg140200].[t_vrdt] END,
     CASE @OrderBy WHEN 't_vrdt DESC' THEN [tdmisg140200].[t_vrdt] END DESC,
     CASE @OrderBy WHEN 't_upon' THEN [tdmisg140200].[t_upon] END,
     CASE @OrderBy WHEN 't_upon DESC' THEN [tdmisg140200].[t_upon] END DESC,
     CASE @OrderBy WHEN 't_adct' THEN [tdmisg140200].[t_adct] END,
     CASE @OrderBy WHEN 't_adct DESC' THEN [tdmisg140200].[t_adct] END DESC,
     CASE @OrderBy WHEN 't_piwt' THEN [tdmisg140200].[t_piwt] END,
     CASE @OrderBy WHEN 't_piwt DESC' THEN [tdmisg140200].[t_piwt] END DESC,
     CASE @OrderBy WHEN 't_poic' THEN [tdmisg140200].[t_poic] END,
     CASE @OrderBy WHEN 't_poic DESC' THEN [tdmisg140200].[t_poic] END DESC,
     CASE @OrderBy WHEN 't_pois' THEN [tdmisg140200].[t_pois] END,
     CASE @OrderBy WHEN 't_pois DESC' THEN [tdmisg140200].[t_pois] END DESC,
     CASE @OrderBy WHEN 't_numo' THEN [tdmisg140200].[t_numo] END,
     CASE @OrderBy WHEN 't_numo DESC' THEN [tdmisg140200].[t_numo] END DESC,
     CASE @OrderBy WHEN 't_numq' THEN [tdmisg140200].[t_numq] END,
     CASE @OrderBy WHEN 't_numq DESC' THEN [tdmisg140200].[t_numq] END DESC,
     CASE @OrderBy WHEN 't_numt' THEN [tdmisg140200].[t_numt] END,
     CASE @OrderBy WHEN 't_numt DESC' THEN [tdmisg140200].[t_numt] END DESC,
     CASE @OrderBy WHEN 't_numv' THEN [tdmisg140200].[t_numv] END,
     CASE @OrderBy WHEN 't_numv DESC' THEN [tdmisg140200].[t_numv] END DESC,
     CASE @OrderBy WHEN 't_nutc' THEN [tdmisg140200].[t_nutc] END,
     CASE @OrderBy WHEN 't_nutc DESC' THEN [tdmisg140200].[t_nutc] END DESC 

    SET @RecordCount = @@RowCount

  SELECT
    [tdmisg140200].*  
  FROM [tdmisg140200] 
      INNER JOIN #PageIndex
          ON [tdmisg140200].[t_pcod] = #PageIndex.t_pcod
          AND [tdmisg140200].[t_cprj] = #PageIndex.t_cprj
          AND [tdmisg140200].[t_uidn] = #PageIndex.t_uidn
  WHERE
        #PageIndex.IndexID > @StartRowIndex
        AND #PageIndex.IndexID < (@StartRowIndex + @MaximumRows + 1)
  ORDER BY
    #PageIndex.IndexID
  END
  GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spdmisg140SelectListFilteres]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spdmisg140SelectListFilteres]
GO
 
CREATE PROCEDURE [dbo].[spdmisg140SelectListFilteres]
  @LoginID NVarChar(8),
  @StartRowIndex int,
  @MaximumRows int,
  @OrderBy NVarChar(50),
  @RecordCount Int = 0 OUTPUT
  AS
  BEGIN
  DECLARE @LGSQL VarChar(8000)
  CREATE TABLE #PageIndex (
  IndexID INT IDENTITY (1, 1) NOT NULL
 ,t_pcod VarChar(9) NOT NULL
 ,t_cprj VarChar(9) NOT NULL
 ,t_uidn VarChar(25) NOT NULL
  )
  SET @LGSQL = 'INSERT INTO #PageIndex (' 
  SET @LGSQL = @LGSQL + 't_pcod'
  SET @LGSQL = @LGSQL + ', t_cprj'
  SET @LGSQL = @LGSQL + ', t_uidn'
  SET @LGSQL = @LGSQL + ')'
  SET @LGSQL = @LGSQL + ' SELECT '
  SET @LGSQL = @LGSQL + '[tdmisg140200].[t_pcod]'
  SET @LGSQL = @LGSQL + ', [tdmisg140200].[t_cprj]'
  SET @LGSQL = @LGSQL + ', [tdmisg140200].[t_uidn]'
  SET @LGSQL = @LGSQL + ' FROM [tdmisg140200] '
  SET @LGSQL = @LGSQL + '  WHERE 1 = 1 '
  SET @LGSQL = @LGSQL + '  ORDER BY '
  SET @LGSQL = @LGSQL + CASE @OrderBy
                        WHEN 't_pcod' THEN '[tdmisg140200].[t_pcod]'
                        WHEN 't_pcod DESC' THEN '[tdmisg140200].[t_pcod] DESC'
                        WHEN 't_cprj' THEN '[tdmisg140200].[t_cprj]'
                        WHEN 't_cprj DESC' THEN '[tdmisg140200].[t_cprj] DESC'
                        WHEN 't_uidn' THEN '[tdmisg140200].[t_uidn]'
                        WHEN 't_uidn DESC' THEN '[tdmisg140200].[t_uidn] DESC'
                        WHEN 't_revn' THEN '[tdmisg140200].[t_revn]'
                        WHEN 't_revn DESC' THEN '[tdmisg140200].[t_revn] DESC'
                        WHEN 't_docn' THEN '[tdmisg140200].[t_docn]'
                        WHEN 't_docn DESC' THEN '[tdmisg140200].[t_docn] DESC'
                        WHEN 't_dsca' THEN '[tdmisg140200].[t_dsca]'
                        WHEN 't_dsca DESC' THEN '[tdmisg140200].[t_dsca] DESC'
                        WHEN 't_aldo' THEN '[tdmisg140200].[t_aldo]'
                        WHEN 't_aldo DESC' THEN '[tdmisg140200].[t_aldo] DESC'
                        WHEN 't_alre' THEN '[tdmisg140200].[t_alre]'
                        WHEN 't_alre DESC' THEN '[tdmisg140200].[t_alre] DESC'
                        WHEN 't_cspa' THEN '[tdmisg140200].[t_cspa]'
                        WHEN 't_cspa DESC' THEN '[tdmisg140200].[t_cspa] DESC'
                        WHEN 't_type' THEN '[tdmisg140200].[t_type]'
                        WHEN 't_type DESC' THEN '[tdmisg140200].[t_type] DESC'
                        WHEN 't_resp' THEN '[tdmisg140200].[t_resp]'
                        WHEN 't_resp DESC' THEN '[tdmisg140200].[t_resp] DESC'
                        WHEN 't_size' THEN '[tdmisg140200].[t_size]'
                        WHEN 't_size DESC' THEN '[tdmisg140200].[t_size] DESC'
                        WHEN 't_orgn' THEN '[tdmisg140200].[t_orgn]'
                        WHEN 't_orgn DESC' THEN '[tdmisg140200].[t_orgn] DESC'
                        WHEN 't_subm' THEN '[tdmisg140200].[t_subm]'
                        WHEN 't_subm DESC' THEN '[tdmisg140200].[t_subm] DESC'
                        WHEN 't_intr' THEN '[tdmisg140200].[t_intr]'
                        WHEN 't_intr DESC' THEN '[tdmisg140200].[t_intr] DESC'
                        WHEN 't_prod' THEN '[tdmisg140200].[t_prod]'
                        WHEN 't_prod DESC' THEN '[tdmisg140200].[t_prod] DESC'
                        WHEN 't_erec' THEN '[tdmisg140200].[t_erec]'
                        WHEN 't_erec DESC' THEN '[tdmisg140200].[t_erec] DESC'
                        WHEN 't_info' THEN '[tdmisg140200].[t_info]'
                        WHEN 't_info DESC' THEN '[tdmisg140200].[t_info] DESC'
                        WHEN 't_remk' THEN '[tdmisg140200].[t_remk]'
                        WHEN 't_remk DESC' THEN '[tdmisg140200].[t_remk] DESC'
                        WHEN 't_soft' THEN '[tdmisg140200].[t_soft]'
                        WHEN 't_soft DESC' THEN '[tdmisg140200].[t_soft] DESC'
                        WHEN 't_drwn' THEN '[tdmisg140200].[t_drwn]'
                        WHEN 't_drwn DESC' THEN '[tdmisg140200].[t_drwn] DESC'
                        WHEN 't_chec' THEN '[tdmisg140200].[t_chec]'
                        WHEN 't_chec DESC' THEN '[tdmisg140200].[t_chec] DESC'
                        WHEN 't_engg' THEN '[tdmisg140200].[t_engg]'
                        WHEN 't_engg DESC' THEN '[tdmisg140200].[t_engg] DESC'
                        WHEN 't_dhrs' THEN '[tdmisg140200].[t_dhrs]'
                        WHEN 't_dhrs DESC' THEN '[tdmisg140200].[t_dhrs] DESC'
                        WHEN 't_chrs' THEN '[tdmisg140200].[t_chrs]'
                        WHEN 't_chrs DESC' THEN '[tdmisg140200].[t_chrs] DESC'
                        WHEN 't_ehrs' THEN '[tdmisg140200].[t_ehrs]'
                        WHEN 't_ehrs DESC' THEN '[tdmisg140200].[t_ehrs] DESC'
                        WHEN 't_lmhr' THEN '[tdmisg140200].[t_lmhr]'
                        WHEN 't_lmhr DESC' THEN '[tdmisg140200].[t_lmhr] DESC'
                        WHEN 't_acdt' THEN '[tdmisg140200].[t_acdt]'
                        WHEN 't_acdt DESC' THEN '[tdmisg140200].[t_acdt] DESC'
                        WHEN 't_upby' THEN '[tdmisg140200].[t_upby]'
                        WHEN 't_upby DESC' THEN '[tdmisg140200].[t_upby] DESC'
                        WHEN 't_updt' THEN '[tdmisg140200].[t_updt]'
                        WHEN 't_updt DESC' THEN '[tdmisg140200].[t_updt] DESC'
                        WHEN 't_dwgs' THEN '[tdmisg140200].[t_dwgs]'
                        WHEN 't_dwgs DESC' THEN '[tdmisg140200].[t_dwgs] DESC'
                        WHEN 't_genm' THEN '[tdmisg140200].[t_genm]'
                        WHEN 't_genm DESC' THEN '[tdmisg140200].[t_genm] DESC'
                        WHEN 't_inpt' THEN '[tdmisg140200].[t_inpt]'
                        WHEN 't_inpt DESC' THEN '[tdmisg140200].[t_inpt] DESC'
                        WHEN 't_seqn' THEN '[tdmisg140200].[t_seqn]'
                        WHEN 't_seqn DESC' THEN '[tdmisg140200].[t_seqn] DESC'
                        WHEN 't_bssd' THEN '[tdmisg140200].[t_bssd]'
                        WHEN 't_bssd DESC' THEN '[tdmisg140200].[t_bssd] DESC'
                        WHEN 't_bsfd' THEN '[tdmisg140200].[t_bsfd]'
                        WHEN 't_bsfd DESC' THEN '[tdmisg140200].[t_bsfd] DESC'
                        WHEN 't_rssd' THEN '[tdmisg140200].[t_rssd]'
                        WHEN 't_rssd DESC' THEN '[tdmisg140200].[t_rssd] DESC'
                        WHEN 't_rsfd' THEN '[tdmisg140200].[t_rsfd]'
                        WHEN 't_rsfd DESC' THEN '[tdmisg140200].[t_rsfd] DESC'
                        WHEN 't_lrrd' THEN '[tdmisg140200].[t_lrrd]'
                        WHEN 't_lrrd DESC' THEN '[tdmisg140200].[t_lrrd] DESC'
                        WHEN 't_rfsv' THEN '[tdmisg140200].[t_rfsv]'
                        WHEN 't_rfsv DESC' THEN '[tdmisg140200].[t_rfsv] DESC'
                        WHEN 't_irst' THEN '[tdmisg140200].[t_irst]'
                        WHEN 't_irst DESC' THEN '[tdmisg140200].[t_irst] DESC'
                        WHEN 't_dref' THEN '[tdmisg140200].[t_dref]'
                        WHEN 't_dref DESC' THEN '[tdmisg140200].[t_dref] DESC'
                        WHEN 't_chef' THEN '[tdmisg140200].[t_chef]'
                        WHEN 't_chef DESC' THEN '[tdmisg140200].[t_chef] DESC'
                        WHEN 't_leef' THEN '[tdmisg140200].[t_leef]'
                        WHEN 't_leef DESC' THEN '[tdmisg140200].[t_leef] DESC'
                        WHEN 't_lmef' THEN '[tdmisg140200].[t_lmef]'
                        WHEN 't_lmef DESC' THEN '[tdmisg140200].[t_lmef] DESC'
                        WHEN 't_drep' THEN '[tdmisg140200].[t_drep]'
                        WHEN 't_drep DESC' THEN '[tdmisg140200].[t_drep] DESC'
                        WHEN 't_oscd' THEN '[tdmisg140200].[t_oscd]'
                        WHEN 't_oscd DESC' THEN '[tdmisg140200].[t_oscd] DESC'
                        WHEN 't_Refcntd' THEN '[tdmisg140200].[t_Refcntd]'
                        WHEN 't_Refcntd DESC' THEN '[tdmisg140200].[t_Refcntd] DESC'
                        WHEN 't_Refcntu' THEN '[tdmisg140200].[t_Refcntu]'
                        WHEN 't_Refcntu DESC' THEN '[tdmisg140200].[t_Refcntu] DESC'
                        WHEN 't_pled' THEN '[tdmisg140200].[t_pled]'
                        WHEN 't_pled DESC' THEN '[tdmisg140200].[t_pled] DESC'
                        WHEN 't_appr' THEN '[tdmisg140200].[t_appr]'
                        WHEN 't_appr DESC' THEN '[tdmisg140200].[t_appr] DESC'
                        WHEN 't_rdat' THEN '[tdmisg140200].[t_rdat]'
                        WHEN 't_rdat DESC' THEN '[tdmisg140200].[t_rdat] DESC'
                        WHEN 't_selc' THEN '[tdmisg140200].[t_selc]'
                        WHEN 't_selc DESC' THEN '[tdmisg140200].[t_selc] DESC'
                        WHEN 't_acty' THEN '[tdmisg140200].[t_acty]'
                        WHEN 't_acty DESC' THEN '[tdmisg140200].[t_acty] DESC'
                        WHEN 't_fadt' THEN '[tdmisg140200].[t_fadt]'
                        WHEN 't_fadt DESC' THEN '[tdmisg140200].[t_fadt] DESC'
                        WHEN 't_iadt' THEN '[tdmisg140200].[t_iadt]'
                        WHEN 't_iadt DESC' THEN '[tdmisg140200].[t_iadt] DESC'
                        WHEN 't_iref' THEN '[tdmisg140200].[t_iref]'
                        WHEN 't_iref DESC' THEN '[tdmisg140200].[t_iref] DESC'
                        WHEN 't_itdt' THEN '[tdmisg140200].[t_itdt]'
                        WHEN 't_itdt DESC' THEN '[tdmisg140200].[t_itdt] DESC'
                        WHEN 't_padt' THEN '[tdmisg140200].[t_padt]'
                        WHEN 't_padt DESC' THEN '[tdmisg140200].[t_padt] DESC'
                        WHEN 't_pcdt' THEN '[tdmisg140200].[t_pcdt]'
                        WHEN 't_pcdt DESC' THEN '[tdmisg140200].[t_pcdt] DESC'
                        WHEN 't_podt' THEN '[tdmisg140200].[t_podt]'
                        WHEN 't_podt DESC' THEN '[tdmisg140200].[t_podt] DESC'
                        WHEN 't_prdt' THEN '[tdmisg140200].[t_prdt]'
                        WHEN 't_prdt DESC' THEN '[tdmisg140200].[t_prdt] DESC'
                        WHEN 't_psdt' THEN '[tdmisg140200].[t_psdt]'
                        WHEN 't_psdt DESC' THEN '[tdmisg140200].[t_psdt] DESC'
                        WHEN 't_dpct' THEN '[tdmisg140200].[t_dpct]'
                        WHEN 't_dpct DESC' THEN '[tdmisg140200].[t_dpct] DESC'
                        WHEN 't_dpwt' THEN '[tdmisg140200].[t_dpwt]'
                        WHEN 't_dpwt DESC' THEN '[tdmisg140200].[t_dpwt] DESC'
                        WHEN 't_idct' THEN '[tdmisg140200].[t_idct]'
                        WHEN 't_idct DESC' THEN '[tdmisg140200].[t_idct] DESC'
                        WHEN 't_idwt' THEN '[tdmisg140200].[t_idwt]'
                        WHEN 't_idwt DESC' THEN '[tdmisg140200].[t_idwt] DESC'
                        WHEN 't_popt' THEN '[tdmisg140200].[t_popt]'
                        WHEN 't_popt DESC' THEN '[tdmisg140200].[t_popt] DESC'
                        WHEN 't_posw' THEN '[tdmisg140200].[t_posw]'
                        WHEN 't_posw DESC' THEN '[tdmisg140200].[t_posw] DESC'
                        WHEN 't_powt' THEN '[tdmisg140200].[t_powt]'
                        WHEN 't_powt DESC' THEN '[tdmisg140200].[t_powt] DESC'
                        WHEN 't_pspt' THEN '[tdmisg140200].[t_pspt]'
                        WHEN 't_pspt DESC' THEN '[tdmisg140200].[t_pspt] DESC'
                        WHEN 't_posd' THEN '[tdmisg140200].[t_posd]'
                        WHEN 't_posd DESC' THEN '[tdmisg140200].[t_posd] DESC'
                        WHEN 't_upct' THEN '[tdmisg140200].[t_upct]'
                        WHEN 't_upct DESC' THEN '[tdmisg140200].[t_upct] DESC'
                        WHEN 't_bgdt' THEN '[tdmisg140200].[t_bgdt]'
                        WHEN 't_bgdt DESC' THEN '[tdmisg140200].[t_bgdt] DESC'
                        WHEN 't_vpdt' THEN '[tdmisg140200].[t_vpdt]'
                        WHEN 't_vpdt DESC' THEN '[tdmisg140200].[t_vpdt] DESC'
                        WHEN 't_vrdt' THEN '[tdmisg140200].[t_vrdt]'
                        WHEN 't_vrdt DESC' THEN '[tdmisg140200].[t_vrdt] DESC'
                        WHEN 't_upon' THEN '[tdmisg140200].[t_upon]'
                        WHEN 't_upon DESC' THEN '[tdmisg140200].[t_upon] DESC'
                        WHEN 't_adct' THEN '[tdmisg140200].[t_adct]'
                        WHEN 't_adct DESC' THEN '[tdmisg140200].[t_adct] DESC'
                        WHEN 't_piwt' THEN '[tdmisg140200].[t_piwt]'
                        WHEN 't_piwt DESC' THEN '[tdmisg140200].[t_piwt] DESC'
                        WHEN 't_poic' THEN '[tdmisg140200].[t_poic]'
                        WHEN 't_poic DESC' THEN '[tdmisg140200].[t_poic] DESC'
                        WHEN 't_pois' THEN '[tdmisg140200].[t_pois]'
                        WHEN 't_pois DESC' THEN '[tdmisg140200].[t_pois] DESC'
                        WHEN 't_numo' THEN '[tdmisg140200].[t_numo]'
                        WHEN 't_numo DESC' THEN '[tdmisg140200].[t_numo] DESC'
                        WHEN 't_numq' THEN '[tdmisg140200].[t_numq]'
                        WHEN 't_numq DESC' THEN '[tdmisg140200].[t_numq] DESC'
                        WHEN 't_numt' THEN '[tdmisg140200].[t_numt]'
                        WHEN 't_numt DESC' THEN '[tdmisg140200].[t_numt] DESC'
                        WHEN 't_numv' THEN '[tdmisg140200].[t_numv]'
                        WHEN 't_numv DESC' THEN '[tdmisg140200].[t_numv] DESC'
                        WHEN 't_nutc' THEN '[tdmisg140200].[t_nutc]'
                        WHEN 't_nutc DESC' THEN '[tdmisg140200].[t_nutc] DESC'
                        ELSE '[tdmisg140200].[t_pcod],[tdmisg140200].[t_cprj],[tdmisg140200].[t_uidn]'
                    END
  EXEC (@LGSQL)

  SET @RecordCount = @@RowCount

  SELECT
    [tdmisg140200].*  
  FROM [tdmisg140200] 
      INNER JOIN #PageIndex
          ON [tdmisg140200].[t_pcod] = #PageIndex.t_pcod
          AND [tdmisg140200].[t_cprj] = #PageIndex.t_cprj
          AND [tdmisg140200].[t_uidn] = #PageIndex.t_uidn
  WHERE
        #PageIndex.IndexID > @StartRowIndex
        AND #PageIndex.IndexID < (@StartRowIndex + @MaximumRows + 1)
  ORDER BY
    #PageIndex.IndexID
  END
  GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spdmisg140Insert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spdmisg140Insert]
GO
 
CREATE PROCEDURE [dbo].[spdmisg140Insert]
  @t_pcod VarChar(9),
  @t_cprj VarChar(9),
  @t_uidn VarChar(25),
  @t_revn VarChar(32),
  @t_docn VarChar(32),
  @t_dsca VarChar(100),
  @t_aldo VarChar(32),
  @t_alre VarChar(20),
  @t_cspa VarChar(8),
  @t_type VarChar(7),
  @t_resp VarChar(3),
  @t_size Int,
  @t_orgn VarChar(3),
  @t_subm Int,
  @t_intr Int,
  @t_prod Int,
  @t_erec Int,
  @t_info Int,
  @t_remk VarChar(100),
  @t_soft VarChar(50),
  @t_drwn VarChar(9),
  @t_chec VarChar(9),
  @t_engg VarChar(9),
  @t_dhrs Float,
  @t_chrs Float,
  @t_ehrs Float,
  @t_lmhr Float,
  @t_acdt DateTime,
  @t_upby VarChar(16),
  @t_updt DateTime,
  @t_dwgs Int,
  @t_genm VarChar(15),
  @t_inpt Int,
  @t_seqn Int,
  @t_bssd DateTime,
  @t_bsfd DateTime,
  @t_rssd DateTime,
  @t_rsfd DateTime,
  @t_lrrd DateTime,
  @t_rfsv VarChar(25),
  @t_irst VarChar(20),
  @t_dref Real,
  @t_chef Real,
  @t_leef Real,
  @t_lmef Real,
  @t_drep VarChar(9),
  @t_oscd Int,
  @t_Refcntd Int,
  @t_Refcntu Int,
  @t_pled VarChar(9),
  @t_appr Int,
  @t_rdat DateTime,
  @t_selc Int,
  @t_acty VarChar(30),
  @t_fadt DateTime,
  @t_iadt DateTime,
  @t_iref VarChar(150),
  @t_itdt DateTime,
  @t_padt DateTime,
  @t_pcdt DateTime,
  @t_podt DateTime,
  @t_prdt DateTime,
  @t_psdt DateTime,
  @t_dpct Int,
  @t_dpwt Float,
  @t_idct Int,
  @t_idwt Float,
  @t_popt Int,
  @t_posw Float,
  @t_powt Float,
  @t_pspt Int,
  @t_posd DateTime,
  @t_upct Int,
  @t_bgdt DateTime,
  @t_vpdt DateTime,
  @t_vrdt DateTime,
  @t_upon DateTime,
  @t_adct DateTime,
  @t_piwt Float,
  @t_poic Int,
  @t_pois DateTime,
  @t_numo Int,
  @t_numq Int,
  @t_numt Int,
  @t_numv Int,
  @t_nutc Int,
  @Return_t_pcod VarChar(9) = null OUTPUT, 
  @Return_t_cprj VarChar(9) = null OUTPUT, 
  @Return_t_uidn VarChar(25) = null OUTPUT 
  AS
  INSERT [tdmisg140200]
  (
   [t_pcod]
  ,[t_cprj]
  ,[t_uidn]
  ,[t_revn]
  ,[t_docn]
  ,[t_dsca]
  ,[t_aldo]
  ,[t_alre]
  ,[t_cspa]
  ,[t_type]
  ,[t_resp]
  ,[t_size]
  ,[t_orgn]
  ,[t_subm]
  ,[t_intr]
  ,[t_prod]
  ,[t_erec]
  ,[t_info]
  ,[t_remk]
  ,[t_soft]
  ,[t_drwn]
  ,[t_chec]
  ,[t_engg]
  ,[t_dhrs]
  ,[t_chrs]
  ,[t_ehrs]
  ,[t_lmhr]
  ,[t_acdt]
  ,[t_upby]
  ,[t_updt]
  ,[t_dwgs]
  ,[t_genm]
  ,[t_inpt]
  ,[t_seqn]
  ,[t_bssd]
  ,[t_bsfd]
  ,[t_rssd]
  ,[t_rsfd]
  ,[t_lrrd]
  ,[t_rfsv]
  ,[t_irst]
  ,[t_dref]
  ,[t_chef]
  ,[t_leef]
  ,[t_lmef]
  ,[t_drep]
  ,[t_oscd]
  ,[t_Refcntd]
  ,[t_Refcntu]
  ,[t_pled]
  ,[t_appr]
  ,[t_rdat]
  ,[t_selc]
  ,[t_acty]
  ,[t_fadt]
  ,[t_iadt]
  ,[t_iref]
  ,[t_itdt]
  ,[t_padt]
  ,[t_pcdt]
  ,[t_podt]
  ,[t_prdt]
  ,[t_psdt]
  ,[t_dpct]
  ,[t_dpwt]
  ,[t_idct]
  ,[t_idwt]
  ,[t_popt]
  ,[t_posw]
  ,[t_powt]
  ,[t_pspt]
  ,[t_posd]
  ,[t_upct]
  ,[t_bgdt]
  ,[t_vpdt]
  ,[t_vrdt]
  ,[t_upon]
  ,[t_adct]
  ,[t_piwt]
  ,[t_poic]
  ,[t_pois]
  ,[t_numo]
  ,[t_numq]
  ,[t_numt]
  ,[t_numv]
  ,[t_nutc]
  )
  VALUES
  (
   UPPER(@t_pcod)
  ,UPPER(@t_cprj)
  ,UPPER(@t_uidn)
  ,@t_revn
  ,@t_docn
  ,@t_dsca
  ,@t_aldo
  ,@t_alre
  ,@t_cspa
  ,@t_type
  ,@t_resp
  ,@t_size
  ,@t_orgn
  ,@t_subm
  ,@t_intr
  ,@t_prod
  ,@t_erec
  ,@t_info
  ,@t_remk
  ,@t_soft
  ,@t_drwn
  ,@t_chec
  ,@t_engg
  ,@t_dhrs
  ,@t_chrs
  ,@t_ehrs
  ,@t_lmhr
  ,@t_acdt
  ,@t_upby
  ,@t_updt
  ,@t_dwgs
  ,@t_genm
  ,@t_inpt
  ,@t_seqn
  ,@t_bssd
  ,@t_bsfd
  ,@t_rssd
  ,@t_rsfd
  ,@t_lrrd
  ,@t_rfsv
  ,@t_irst
  ,@t_dref
  ,@t_chef
  ,@t_leef
  ,@t_lmef
  ,@t_drep
  ,@t_oscd
  ,@t_Refcntd
  ,@t_Refcntu
  ,@t_pled
  ,@t_appr
  ,@t_rdat
  ,@t_selc
  ,@t_acty
  ,@t_fadt
  ,@t_iadt
  ,@t_iref
  ,@t_itdt
  ,@t_padt
  ,@t_pcdt
  ,@t_podt
  ,@t_prdt
  ,@t_psdt
  ,@t_dpct
  ,@t_dpwt
  ,@t_idct
  ,@t_idwt
  ,@t_popt
  ,@t_posw
  ,@t_powt
  ,@t_pspt
  ,@t_posd
  ,@t_upct
  ,@t_bgdt
  ,@t_vpdt
  ,@t_vrdt
  ,@t_upon
  ,@t_adct
  ,@t_piwt
  ,@t_poic
  ,@t_pois
  ,@t_numo
  ,@t_numq
  ,@t_numt
  ,@t_numv
  ,@t_nutc
  )
  SET @Return_t_pcod = @t_pcod
  SET @Return_t_cprj = @t_cprj
  SET @Return_t_uidn = @t_uidn
  GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spdmisg140Update]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spdmisg140Update]
GO
 
CREATE PROCEDURE [dbo].[spdmisg140Update]
  @Original_t_pcod VarChar(9), 
  @Original_t_cprj VarChar(9), 
  @Original_t_uidn VarChar(25), 
  @t_pcod VarChar(9),
  @t_cprj VarChar(9),
  @t_uidn VarChar(25),
  @t_revn VarChar(32),
  @t_docn VarChar(32),
  @t_dsca VarChar(100),
  @t_aldo VarChar(32),
  @t_alre VarChar(20),
  @t_cspa VarChar(8),
  @t_type VarChar(7),
  @t_resp VarChar(3),
  @t_size Int,
  @t_orgn VarChar(3),
  @t_subm Int,
  @t_intr Int,
  @t_prod Int,
  @t_erec Int,
  @t_info Int,
  @t_remk VarChar(100),
  @t_soft VarChar(50),
  @t_drwn VarChar(9),
  @t_chec VarChar(9),
  @t_engg VarChar(9),
  @t_dhrs Float,
  @t_chrs Float,
  @t_ehrs Float,
  @t_lmhr Float,
  @t_acdt DateTime,
  @t_upby VarChar(16),
  @t_updt DateTime,
  @t_dwgs Int,
  @t_genm VarChar(15),
  @t_inpt Int,
  @t_seqn Int,
  @t_bssd DateTime,
  @t_bsfd DateTime,
  @t_rssd DateTime,
  @t_rsfd DateTime,
  @t_lrrd DateTime,
  @t_rfsv VarChar(25),
  @t_irst VarChar(20),
  @t_dref Real,
  @t_chef Real,
  @t_leef Real,
  @t_lmef Real,
  @t_drep VarChar(9),
  @t_oscd Int,
  @t_Refcntd Int,
  @t_Refcntu Int,
  @t_pled VarChar(9),
  @t_appr Int,
  @t_rdat DateTime,
  @t_selc Int,
  @t_acty VarChar(30),
  @t_fadt DateTime,
  @t_iadt DateTime,
  @t_iref VarChar(150),
  @t_itdt DateTime,
  @t_padt DateTime,
  @t_pcdt DateTime,
  @t_podt DateTime,
  @t_prdt DateTime,
  @t_psdt DateTime,
  @t_dpct Int,
  @t_dpwt Float,
  @t_idct Int,
  @t_idwt Float,
  @t_popt Int,
  @t_posw Float,
  @t_powt Float,
  @t_pspt Int,
  @t_posd DateTime,
  @t_upct Int,
  @t_bgdt DateTime,
  @t_vpdt DateTime,
  @t_vrdt DateTime,
  @t_upon DateTime,
  @t_adct DateTime,
  @t_piwt Float,
  @t_poic Int,
  @t_pois DateTime,
  @t_numo Int,
  @t_numq Int,
  @t_numt Int,
  @t_numv Int,
  @t_nutc Int,
  @RowCount int = null OUTPUT
  AS
  UPDATE [tdmisg140200] SET 
   [t_pcod] = @t_pcod
  ,[t_cprj] = @t_cprj
  ,[t_uidn] = @t_uidn
  ,[t_revn] = @t_revn
  ,[t_docn] = @t_docn
  ,[t_dsca] = @t_dsca
  ,[t_aldo] = @t_aldo
  ,[t_alre] = @t_alre
  ,[t_cspa] = @t_cspa
  ,[t_type] = @t_type
  ,[t_resp] = @t_resp
  ,[t_size] = @t_size
  ,[t_orgn] = @t_orgn
  ,[t_subm] = @t_subm
  ,[t_intr] = @t_intr
  ,[t_prod] = @t_prod
  ,[t_erec] = @t_erec
  ,[t_info] = @t_info
  ,[t_remk] = @t_remk
  ,[t_soft] = @t_soft
  ,[t_drwn] = @t_drwn
  ,[t_chec] = @t_chec
  ,[t_engg] = @t_engg
  ,[t_dhrs] = @t_dhrs
  ,[t_chrs] = @t_chrs
  ,[t_ehrs] = @t_ehrs
  ,[t_lmhr] = @t_lmhr
  ,[t_acdt] = @t_acdt
  ,[t_upby] = @t_upby
  ,[t_updt] = @t_updt
  ,[t_dwgs] = @t_dwgs
  ,[t_genm] = @t_genm
  ,[t_inpt] = @t_inpt
  ,[t_seqn] = @t_seqn
  ,[t_bssd] = @t_bssd
  ,[t_bsfd] = @t_bsfd
  ,[t_rssd] = @t_rssd
  ,[t_rsfd] = @t_rsfd
  ,[t_lrrd] = @t_lrrd
  ,[t_rfsv] = @t_rfsv
  ,[t_irst] = @t_irst
  ,[t_dref] = @t_dref
  ,[t_chef] = @t_chef
  ,[t_leef] = @t_leef
  ,[t_lmef] = @t_lmef
  ,[t_drep] = @t_drep
  ,[t_oscd] = @t_oscd
  ,[t_Refcntd] = @t_Refcntd
  ,[t_Refcntu] = @t_Refcntu
  ,[t_pled] = @t_pled
  ,[t_appr] = @t_appr
  ,[t_rdat] = @t_rdat
  ,[t_selc] = @t_selc
  ,[t_acty] = @t_acty
  ,[t_fadt] = @t_fadt
  ,[t_iadt] = @t_iadt
  ,[t_iref] = @t_iref
  ,[t_itdt] = @t_itdt
  ,[t_padt] = @t_padt
  ,[t_pcdt] = @t_pcdt
  ,[t_podt] = @t_podt
  ,[t_prdt] = @t_prdt
  ,[t_psdt] = @t_psdt
  ,[t_dpct] = @t_dpct
  ,[t_dpwt] = @t_dpwt
  ,[t_idct] = @t_idct
  ,[t_idwt] = @t_idwt
  ,[t_popt] = @t_popt
  ,[t_posw] = @t_posw
  ,[t_powt] = @t_powt
  ,[t_pspt] = @t_pspt
  ,[t_posd] = @t_posd
  ,[t_upct] = @t_upct
  ,[t_bgdt] = @t_bgdt
  ,[t_vpdt] = @t_vpdt
  ,[t_vrdt] = @t_vrdt
  ,[t_upon] = @t_upon
  ,[t_adct] = @t_adct
  ,[t_piwt] = @t_piwt
  ,[t_poic] = @t_poic
  ,[t_pois] = @t_pois
  ,[t_numo] = @t_numo
  ,[t_numq] = @t_numq
  ,[t_numt] = @t_numt
  ,[t_numv] = @t_numv
  ,[t_nutc] = @t_nutc
  WHERE
  [t_pcod] = @Original_t_pcod
  AND [t_cprj] = @Original_t_cprj
  AND [t_uidn] = @Original_t_uidn
  SET @RowCount = @@RowCount
  GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spdmisg140Delete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spdmisg140Delete]
GO
 
CREATE PROCEDURE [dbo].[spdmisg140Delete]
  @Original_t_pcod VarChar(9),
  @Original_t_cprj VarChar(9),
  @Original_t_uidn VarChar(25),
  @RowCount int = null OUTPUT
  AS
  DELETE [tdmisg140200]
  WHERE
  [tdmisg140200].[t_pcod] = @Original_t_pcod
  AND [tdmisg140200].[t_cprj] = @Original_t_cprj
  AND [tdmisg140200].[t_uidn] = @Original_t_uidn
  SET @RowCount = @@RowCount
  GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sptdpur400SelectList]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sptdpur400SelectList]
GO
 
CREATE PROCEDURE [dbo].[sptdpur400SelectList]
  @LoginID NVarChar(8),
  @OrderBy NVarChar(50),
  @RecordCount Int = 0 OUTPUT
  AS
  SELECT
    [ttdpur400200].*  
  FROM [ttdpur400200] 
  WHERE 1 = 1  
  ORDER BY
     CASE @OrderBy WHEN 't_orno' THEN [ttdpur400200].[t_orno] END,
     CASE @OrderBy WHEN 't_orno DESC' THEN [ttdpur400200].[t_orno] END DESC,
     CASE @OrderBy WHEN 't_otbp' THEN [ttdpur400200].[t_otbp] END,
     CASE @OrderBy WHEN 't_otbp DESC' THEN [ttdpur400200].[t_otbp] END DESC,
     CASE @OrderBy WHEN 't_otad' THEN [ttdpur400200].[t_otad] END,
     CASE @OrderBy WHEN 't_otad DESC' THEN [ttdpur400200].[t_otad] END DESC,
     CASE @OrderBy WHEN 't_otcn' THEN [ttdpur400200].[t_otcn] END,
     CASE @OrderBy WHEN 't_otcn DESC' THEN [ttdpur400200].[t_otcn] END DESC,
     CASE @OrderBy WHEN 't_sfbp' THEN [ttdpur400200].[t_sfbp] END,
     CASE @OrderBy WHEN 't_sfbp DESC' THEN [ttdpur400200].[t_sfbp] END DESC,
     CASE @OrderBy WHEN 't_sfad' THEN [ttdpur400200].[t_sfad] END,
     CASE @OrderBy WHEN 't_sfad DESC' THEN [ttdpur400200].[t_sfad] END DESC,
     CASE @OrderBy WHEN 't_sfcn' THEN [ttdpur400200].[t_sfcn] END,
     CASE @OrderBy WHEN 't_sfcn DESC' THEN [ttdpur400200].[t_sfcn] END DESC,
     CASE @OrderBy WHEN 't_ifbp' THEN [ttdpur400200].[t_ifbp] END,
     CASE @OrderBy WHEN 't_ifbp DESC' THEN [ttdpur400200].[t_ifbp] END DESC,
     CASE @OrderBy WHEN 't_ifad' THEN [ttdpur400200].[t_ifad] END,
     CASE @OrderBy WHEN 't_ifad DESC' THEN [ttdpur400200].[t_ifad] END DESC,
     CASE @OrderBy WHEN 't_ifcn' THEN [ttdpur400200].[t_ifcn] END,
     CASE @OrderBy WHEN 't_ifcn DESC' THEN [ttdpur400200].[t_ifcn] END DESC,
     CASE @OrderBy WHEN 't_ptbp' THEN [ttdpur400200].[t_ptbp] END,
     CASE @OrderBy WHEN 't_ptbp DESC' THEN [ttdpur400200].[t_ptbp] END DESC,
     CASE @OrderBy WHEN 't_ptad' THEN [ttdpur400200].[t_ptad] END,
     CASE @OrderBy WHEN 't_ptad DESC' THEN [ttdpur400200].[t_ptad] END DESC,
     CASE @OrderBy WHEN 't_ptcn' THEN [ttdpur400200].[t_ptcn] END,
     CASE @OrderBy WHEN 't_ptcn DESC' THEN [ttdpur400200].[t_ptcn] END DESC,
     CASE @OrderBy WHEN 't_corg' THEN [ttdpur400200].[t_corg] END,
     CASE @OrderBy WHEN 't_corg DESC' THEN [ttdpur400200].[t_corg] END DESC,
     CASE @OrderBy WHEN 't_cotp' THEN [ttdpur400200].[t_cotp] END,
     CASE @OrderBy WHEN 't_cotp DESC' THEN [ttdpur400200].[t_cotp] END DESC,
     CASE @OrderBy WHEN 't_ragr' THEN [ttdpur400200].[t_ragr] END,
     CASE @OrderBy WHEN 't_ragr DESC' THEN [ttdpur400200].[t_ragr] END DESC,
     CASE @OrderBy WHEN 't_cpay' THEN [ttdpur400200].[t_cpay] END,
     CASE @OrderBy WHEN 't_cpay DESC' THEN [ttdpur400200].[t_cpay] END DESC,
     CASE @OrderBy WHEN 't_odat' THEN [ttdpur400200].[t_odat] END,
     CASE @OrderBy WHEN 't_odat DESC' THEN [ttdpur400200].[t_odat] END DESC,
     CASE @OrderBy WHEN 't_odis' THEN [ttdpur400200].[t_odis] END,
     CASE @OrderBy WHEN 't_odis DESC' THEN [ttdpur400200].[t_odis] END DESC,
     CASE @OrderBy WHEN 't_ccur' THEN [ttdpur400200].[t_ccur] END,
     CASE @OrderBy WHEN 't_ccur DESC' THEN [ttdpur400200].[t_ccur] END DESC,
     CASE @OrderBy WHEN 't_mcfr' THEN [ttdpur400200].[t_mcfr] END,
     CASE @OrderBy WHEN 't_mcfr DESC' THEN [ttdpur400200].[t_mcfr] END DESC,
     CASE @OrderBy WHEN 't_ratp_1' THEN [ttdpur400200].[t_ratp_1] END,
     CASE @OrderBy WHEN 't_ratp_1 DESC' THEN [ttdpur400200].[t_ratp_1] END DESC,
     CASE @OrderBy WHEN 't_ratp_2' THEN [ttdpur400200].[t_ratp_2] END,
     CASE @OrderBy WHEN 't_ratp_2 DESC' THEN [ttdpur400200].[t_ratp_2] END DESC,
     CASE @OrderBy WHEN 't_ratp_3' THEN [ttdpur400200].[t_ratp_3] END,
     CASE @OrderBy WHEN 't_ratp_3 DESC' THEN [ttdpur400200].[t_ratp_3] END DESC,
     CASE @OrderBy WHEN 't_ratf_1' THEN [ttdpur400200].[t_ratf_1] END,
     CASE @OrderBy WHEN 't_ratf_1 DESC' THEN [ttdpur400200].[t_ratf_1] END DESC,
     CASE @OrderBy WHEN 't_ratf_2' THEN [ttdpur400200].[t_ratf_2] END,
     CASE @OrderBy WHEN 't_ratf_2 DESC' THEN [ttdpur400200].[t_ratf_2] END DESC,
     CASE @OrderBy WHEN 't_ratf_3' THEN [ttdpur400200].[t_ratf_3] END,
     CASE @OrderBy WHEN 't_ratf_3 DESC' THEN [ttdpur400200].[t_ratf_3] END DESC,
     CASE @OrderBy WHEN 't_ratd' THEN [ttdpur400200].[t_ratd] END,
     CASE @OrderBy WHEN 't_ratd DESC' THEN [ttdpur400200].[t_ratd] END DESC,
     CASE @OrderBy WHEN 't_ratt' THEN [ttdpur400200].[t_ratt] END,
     CASE @OrderBy WHEN 't_ratt DESC' THEN [ttdpur400200].[t_ratt] END DESC,
     CASE @OrderBy WHEN 't_raur' THEN [ttdpur400200].[t_raur] END,
     CASE @OrderBy WHEN 't_raur DESC' THEN [ttdpur400200].[t_raur] END DESC,
     CASE @OrderBy WHEN 't_cwar' THEN [ttdpur400200].[t_cwar] END,
     CASE @OrderBy WHEN 't_cwar DESC' THEN [ttdpur400200].[t_cwar] END DESC,
     CASE @OrderBy WHEN 't_cadr' THEN [ttdpur400200].[t_cadr] END,
     CASE @OrderBy WHEN 't_cadr DESC' THEN [ttdpur400200].[t_cadr] END DESC,
     CASE @OrderBy WHEN 't_ccon' THEN [ttdpur400200].[t_ccon] END,
     CASE @OrderBy WHEN 't_ccon DESC' THEN [ttdpur400200].[t_ccon] END DESC,
     CASE @OrderBy WHEN 't_plnr' THEN [ttdpur400200].[t_plnr] END,
     CASE @OrderBy WHEN 't_plnr DESC' THEN [ttdpur400200].[t_plnr] END DESC,
     CASE @OrderBy WHEN 't_ccrs' THEN [ttdpur400200].[t_ccrs] END,
     CASE @OrderBy WHEN 't_ccrs DESC' THEN [ttdpur400200].[t_ccrs] END DESC,
     CASE @OrderBy WHEN 't_cfrw' THEN [ttdpur400200].[t_cfrw] END,
     CASE @OrderBy WHEN 't_cfrw DESC' THEN [ttdpur400200].[t_cfrw] END DESC,
     CASE @OrderBy WHEN 't_cplp' THEN [ttdpur400200].[t_cplp] END,
     CASE @OrderBy WHEN 't_cplp DESC' THEN [ttdpur400200].[t_cplp] END DESC,
     CASE @OrderBy WHEN 't_bppr' THEN [ttdpur400200].[t_bppr] END,
     CASE @OrderBy WHEN 't_bppr DESC' THEN [ttdpur400200].[t_bppr] END DESC,
     CASE @OrderBy WHEN 't_bptx' THEN [ttdpur400200].[t_bptx] END,
     CASE @OrderBy WHEN 't_bptx DESC' THEN [ttdpur400200].[t_bptx] END DESC,
     CASE @OrderBy WHEN 't_cdec' THEN [ttdpur400200].[t_cdec] END,
     CASE @OrderBy WHEN 't_cdec DESC' THEN [ttdpur400200].[t_cdec] END DESC,
     CASE @OrderBy WHEN 't_ptpa' THEN [ttdpur400200].[t_ptpa] END,
     CASE @OrderBy WHEN 't_ptpa DESC' THEN [ttdpur400200].[t_ptpa] END DESC,
     CASE @OrderBy WHEN 't_ddat' THEN [ttdpur400200].[t_ddat] END,
     CASE @OrderBy WHEN 't_ddat DESC' THEN [ttdpur400200].[t_ddat] END DESC,
     CASE @OrderBy WHEN 't_ddtc' THEN [ttdpur400200].[t_ddtc] END,
     CASE @OrderBy WHEN 't_ddtc DESC' THEN [ttdpur400200].[t_ddtc] END DESC,
     CASE @OrderBy WHEN 't_cbrn' THEN [ttdpur400200].[t_cbrn] END,
     CASE @OrderBy WHEN 't_cbrn DESC' THEN [ttdpur400200].[t_cbrn] END DESC,
     CASE @OrderBy WHEN 't_creg' THEN [ttdpur400200].[t_creg] END,
     CASE @OrderBy WHEN 't_creg DESC' THEN [ttdpur400200].[t_creg] END DESC,
     CASE @OrderBy WHEN 't_refa' THEN [ttdpur400200].[t_refa] END,
     CASE @OrderBy WHEN 't_refa DESC' THEN [ttdpur400200].[t_refa] END DESC,
     CASE @OrderBy WHEN 't_refb' THEN [ttdpur400200].[t_refb] END,
     CASE @OrderBy WHEN 't_refb DESC' THEN [ttdpur400200].[t_refb] END DESC,
     CASE @OrderBy WHEN 't_prno' THEN [ttdpur400200].[t_prno] END,
     CASE @OrderBy WHEN 't_prno DESC' THEN [ttdpur400200].[t_prno] END DESC,
     CASE @OrderBy WHEN 't_ctrj' THEN [ttdpur400200].[t_ctrj] END,
     CASE @OrderBy WHEN 't_ctrj DESC' THEN [ttdpur400200].[t_ctrj] END DESC,
     CASE @OrderBy WHEN 't_cofc' THEN [ttdpur400200].[t_cofc] END,
     CASE @OrderBy WHEN 't_cofc DESC' THEN [ttdpur400200].[t_cofc] END DESC,
     CASE @OrderBy WHEN 't_fdpt' THEN [ttdpur400200].[t_fdpt] END,
     CASE @OrderBy WHEN 't_fdpt DESC' THEN [ttdpur400200].[t_fdpt] END DESC,
     CASE @OrderBy WHEN 't_odty' THEN [ttdpur400200].[t_odty] END,
     CASE @OrderBy WHEN 't_odty DESC' THEN [ttdpur400200].[t_odty] END DESC,
     CASE @OrderBy WHEN 't_odno' THEN [ttdpur400200].[t_odno] END,
     CASE @OrderBy WHEN 't_odno DESC' THEN [ttdpur400200].[t_odno] END DESC,
     CASE @OrderBy WHEN 't_retr' THEN [ttdpur400200].[t_retr] END,
     CASE @OrderBy WHEN 't_retr DESC' THEN [ttdpur400200].[t_retr] END DESC,
     CASE @OrderBy WHEN 't_sorn' THEN [ttdpur400200].[t_sorn] END,
     CASE @OrderBy WHEN 't_sorn DESC' THEN [ttdpur400200].[t_sorn] END DESC,
     CASE @OrderBy WHEN 't_cosn' THEN [ttdpur400200].[t_cosn] END,
     CASE @OrderBy WHEN 't_cosn DESC' THEN [ttdpur400200].[t_cosn] END DESC,
     CASE @OrderBy WHEN 't_akcd' THEN [ttdpur400200].[t_akcd] END,
     CASE @OrderBy WHEN 't_akcd DESC' THEN [ttdpur400200].[t_akcd] END DESC,
     CASE @OrderBy WHEN 't_crcd' THEN [ttdpur400200].[t_crcd] END,
     CASE @OrderBy WHEN 't_crcd DESC' THEN [ttdpur400200].[t_crcd] END DESC,
     CASE @OrderBy WHEN 't_ctcd' THEN [ttdpur400200].[t_ctcd] END,
     CASE @OrderBy WHEN 't_ctcd DESC' THEN [ttdpur400200].[t_ctcd] END DESC,
     CASE @OrderBy WHEN 't_egen' THEN [ttdpur400200].[t_egen] END,
     CASE @OrderBy WHEN 't_egen DESC' THEN [ttdpur400200].[t_egen] END DESC,
     CASE @OrderBy WHEN 't_sbim' THEN [ttdpur400200].[t_sbim] END,
     CASE @OrderBy WHEN 't_sbim DESC' THEN [ttdpur400200].[t_sbim] END DESC,
     CASE @OrderBy WHEN 't_paft' THEN [ttdpur400200].[t_paft] END,
     CASE @OrderBy WHEN 't_paft DESC' THEN [ttdpur400200].[t_paft] END DESC,
     CASE @OrderBy WHEN 't_sbmt' THEN [ttdpur400200].[t_sbmt] END,
     CASE @OrderBy WHEN 't_sbmt DESC' THEN [ttdpur400200].[t_sbmt] END DESC,
     CASE @OrderBy WHEN 't_bpcl' THEN [ttdpur400200].[t_bpcl] END,
     CASE @OrderBy WHEN 't_bpcl DESC' THEN [ttdpur400200].[t_bpcl] END DESC,
     CASE @OrderBy WHEN 't_oamt' THEN [ttdpur400200].[t_oamt] END,
     CASE @OrderBy WHEN 't_oamt DESC' THEN [ttdpur400200].[t_oamt] END DESC,
     CASE @OrderBy WHEN 't_comm' THEN [ttdpur400200].[t_comm] END,
     CASE @OrderBy WHEN 't_comm DESC' THEN [ttdpur400200].[t_comm] END DESC,
     CASE @OrderBy WHEN 't_iebp' THEN [ttdpur400200].[t_iebp] END,
     CASE @OrderBy WHEN 't_iebp DESC' THEN [ttdpur400200].[t_iebp] END DESC,
     CASE @OrderBy WHEN 't_iafc' THEN [ttdpur400200].[t_iafc] END,
     CASE @OrderBy WHEN 't_iafc DESC' THEN [ttdpur400200].[t_iafc] END DESC,
     CASE @OrderBy WHEN 't_lccl' THEN [ttdpur400200].[t_lccl] END,
     CASE @OrderBy WHEN 't_lccl DESC' THEN [ttdpur400200].[t_lccl] END DESC,
     CASE @OrderBy WHEN 't_hdst' THEN [ttdpur400200].[t_hdst] END,
     CASE @OrderBy WHEN 't_hdst DESC' THEN [ttdpur400200].[t_hdst] END DESC,
     CASE @OrderBy WHEN 't_hisp' THEN [ttdpur400200].[t_hisp] END,
     CASE @OrderBy WHEN 't_hisp DESC' THEN [ttdpur400200].[t_hisp] END DESC,
     CASE @OrderBy WHEN 't_hism' THEN [ttdpur400200].[t_hism] END,
     CASE @OrderBy WHEN 't_hism DESC' THEN [ttdpur400200].[t_hism] END DESC,
     CASE @OrderBy WHEN 't_ccty' THEN [ttdpur400200].[t_ccty] END,
     CASE @OrderBy WHEN 't_ccty DESC' THEN [ttdpur400200].[t_ccty] END DESC,
     CASE @OrderBy WHEN 't_cvyn' THEN [ttdpur400200].[t_cvyn] END,
     CASE @OrderBy WHEN 't_cvyn DESC' THEN [ttdpur400200].[t_cvyn] END DESC,
     CASE @OrderBy WHEN 't_bpid_l' THEN [ttdpur400200].[t_bpid_l] END,
     CASE @OrderBy WHEN 't_bpid_l DESC' THEN [ttdpur400200].[t_bpid_l] END DESC,
     CASE @OrderBy WHEN 't_impo_l' THEN [ttdpur400200].[t_impo_l] END,
     CASE @OrderBy WHEN 't_impo_l DESC' THEN [ttdpur400200].[t_impo_l] END DESC,
     CASE @OrderBy WHEN 't_ccty_l' THEN [ttdpur400200].[t_ccty_l] END,
     CASE @OrderBy WHEN 't_ccty_l DESC' THEN [ttdpur400200].[t_ccty_l] END DESC,
     CASE @OrderBy WHEN 't_cvat_l' THEN [ttdpur400200].[t_cvat_l] END,
     CASE @OrderBy WHEN 't_cvat_l DESC' THEN [ttdpur400200].[t_cvat_l] END DESC,
     CASE @OrderBy WHEN 't_exmt_l' THEN [ttdpur400200].[t_exmt_l] END,
     CASE @OrderBy WHEN 't_exmt_l DESC' THEN [ttdpur400200].[t_exmt_l] END DESC,
     CASE @OrderBy WHEN 't_catg_l' THEN [ttdpur400200].[t_catg_l] END,
     CASE @OrderBy WHEN 't_catg_l DESC' THEN [ttdpur400200].[t_catg_l] END DESC,
     CASE @OrderBy WHEN 't_ceno_l' THEN [ttdpur400200].[t_ceno_l] END,
     CASE @OrderBy WHEN 't_ceno_l DESC' THEN [ttdpur400200].[t_ceno_l] END DESC,
     CASE @OrderBy WHEN 't_bdbt_l' THEN [ttdpur400200].[t_bdbt_l] END,
     CASE @OrderBy WHEN 't_bdbt_l DESC' THEN [ttdpur400200].[t_bdbt_l] END DESC,
     CASE @OrderBy WHEN 't_bnoo_l' THEN [ttdpur400200].[t_bnoo_l] END,
     CASE @OrderBy WHEN 't_bnoo_l DESC' THEN [ttdpur400200].[t_bnoo_l] END DESC,
     CASE @OrderBy WHEN 't_txta' THEN [ttdpur400200].[t_txta] END,
     CASE @OrderBy WHEN 't_txta DESC' THEN [ttdpur400200].[t_txta] END DESC,
     CASE @OrderBy WHEN 't_txtb' THEN [ttdpur400200].[t_txtb] END,
     CASE @OrderBy WHEN 't_txtb DESC' THEN [ttdpur400200].[t_txtb] END DESC,
     CASE @OrderBy WHEN 't_cdf_adat' THEN [ttdpur400200].[t_cdf_adat] END,
     CASE @OrderBy WHEN 't_cdf_adat DESC' THEN [ttdpur400200].[t_cdf_adat] END DESC,
     CASE @OrderBy WHEN 't_cdf_alvl' THEN [ttdpur400200].[t_cdf_alvl] END,
     CASE @OrderBy WHEN 't_cdf_alvl DESC' THEN [ttdpur400200].[t_cdf_alvl] END DESC,
     CASE @OrderBy WHEN 't_cdf_onlr' THEN [ttdpur400200].[t_cdf_onlr] END,
     CASE @OrderBy WHEN 't_cdf_onlr DESC' THEN [ttdpur400200].[t_cdf_onlr] END DESC,
     CASE @OrderBy WHEN 't_cdf_prty' THEN [ttdpur400200].[t_cdf_prty] END,
     CASE @OrderBy WHEN 't_cdf_prty DESC' THEN [ttdpur400200].[t_cdf_prty] END DESC,
     CASE @OrderBy WHEN 't_cdf_qap' THEN [ttdpur400200].[t_cdf_qap] END,
     CASE @OrderBy WHEN 't_cdf_qap DESC' THEN [ttdpur400200].[t_cdf_qap] END DESC,
     CASE @OrderBy WHEN 't_cdf_qdat' THEN [ttdpur400200].[t_cdf_qdat] END,
     CASE @OrderBy WHEN 't_cdf_qdat DESC' THEN [ttdpur400200].[t_cdf_qdat] END DESC,
     CASE @OrderBy WHEN 't_cdf_refb' THEN [ttdpur400200].[t_cdf_refb] END,
     CASE @OrderBy WHEN 't_cdf_refb DESC' THEN [ttdpur400200].[t_cdf_refb] END DESC,
     CASE @OrderBy WHEN 't_Refcntd' THEN [ttdpur400200].[t_Refcntd] END,
     CASE @OrderBy WHEN 't_Refcntd DESC' THEN [ttdpur400200].[t_Refcntd] END DESC,
     CASE @OrderBy WHEN 't_Refcntu' THEN [ttdpur400200].[t_Refcntu] END,
     CASE @OrderBy WHEN 't_Refcntu DESC' THEN [ttdpur400200].[t_Refcntu] END DESC,
     CASE @OrderBy WHEN 't_cdf_reas' THEN [ttdpur400200].[t_cdf_reas] END,
     CASE @OrderBy WHEN 't_cdf_reas DESC' THEN [ttdpur400200].[t_cdf_reas] END DESC,
     CASE @OrderBy WHEN 't_cdf_qapa' THEN [ttdpur400200].[t_cdf_qapa] END,
     CASE @OrderBy WHEN 't_cdf_qapa DESC' THEN [ttdpur400200].[t_cdf_qapa] END DESC,
     CASE @OrderBy WHEN 't_atfr_l' THEN [ttdpur400200].[t_atfr_l] END,
     CASE @OrderBy WHEN 't_atfr_l DESC' THEN [ttdpur400200].[t_atfr_l] END DESC 
  SET @RecordCount = @@RowCount
  GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sptdpur400AutoCompleteList]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sptdpur400AutoCompleteList]
GO
 
CREATE PROCEDURE [dbo].[sptdpur400AutoCompleteList]
  @LoginID NVarChar(8),
  @Prefix NVarChar(250),
  @Records Int,
  @ByCode Int 
  AS 
  BEGIN 
  DECLARE @Prefix1 VarChar(260)
  SET @Prefix1 = LOWER(@Prefix) + '%'
  DECLARE @LGSQL VarChar(8000)
  SET @LGSQL = 'SELECT TOP (' + STR(@Records) + ') ' 
  SET @LGSQL = @LGSQL + ' [ttdpur400200].[t_refa]' 
  SET @LGSQL = @LGSQL + ',[ttdpur400200].[t_orno]' 
  SET @LGSQL = @LGSQL + ' FROM [ttdpur400200] ' 
  SET @LGSQL = @LGSQL + ' WHERE 1 = 1 ' 
  SET @LGSQL = @LGSQL + ' AND (LOWER(ISNULL([ttdpur400200].[t_orno],'''')) LIKE ''' + @Prefix1 + ''''
  SET @LGSQL = @LGSQL + ' OR LOWER(ISNULL([ttdpur400200].[t_refa],'''')) LIKE ''' + @Prefix1 + ''''
  SET @LGSQL = @LGSQL + ')' 
  
  EXEC (@LGSQL)
  END 
  GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sptdpur400SelectByID]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sptdpur400SelectByID]
GO
 
CREATE PROCEDURE [dbo].[sptdpur400SelectByID]
  @LoginID NVarChar(8),
  @t_orno VarChar(9) 
  AS
  SELECT
    [ttdpur400200].*  
  FROM [ttdpur400200] 
  WHERE
  [ttdpur400200].[t_orno] = @t_orno
  GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sptdpur400SelectListSearch]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sptdpur400SelectListSearch]
GO
 
CREATE PROCEDURE [dbo].[sptdpur400SelectListSearch]
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
 ,t_orno VarChar(9) NOT NULL
  )
  INSERT INTO #PageIndex (t_orno)
  SELECT [ttdpur400200].[t_orno] FROM [ttdpur400200]
 WHERE  
   ( 
         LOWER(ISNULL([ttdpur400200].[t_orno],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ttdpur400200].[t_otbp],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ttdpur400200].[t_otad],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ttdpur400200].[t_otcn],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ttdpur400200].[t_sfbp],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ttdpur400200].[t_sfad],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ttdpur400200].[t_sfcn],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ttdpur400200].[t_ifbp],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ttdpur400200].[t_ifad],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ttdpur400200].[t_ifcn],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ttdpur400200].[t_ptbp],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ttdpur400200].[t_ptad],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ttdpur400200].[t_ptcn],'')) LIKE @KeyWord1
     OR STR(ISNULL([ttdpur400200].[t_corg], 0)) LIKE @KeyWord1
     OR LOWER(ISNULL([ttdpur400200].[t_cotp],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ttdpur400200].[t_ragr],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ttdpur400200].[t_cpay],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ttdpur400200].[t_ccur],'')) LIKE @KeyWord1
     OR STR(ISNULL([ttdpur400200].[t_mcfr], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttdpur400200].[t_ratp_1], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttdpur400200].[t_ratp_2], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttdpur400200].[t_ratp_3], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttdpur400200].[t_ratf_1], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttdpur400200].[t_ratf_2], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttdpur400200].[t_ratf_3], 0)) LIKE @KeyWord1
     OR LOWER(ISNULL([ttdpur400200].[t_ratt],'')) LIKE @KeyWord1
     OR STR(ISNULL([ttdpur400200].[t_raur], 0)) LIKE @KeyWord1
     OR LOWER(ISNULL([ttdpur400200].[t_cwar],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ttdpur400200].[t_cadr],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ttdpur400200].[t_ccon],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ttdpur400200].[t_plnr],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ttdpur400200].[t_ccrs],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ttdpur400200].[t_cfrw],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ttdpur400200].[t_cplp],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ttdpur400200].[t_bppr],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ttdpur400200].[t_bptx],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ttdpur400200].[t_cdec],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ttdpur400200].[t_ptpa],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ttdpur400200].[t_cbrn],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ttdpur400200].[t_creg],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ttdpur400200].[t_refa],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ttdpur400200].[t_refb],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ttdpur400200].[t_prno],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ttdpur400200].[t_ctrj],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ttdpur400200].[t_cofc],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ttdpur400200].[t_fdpt],'')) LIKE @KeyWord1
     OR STR(ISNULL([ttdpur400200].[t_odty], 0)) LIKE @KeyWord1
     OR LOWER(ISNULL([ttdpur400200].[t_odno],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ttdpur400200].[t_retr],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ttdpur400200].[t_sorn],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ttdpur400200].[t_cosn],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ttdpur400200].[t_akcd],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ttdpur400200].[t_crcd],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ttdpur400200].[t_ctcd],'')) LIKE @KeyWord1
     OR STR(ISNULL([ttdpur400200].[t_egen], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttdpur400200].[t_sbim], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttdpur400200].[t_paft], 0)) LIKE @KeyWord1
     OR LOWER(ISNULL([ttdpur400200].[t_sbmt],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ttdpur400200].[t_bpcl],'')) LIKE @KeyWord1
     OR STR(ISNULL([ttdpur400200].[t_oamt], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttdpur400200].[t_comm], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttdpur400200].[t_iebp], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttdpur400200].[t_iafc], 0)) LIKE @KeyWord1
     OR LOWER(ISNULL([ttdpur400200].[t_lccl],'')) LIKE @KeyWord1
     OR STR(ISNULL([ttdpur400200].[t_hdst], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttdpur400200].[t_hisp], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttdpur400200].[t_hism], 0)) LIKE @KeyWord1
     OR LOWER(ISNULL([ttdpur400200].[t_ccty],'')) LIKE @KeyWord1
     OR STR(ISNULL([ttdpur400200].[t_cvyn], 0)) LIKE @KeyWord1
     OR LOWER(ISNULL([ttdpur400200].[t_bpid_l],'')) LIKE @KeyWord1
     OR STR(ISNULL([ttdpur400200].[t_impo_l], 0)) LIKE @KeyWord1
     OR LOWER(ISNULL([ttdpur400200].[t_ccty_l],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ttdpur400200].[t_cvat_l],'')) LIKE @KeyWord1
     OR STR(ISNULL([ttdpur400200].[t_exmt_l], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttdpur400200].[t_catg_l], 0)) LIKE @KeyWord1
     OR LOWER(ISNULL([ttdpur400200].[t_ceno_l],'')) LIKE @KeyWord1
     OR STR(ISNULL([ttdpur400200].[t_bdbt_l], 0)) LIKE @KeyWord1
     OR LOWER(ISNULL([ttdpur400200].[t_bnoo_l],'')) LIKE @KeyWord1
     OR STR(ISNULL([ttdpur400200].[t_txta], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttdpur400200].[t_txtb], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttdpur400200].[t_cdf_alvl], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttdpur400200].[t_cdf_onlr], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttdpur400200].[t_cdf_prty], 0)) LIKE @KeyWord1
     OR LOWER(ISNULL([ttdpur400200].[t_cdf_qap],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ttdpur400200].[t_cdf_refb],'')) LIKE @KeyWord1
     OR STR(ISNULL([ttdpur400200].[t_Refcntd], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttdpur400200].[t_Refcntu], 0)) LIKE @KeyWord1
     OR LOWER(ISNULL([ttdpur400200].[t_cdf_reas],'')) LIKE @KeyWord1
     OR STR(ISNULL([ttdpur400200].[t_cdf_qapa], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttdpur400200].[t_atfr_l], 0)) LIKE @KeyWord1
   ) 
  ORDER BY
     CASE @OrderBy WHEN 't_orno' THEN [ttdpur400200].[t_orno] END,
     CASE @OrderBy WHEN 't_orno DESC' THEN [ttdpur400200].[t_orno] END DESC,
     CASE @OrderBy WHEN 't_otbp' THEN [ttdpur400200].[t_otbp] END,
     CASE @OrderBy WHEN 't_otbp DESC' THEN [ttdpur400200].[t_otbp] END DESC,
     CASE @OrderBy WHEN 't_otad' THEN [ttdpur400200].[t_otad] END,
     CASE @OrderBy WHEN 't_otad DESC' THEN [ttdpur400200].[t_otad] END DESC,
     CASE @OrderBy WHEN 't_otcn' THEN [ttdpur400200].[t_otcn] END,
     CASE @OrderBy WHEN 't_otcn DESC' THEN [ttdpur400200].[t_otcn] END DESC,
     CASE @OrderBy WHEN 't_sfbp' THEN [ttdpur400200].[t_sfbp] END,
     CASE @OrderBy WHEN 't_sfbp DESC' THEN [ttdpur400200].[t_sfbp] END DESC,
     CASE @OrderBy WHEN 't_sfad' THEN [ttdpur400200].[t_sfad] END,
     CASE @OrderBy WHEN 't_sfad DESC' THEN [ttdpur400200].[t_sfad] END DESC,
     CASE @OrderBy WHEN 't_sfcn' THEN [ttdpur400200].[t_sfcn] END,
     CASE @OrderBy WHEN 't_sfcn DESC' THEN [ttdpur400200].[t_sfcn] END DESC,
     CASE @OrderBy WHEN 't_ifbp' THEN [ttdpur400200].[t_ifbp] END,
     CASE @OrderBy WHEN 't_ifbp DESC' THEN [ttdpur400200].[t_ifbp] END DESC,
     CASE @OrderBy WHEN 't_ifad' THEN [ttdpur400200].[t_ifad] END,
     CASE @OrderBy WHEN 't_ifad DESC' THEN [ttdpur400200].[t_ifad] END DESC,
     CASE @OrderBy WHEN 't_ifcn' THEN [ttdpur400200].[t_ifcn] END,
     CASE @OrderBy WHEN 't_ifcn DESC' THEN [ttdpur400200].[t_ifcn] END DESC,
     CASE @OrderBy WHEN 't_ptbp' THEN [ttdpur400200].[t_ptbp] END,
     CASE @OrderBy WHEN 't_ptbp DESC' THEN [ttdpur400200].[t_ptbp] END DESC,
     CASE @OrderBy WHEN 't_ptad' THEN [ttdpur400200].[t_ptad] END,
     CASE @OrderBy WHEN 't_ptad DESC' THEN [ttdpur400200].[t_ptad] END DESC,
     CASE @OrderBy WHEN 't_ptcn' THEN [ttdpur400200].[t_ptcn] END,
     CASE @OrderBy WHEN 't_ptcn DESC' THEN [ttdpur400200].[t_ptcn] END DESC,
     CASE @OrderBy WHEN 't_corg' THEN [ttdpur400200].[t_corg] END,
     CASE @OrderBy WHEN 't_corg DESC' THEN [ttdpur400200].[t_corg] END DESC,
     CASE @OrderBy WHEN 't_cotp' THEN [ttdpur400200].[t_cotp] END,
     CASE @OrderBy WHEN 't_cotp DESC' THEN [ttdpur400200].[t_cotp] END DESC,
     CASE @OrderBy WHEN 't_ragr' THEN [ttdpur400200].[t_ragr] END,
     CASE @OrderBy WHEN 't_ragr DESC' THEN [ttdpur400200].[t_ragr] END DESC,
     CASE @OrderBy WHEN 't_cpay' THEN [ttdpur400200].[t_cpay] END,
     CASE @OrderBy WHEN 't_cpay DESC' THEN [ttdpur400200].[t_cpay] END DESC,
     CASE @OrderBy WHEN 't_odat' THEN [ttdpur400200].[t_odat] END,
     CASE @OrderBy WHEN 't_odat DESC' THEN [ttdpur400200].[t_odat] END DESC,
     CASE @OrderBy WHEN 't_odis' THEN [ttdpur400200].[t_odis] END,
     CASE @OrderBy WHEN 't_odis DESC' THEN [ttdpur400200].[t_odis] END DESC,
     CASE @OrderBy WHEN 't_ccur' THEN [ttdpur400200].[t_ccur] END,
     CASE @OrderBy WHEN 't_ccur DESC' THEN [ttdpur400200].[t_ccur] END DESC,
     CASE @OrderBy WHEN 't_mcfr' THEN [ttdpur400200].[t_mcfr] END,
     CASE @OrderBy WHEN 't_mcfr DESC' THEN [ttdpur400200].[t_mcfr] END DESC,
     CASE @OrderBy WHEN 't_ratp_1' THEN [ttdpur400200].[t_ratp_1] END,
     CASE @OrderBy WHEN 't_ratp_1 DESC' THEN [ttdpur400200].[t_ratp_1] END DESC,
     CASE @OrderBy WHEN 't_ratp_2' THEN [ttdpur400200].[t_ratp_2] END,
     CASE @OrderBy WHEN 't_ratp_2 DESC' THEN [ttdpur400200].[t_ratp_2] END DESC,
     CASE @OrderBy WHEN 't_ratp_3' THEN [ttdpur400200].[t_ratp_3] END,
     CASE @OrderBy WHEN 't_ratp_3 DESC' THEN [ttdpur400200].[t_ratp_3] END DESC,
     CASE @OrderBy WHEN 't_ratf_1' THEN [ttdpur400200].[t_ratf_1] END,
     CASE @OrderBy WHEN 't_ratf_1 DESC' THEN [ttdpur400200].[t_ratf_1] END DESC,
     CASE @OrderBy WHEN 't_ratf_2' THEN [ttdpur400200].[t_ratf_2] END,
     CASE @OrderBy WHEN 't_ratf_2 DESC' THEN [ttdpur400200].[t_ratf_2] END DESC,
     CASE @OrderBy WHEN 't_ratf_3' THEN [ttdpur400200].[t_ratf_3] END,
     CASE @OrderBy WHEN 't_ratf_3 DESC' THEN [ttdpur400200].[t_ratf_3] END DESC,
     CASE @OrderBy WHEN 't_ratd' THEN [ttdpur400200].[t_ratd] END,
     CASE @OrderBy WHEN 't_ratd DESC' THEN [ttdpur400200].[t_ratd] END DESC,
     CASE @OrderBy WHEN 't_ratt' THEN [ttdpur400200].[t_ratt] END,
     CASE @OrderBy WHEN 't_ratt DESC' THEN [ttdpur400200].[t_ratt] END DESC,
     CASE @OrderBy WHEN 't_raur' THEN [ttdpur400200].[t_raur] END,
     CASE @OrderBy WHEN 't_raur DESC' THEN [ttdpur400200].[t_raur] END DESC,
     CASE @OrderBy WHEN 't_cwar' THEN [ttdpur400200].[t_cwar] END,
     CASE @OrderBy WHEN 't_cwar DESC' THEN [ttdpur400200].[t_cwar] END DESC,
     CASE @OrderBy WHEN 't_cadr' THEN [ttdpur400200].[t_cadr] END,
     CASE @OrderBy WHEN 't_cadr DESC' THEN [ttdpur400200].[t_cadr] END DESC,
     CASE @OrderBy WHEN 't_ccon' THEN [ttdpur400200].[t_ccon] END,
     CASE @OrderBy WHEN 't_ccon DESC' THEN [ttdpur400200].[t_ccon] END DESC,
     CASE @OrderBy WHEN 't_plnr' THEN [ttdpur400200].[t_plnr] END,
     CASE @OrderBy WHEN 't_plnr DESC' THEN [ttdpur400200].[t_plnr] END DESC,
     CASE @OrderBy WHEN 't_ccrs' THEN [ttdpur400200].[t_ccrs] END,
     CASE @OrderBy WHEN 't_ccrs DESC' THEN [ttdpur400200].[t_ccrs] END DESC,
     CASE @OrderBy WHEN 't_cfrw' THEN [ttdpur400200].[t_cfrw] END,
     CASE @OrderBy WHEN 't_cfrw DESC' THEN [ttdpur400200].[t_cfrw] END DESC,
     CASE @OrderBy WHEN 't_cplp' THEN [ttdpur400200].[t_cplp] END,
     CASE @OrderBy WHEN 't_cplp DESC' THEN [ttdpur400200].[t_cplp] END DESC,
     CASE @OrderBy WHEN 't_bppr' THEN [ttdpur400200].[t_bppr] END,
     CASE @OrderBy WHEN 't_bppr DESC' THEN [ttdpur400200].[t_bppr] END DESC,
     CASE @OrderBy WHEN 't_bptx' THEN [ttdpur400200].[t_bptx] END,
     CASE @OrderBy WHEN 't_bptx DESC' THEN [ttdpur400200].[t_bptx] END DESC,
     CASE @OrderBy WHEN 't_cdec' THEN [ttdpur400200].[t_cdec] END,
     CASE @OrderBy WHEN 't_cdec DESC' THEN [ttdpur400200].[t_cdec] END DESC,
     CASE @OrderBy WHEN 't_ptpa' THEN [ttdpur400200].[t_ptpa] END,
     CASE @OrderBy WHEN 't_ptpa DESC' THEN [ttdpur400200].[t_ptpa] END DESC,
     CASE @OrderBy WHEN 't_ddat' THEN [ttdpur400200].[t_ddat] END,
     CASE @OrderBy WHEN 't_ddat DESC' THEN [ttdpur400200].[t_ddat] END DESC,
     CASE @OrderBy WHEN 't_ddtc' THEN [ttdpur400200].[t_ddtc] END,
     CASE @OrderBy WHEN 't_ddtc DESC' THEN [ttdpur400200].[t_ddtc] END DESC,
     CASE @OrderBy WHEN 't_cbrn' THEN [ttdpur400200].[t_cbrn] END,
     CASE @OrderBy WHEN 't_cbrn DESC' THEN [ttdpur400200].[t_cbrn] END DESC,
     CASE @OrderBy WHEN 't_creg' THEN [ttdpur400200].[t_creg] END,
     CASE @OrderBy WHEN 't_creg DESC' THEN [ttdpur400200].[t_creg] END DESC,
     CASE @OrderBy WHEN 't_refa' THEN [ttdpur400200].[t_refa] END,
     CASE @OrderBy WHEN 't_refa DESC' THEN [ttdpur400200].[t_refa] END DESC,
     CASE @OrderBy WHEN 't_refb' THEN [ttdpur400200].[t_refb] END,
     CASE @OrderBy WHEN 't_refb DESC' THEN [ttdpur400200].[t_refb] END DESC,
     CASE @OrderBy WHEN 't_prno' THEN [ttdpur400200].[t_prno] END,
     CASE @OrderBy WHEN 't_prno DESC' THEN [ttdpur400200].[t_prno] END DESC,
     CASE @OrderBy WHEN 't_ctrj' THEN [ttdpur400200].[t_ctrj] END,
     CASE @OrderBy WHEN 't_ctrj DESC' THEN [ttdpur400200].[t_ctrj] END DESC,
     CASE @OrderBy WHEN 't_cofc' THEN [ttdpur400200].[t_cofc] END,
     CASE @OrderBy WHEN 't_cofc DESC' THEN [ttdpur400200].[t_cofc] END DESC,
     CASE @OrderBy WHEN 't_fdpt' THEN [ttdpur400200].[t_fdpt] END,
     CASE @OrderBy WHEN 't_fdpt DESC' THEN [ttdpur400200].[t_fdpt] END DESC,
     CASE @OrderBy WHEN 't_odty' THEN [ttdpur400200].[t_odty] END,
     CASE @OrderBy WHEN 't_odty DESC' THEN [ttdpur400200].[t_odty] END DESC,
     CASE @OrderBy WHEN 't_odno' THEN [ttdpur400200].[t_odno] END,
     CASE @OrderBy WHEN 't_odno DESC' THEN [ttdpur400200].[t_odno] END DESC,
     CASE @OrderBy WHEN 't_retr' THEN [ttdpur400200].[t_retr] END,
     CASE @OrderBy WHEN 't_retr DESC' THEN [ttdpur400200].[t_retr] END DESC,
     CASE @OrderBy WHEN 't_sorn' THEN [ttdpur400200].[t_sorn] END,
     CASE @OrderBy WHEN 't_sorn DESC' THEN [ttdpur400200].[t_sorn] END DESC,
     CASE @OrderBy WHEN 't_cosn' THEN [ttdpur400200].[t_cosn] END,
     CASE @OrderBy WHEN 't_cosn DESC' THEN [ttdpur400200].[t_cosn] END DESC,
     CASE @OrderBy WHEN 't_akcd' THEN [ttdpur400200].[t_akcd] END,
     CASE @OrderBy WHEN 't_akcd DESC' THEN [ttdpur400200].[t_akcd] END DESC,
     CASE @OrderBy WHEN 't_crcd' THEN [ttdpur400200].[t_crcd] END,
     CASE @OrderBy WHEN 't_crcd DESC' THEN [ttdpur400200].[t_crcd] END DESC,
     CASE @OrderBy WHEN 't_ctcd' THEN [ttdpur400200].[t_ctcd] END,
     CASE @OrderBy WHEN 't_ctcd DESC' THEN [ttdpur400200].[t_ctcd] END DESC,
     CASE @OrderBy WHEN 't_egen' THEN [ttdpur400200].[t_egen] END,
     CASE @OrderBy WHEN 't_egen DESC' THEN [ttdpur400200].[t_egen] END DESC,
     CASE @OrderBy WHEN 't_sbim' THEN [ttdpur400200].[t_sbim] END,
     CASE @OrderBy WHEN 't_sbim DESC' THEN [ttdpur400200].[t_sbim] END DESC,
     CASE @OrderBy WHEN 't_paft' THEN [ttdpur400200].[t_paft] END,
     CASE @OrderBy WHEN 't_paft DESC' THEN [ttdpur400200].[t_paft] END DESC,
     CASE @OrderBy WHEN 't_sbmt' THEN [ttdpur400200].[t_sbmt] END,
     CASE @OrderBy WHEN 't_sbmt DESC' THEN [ttdpur400200].[t_sbmt] END DESC,
     CASE @OrderBy WHEN 't_bpcl' THEN [ttdpur400200].[t_bpcl] END,
     CASE @OrderBy WHEN 't_bpcl DESC' THEN [ttdpur400200].[t_bpcl] END DESC,
     CASE @OrderBy WHEN 't_oamt' THEN [ttdpur400200].[t_oamt] END,
     CASE @OrderBy WHEN 't_oamt DESC' THEN [ttdpur400200].[t_oamt] END DESC,
     CASE @OrderBy WHEN 't_comm' THEN [ttdpur400200].[t_comm] END,
     CASE @OrderBy WHEN 't_comm DESC' THEN [ttdpur400200].[t_comm] END DESC,
     CASE @OrderBy WHEN 't_iebp' THEN [ttdpur400200].[t_iebp] END,
     CASE @OrderBy WHEN 't_iebp DESC' THEN [ttdpur400200].[t_iebp] END DESC,
     CASE @OrderBy WHEN 't_iafc' THEN [ttdpur400200].[t_iafc] END,
     CASE @OrderBy WHEN 't_iafc DESC' THEN [ttdpur400200].[t_iafc] END DESC,
     CASE @OrderBy WHEN 't_lccl' THEN [ttdpur400200].[t_lccl] END,
     CASE @OrderBy WHEN 't_lccl DESC' THEN [ttdpur400200].[t_lccl] END DESC,
     CASE @OrderBy WHEN 't_hdst' THEN [ttdpur400200].[t_hdst] END,
     CASE @OrderBy WHEN 't_hdst DESC' THEN [ttdpur400200].[t_hdst] END DESC,
     CASE @OrderBy WHEN 't_hisp' THEN [ttdpur400200].[t_hisp] END,
     CASE @OrderBy WHEN 't_hisp DESC' THEN [ttdpur400200].[t_hisp] END DESC,
     CASE @OrderBy WHEN 't_hism' THEN [ttdpur400200].[t_hism] END,
     CASE @OrderBy WHEN 't_hism DESC' THEN [ttdpur400200].[t_hism] END DESC,
     CASE @OrderBy WHEN 't_ccty' THEN [ttdpur400200].[t_ccty] END,
     CASE @OrderBy WHEN 't_ccty DESC' THEN [ttdpur400200].[t_ccty] END DESC,
     CASE @OrderBy WHEN 't_cvyn' THEN [ttdpur400200].[t_cvyn] END,
     CASE @OrderBy WHEN 't_cvyn DESC' THEN [ttdpur400200].[t_cvyn] END DESC,
     CASE @OrderBy WHEN 't_bpid_l' THEN [ttdpur400200].[t_bpid_l] END,
     CASE @OrderBy WHEN 't_bpid_l DESC' THEN [ttdpur400200].[t_bpid_l] END DESC,
     CASE @OrderBy WHEN 't_impo_l' THEN [ttdpur400200].[t_impo_l] END,
     CASE @OrderBy WHEN 't_impo_l DESC' THEN [ttdpur400200].[t_impo_l] END DESC,
     CASE @OrderBy WHEN 't_ccty_l' THEN [ttdpur400200].[t_ccty_l] END,
     CASE @OrderBy WHEN 't_ccty_l DESC' THEN [ttdpur400200].[t_ccty_l] END DESC,
     CASE @OrderBy WHEN 't_cvat_l' THEN [ttdpur400200].[t_cvat_l] END,
     CASE @OrderBy WHEN 't_cvat_l DESC' THEN [ttdpur400200].[t_cvat_l] END DESC,
     CASE @OrderBy WHEN 't_exmt_l' THEN [ttdpur400200].[t_exmt_l] END,
     CASE @OrderBy WHEN 't_exmt_l DESC' THEN [ttdpur400200].[t_exmt_l] END DESC,
     CASE @OrderBy WHEN 't_catg_l' THEN [ttdpur400200].[t_catg_l] END,
     CASE @OrderBy WHEN 't_catg_l DESC' THEN [ttdpur400200].[t_catg_l] END DESC,
     CASE @OrderBy WHEN 't_ceno_l' THEN [ttdpur400200].[t_ceno_l] END,
     CASE @OrderBy WHEN 't_ceno_l DESC' THEN [ttdpur400200].[t_ceno_l] END DESC,
     CASE @OrderBy WHEN 't_bdbt_l' THEN [ttdpur400200].[t_bdbt_l] END,
     CASE @OrderBy WHEN 't_bdbt_l DESC' THEN [ttdpur400200].[t_bdbt_l] END DESC,
     CASE @OrderBy WHEN 't_bnoo_l' THEN [ttdpur400200].[t_bnoo_l] END,
     CASE @OrderBy WHEN 't_bnoo_l DESC' THEN [ttdpur400200].[t_bnoo_l] END DESC,
     CASE @OrderBy WHEN 't_txta' THEN [ttdpur400200].[t_txta] END,
     CASE @OrderBy WHEN 't_txta DESC' THEN [ttdpur400200].[t_txta] END DESC,
     CASE @OrderBy WHEN 't_txtb' THEN [ttdpur400200].[t_txtb] END,
     CASE @OrderBy WHEN 't_txtb DESC' THEN [ttdpur400200].[t_txtb] END DESC,
     CASE @OrderBy WHEN 't_cdf_adat' THEN [ttdpur400200].[t_cdf_adat] END,
     CASE @OrderBy WHEN 't_cdf_adat DESC' THEN [ttdpur400200].[t_cdf_adat] END DESC,
     CASE @OrderBy WHEN 't_cdf_alvl' THEN [ttdpur400200].[t_cdf_alvl] END,
     CASE @OrderBy WHEN 't_cdf_alvl DESC' THEN [ttdpur400200].[t_cdf_alvl] END DESC,
     CASE @OrderBy WHEN 't_cdf_onlr' THEN [ttdpur400200].[t_cdf_onlr] END,
     CASE @OrderBy WHEN 't_cdf_onlr DESC' THEN [ttdpur400200].[t_cdf_onlr] END DESC,
     CASE @OrderBy WHEN 't_cdf_prty' THEN [ttdpur400200].[t_cdf_prty] END,
     CASE @OrderBy WHEN 't_cdf_prty DESC' THEN [ttdpur400200].[t_cdf_prty] END DESC,
     CASE @OrderBy WHEN 't_cdf_qap' THEN [ttdpur400200].[t_cdf_qap] END,
     CASE @OrderBy WHEN 't_cdf_qap DESC' THEN [ttdpur400200].[t_cdf_qap] END DESC,
     CASE @OrderBy WHEN 't_cdf_qdat' THEN [ttdpur400200].[t_cdf_qdat] END,
     CASE @OrderBy WHEN 't_cdf_qdat DESC' THEN [ttdpur400200].[t_cdf_qdat] END DESC,
     CASE @OrderBy WHEN 't_cdf_refb' THEN [ttdpur400200].[t_cdf_refb] END,
     CASE @OrderBy WHEN 't_cdf_refb DESC' THEN [ttdpur400200].[t_cdf_refb] END DESC,
     CASE @OrderBy WHEN 't_Refcntd' THEN [ttdpur400200].[t_Refcntd] END,
     CASE @OrderBy WHEN 't_Refcntd DESC' THEN [ttdpur400200].[t_Refcntd] END DESC,
     CASE @OrderBy WHEN 't_Refcntu' THEN [ttdpur400200].[t_Refcntu] END,
     CASE @OrderBy WHEN 't_Refcntu DESC' THEN [ttdpur400200].[t_Refcntu] END DESC,
     CASE @OrderBy WHEN 't_cdf_reas' THEN [ttdpur400200].[t_cdf_reas] END,
     CASE @OrderBy WHEN 't_cdf_reas DESC' THEN [ttdpur400200].[t_cdf_reas] END DESC,
     CASE @OrderBy WHEN 't_cdf_qapa' THEN [ttdpur400200].[t_cdf_qapa] END,
     CASE @OrderBy WHEN 't_cdf_qapa DESC' THEN [ttdpur400200].[t_cdf_qapa] END DESC,
     CASE @OrderBy WHEN 't_atfr_l' THEN [ttdpur400200].[t_atfr_l] END,
     CASE @OrderBy WHEN 't_atfr_l DESC' THEN [ttdpur400200].[t_atfr_l] END DESC 

    SET @RecordCount = @@RowCount

  SELECT
    [ttdpur400200].*  
  FROM [ttdpur400200] 
      INNER JOIN #PageIndex
          ON [ttdpur400200].[t_orno] = #PageIndex.t_orno
  WHERE
        #PageIndex.IndexID > @StartRowIndex
        AND #PageIndex.IndexID < (@StartRowIndex + @MaximumRows + 1)
  ORDER BY
    #PageIndex.IndexID
  END
  GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sptdpur400SelectListFilteres]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sptdpur400SelectListFilteres]
GO
 
CREATE PROCEDURE [dbo].[sptdpur400SelectListFilteres]
  @LoginID NVarChar(8),
  @StartRowIndex int,
  @MaximumRows int,
  @OrderBy NVarChar(50),
  @RecordCount Int = 0 OUTPUT
  AS
  BEGIN
  DECLARE @LGSQL VarChar(8000)
  CREATE TABLE #PageIndex (
  IndexID INT IDENTITY (1, 1) NOT NULL
 ,t_orno VarChar(9) NOT NULL
  )
  SET @LGSQL = 'INSERT INTO #PageIndex (' 
  SET @LGSQL = @LGSQL + 't_orno'
  SET @LGSQL = @LGSQL + ')'
  SET @LGSQL = @LGSQL + ' SELECT '
  SET @LGSQL = @LGSQL + '[ttdpur400200].[t_orno]'
  SET @LGSQL = @LGSQL + ' FROM [ttdpur400200] '
  SET @LGSQL = @LGSQL + '  WHERE 1 = 1 '
  SET @LGSQL = @LGSQL + '  ORDER BY '
  SET @LGSQL = @LGSQL + CASE @OrderBy
                        WHEN 't_orno' THEN '[ttdpur400200].[t_orno]'
                        WHEN 't_orno DESC' THEN '[ttdpur400200].[t_orno] DESC'
                        WHEN 't_otbp' THEN '[ttdpur400200].[t_otbp]'
                        WHEN 't_otbp DESC' THEN '[ttdpur400200].[t_otbp] DESC'
                        WHEN 't_otad' THEN '[ttdpur400200].[t_otad]'
                        WHEN 't_otad DESC' THEN '[ttdpur400200].[t_otad] DESC'
                        WHEN 't_otcn' THEN '[ttdpur400200].[t_otcn]'
                        WHEN 't_otcn DESC' THEN '[ttdpur400200].[t_otcn] DESC'
                        WHEN 't_sfbp' THEN '[ttdpur400200].[t_sfbp]'
                        WHEN 't_sfbp DESC' THEN '[ttdpur400200].[t_sfbp] DESC'
                        WHEN 't_sfad' THEN '[ttdpur400200].[t_sfad]'
                        WHEN 't_sfad DESC' THEN '[ttdpur400200].[t_sfad] DESC'
                        WHEN 't_sfcn' THEN '[ttdpur400200].[t_sfcn]'
                        WHEN 't_sfcn DESC' THEN '[ttdpur400200].[t_sfcn] DESC'
                        WHEN 't_ifbp' THEN '[ttdpur400200].[t_ifbp]'
                        WHEN 't_ifbp DESC' THEN '[ttdpur400200].[t_ifbp] DESC'
                        WHEN 't_ifad' THEN '[ttdpur400200].[t_ifad]'
                        WHEN 't_ifad DESC' THEN '[ttdpur400200].[t_ifad] DESC'
                        WHEN 't_ifcn' THEN '[ttdpur400200].[t_ifcn]'
                        WHEN 't_ifcn DESC' THEN '[ttdpur400200].[t_ifcn] DESC'
                        WHEN 't_ptbp' THEN '[ttdpur400200].[t_ptbp]'
                        WHEN 't_ptbp DESC' THEN '[ttdpur400200].[t_ptbp] DESC'
                        WHEN 't_ptad' THEN '[ttdpur400200].[t_ptad]'
                        WHEN 't_ptad DESC' THEN '[ttdpur400200].[t_ptad] DESC'
                        WHEN 't_ptcn' THEN '[ttdpur400200].[t_ptcn]'
                        WHEN 't_ptcn DESC' THEN '[ttdpur400200].[t_ptcn] DESC'
                        WHEN 't_corg' THEN '[ttdpur400200].[t_corg]'
                        WHEN 't_corg DESC' THEN '[ttdpur400200].[t_corg] DESC'
                        WHEN 't_cotp' THEN '[ttdpur400200].[t_cotp]'
                        WHEN 't_cotp DESC' THEN '[ttdpur400200].[t_cotp] DESC'
                        WHEN 't_ragr' THEN '[ttdpur400200].[t_ragr]'
                        WHEN 't_ragr DESC' THEN '[ttdpur400200].[t_ragr] DESC'
                        WHEN 't_cpay' THEN '[ttdpur400200].[t_cpay]'
                        WHEN 't_cpay DESC' THEN '[ttdpur400200].[t_cpay] DESC'
                        WHEN 't_odat' THEN '[ttdpur400200].[t_odat]'
                        WHEN 't_odat DESC' THEN '[ttdpur400200].[t_odat] DESC'
                        WHEN 't_odis' THEN '[ttdpur400200].[t_odis]'
                        WHEN 't_odis DESC' THEN '[ttdpur400200].[t_odis] DESC'
                        WHEN 't_ccur' THEN '[ttdpur400200].[t_ccur]'
                        WHEN 't_ccur DESC' THEN '[ttdpur400200].[t_ccur] DESC'
                        WHEN 't_mcfr' THEN '[ttdpur400200].[t_mcfr]'
                        WHEN 't_mcfr DESC' THEN '[ttdpur400200].[t_mcfr] DESC'
                        WHEN 't_ratp_1' THEN '[ttdpur400200].[t_ratp_1]'
                        WHEN 't_ratp_1 DESC' THEN '[ttdpur400200].[t_ratp_1] DESC'
                        WHEN 't_ratp_2' THEN '[ttdpur400200].[t_ratp_2]'
                        WHEN 't_ratp_2 DESC' THEN '[ttdpur400200].[t_ratp_2] DESC'
                        WHEN 't_ratp_3' THEN '[ttdpur400200].[t_ratp_3]'
                        WHEN 't_ratp_3 DESC' THEN '[ttdpur400200].[t_ratp_3] DESC'
                        WHEN 't_ratf_1' THEN '[ttdpur400200].[t_ratf_1]'
                        WHEN 't_ratf_1 DESC' THEN '[ttdpur400200].[t_ratf_1] DESC'
                        WHEN 't_ratf_2' THEN '[ttdpur400200].[t_ratf_2]'
                        WHEN 't_ratf_2 DESC' THEN '[ttdpur400200].[t_ratf_2] DESC'
                        WHEN 't_ratf_3' THEN '[ttdpur400200].[t_ratf_3]'
                        WHEN 't_ratf_3 DESC' THEN '[ttdpur400200].[t_ratf_3] DESC'
                        WHEN 't_ratd' THEN '[ttdpur400200].[t_ratd]'
                        WHEN 't_ratd DESC' THEN '[ttdpur400200].[t_ratd] DESC'
                        WHEN 't_ratt' THEN '[ttdpur400200].[t_ratt]'
                        WHEN 't_ratt DESC' THEN '[ttdpur400200].[t_ratt] DESC'
                        WHEN 't_raur' THEN '[ttdpur400200].[t_raur]'
                        WHEN 't_raur DESC' THEN '[ttdpur400200].[t_raur] DESC'
                        WHEN 't_cwar' THEN '[ttdpur400200].[t_cwar]'
                        WHEN 't_cwar DESC' THEN '[ttdpur400200].[t_cwar] DESC'
                        WHEN 't_cadr' THEN '[ttdpur400200].[t_cadr]'
                        WHEN 't_cadr DESC' THEN '[ttdpur400200].[t_cadr] DESC'
                        WHEN 't_ccon' THEN '[ttdpur400200].[t_ccon]'
                        WHEN 't_ccon DESC' THEN '[ttdpur400200].[t_ccon] DESC'
                        WHEN 't_plnr' THEN '[ttdpur400200].[t_plnr]'
                        WHEN 't_plnr DESC' THEN '[ttdpur400200].[t_plnr] DESC'
                        WHEN 't_ccrs' THEN '[ttdpur400200].[t_ccrs]'
                        WHEN 't_ccrs DESC' THEN '[ttdpur400200].[t_ccrs] DESC'
                        WHEN 't_cfrw' THEN '[ttdpur400200].[t_cfrw]'
                        WHEN 't_cfrw DESC' THEN '[ttdpur400200].[t_cfrw] DESC'
                        WHEN 't_cplp' THEN '[ttdpur400200].[t_cplp]'
                        WHEN 't_cplp DESC' THEN '[ttdpur400200].[t_cplp] DESC'
                        WHEN 't_bppr' THEN '[ttdpur400200].[t_bppr]'
                        WHEN 't_bppr DESC' THEN '[ttdpur400200].[t_bppr] DESC'
                        WHEN 't_bptx' THEN '[ttdpur400200].[t_bptx]'
                        WHEN 't_bptx DESC' THEN '[ttdpur400200].[t_bptx] DESC'
                        WHEN 't_cdec' THEN '[ttdpur400200].[t_cdec]'
                        WHEN 't_cdec DESC' THEN '[ttdpur400200].[t_cdec] DESC'
                        WHEN 't_ptpa' THEN '[ttdpur400200].[t_ptpa]'
                        WHEN 't_ptpa DESC' THEN '[ttdpur400200].[t_ptpa] DESC'
                        WHEN 't_ddat' THEN '[ttdpur400200].[t_ddat]'
                        WHEN 't_ddat DESC' THEN '[ttdpur400200].[t_ddat] DESC'
                        WHEN 't_ddtc' THEN '[ttdpur400200].[t_ddtc]'
                        WHEN 't_ddtc DESC' THEN '[ttdpur400200].[t_ddtc] DESC'
                        WHEN 't_cbrn' THEN '[ttdpur400200].[t_cbrn]'
                        WHEN 't_cbrn DESC' THEN '[ttdpur400200].[t_cbrn] DESC'
                        WHEN 't_creg' THEN '[ttdpur400200].[t_creg]'
                        WHEN 't_creg DESC' THEN '[ttdpur400200].[t_creg] DESC'
                        WHEN 't_refa' THEN '[ttdpur400200].[t_refa]'
                        WHEN 't_refa DESC' THEN '[ttdpur400200].[t_refa] DESC'
                        WHEN 't_refb' THEN '[ttdpur400200].[t_refb]'
                        WHEN 't_refb DESC' THEN '[ttdpur400200].[t_refb] DESC'
                        WHEN 't_prno' THEN '[ttdpur400200].[t_prno]'
                        WHEN 't_prno DESC' THEN '[ttdpur400200].[t_prno] DESC'
                        WHEN 't_ctrj' THEN '[ttdpur400200].[t_ctrj]'
                        WHEN 't_ctrj DESC' THEN '[ttdpur400200].[t_ctrj] DESC'
                        WHEN 't_cofc' THEN '[ttdpur400200].[t_cofc]'
                        WHEN 't_cofc DESC' THEN '[ttdpur400200].[t_cofc] DESC'
                        WHEN 't_fdpt' THEN '[ttdpur400200].[t_fdpt]'
                        WHEN 't_fdpt DESC' THEN '[ttdpur400200].[t_fdpt] DESC'
                        WHEN 't_odty' THEN '[ttdpur400200].[t_odty]'
                        WHEN 't_odty DESC' THEN '[ttdpur400200].[t_odty] DESC'
                        WHEN 't_odno' THEN '[ttdpur400200].[t_odno]'
                        WHEN 't_odno DESC' THEN '[ttdpur400200].[t_odno] DESC'
                        WHEN 't_retr' THEN '[ttdpur400200].[t_retr]'
                        WHEN 't_retr DESC' THEN '[ttdpur400200].[t_retr] DESC'
                        WHEN 't_sorn' THEN '[ttdpur400200].[t_sorn]'
                        WHEN 't_sorn DESC' THEN '[ttdpur400200].[t_sorn] DESC'
                        WHEN 't_cosn' THEN '[ttdpur400200].[t_cosn]'
                        WHEN 't_cosn DESC' THEN '[ttdpur400200].[t_cosn] DESC'
                        WHEN 't_akcd' THEN '[ttdpur400200].[t_akcd]'
                        WHEN 't_akcd DESC' THEN '[ttdpur400200].[t_akcd] DESC'
                        WHEN 't_crcd' THEN '[ttdpur400200].[t_crcd]'
                        WHEN 't_crcd DESC' THEN '[ttdpur400200].[t_crcd] DESC'
                        WHEN 't_ctcd' THEN '[ttdpur400200].[t_ctcd]'
                        WHEN 't_ctcd DESC' THEN '[ttdpur400200].[t_ctcd] DESC'
                        WHEN 't_egen' THEN '[ttdpur400200].[t_egen]'
                        WHEN 't_egen DESC' THEN '[ttdpur400200].[t_egen] DESC'
                        WHEN 't_sbim' THEN '[ttdpur400200].[t_sbim]'
                        WHEN 't_sbim DESC' THEN '[ttdpur400200].[t_sbim] DESC'
                        WHEN 't_paft' THEN '[ttdpur400200].[t_paft]'
                        WHEN 't_paft DESC' THEN '[ttdpur400200].[t_paft] DESC'
                        WHEN 't_sbmt' THEN '[ttdpur400200].[t_sbmt]'
                        WHEN 't_sbmt DESC' THEN '[ttdpur400200].[t_sbmt] DESC'
                        WHEN 't_bpcl' THEN '[ttdpur400200].[t_bpcl]'
                        WHEN 't_bpcl DESC' THEN '[ttdpur400200].[t_bpcl] DESC'
                        WHEN 't_oamt' THEN '[ttdpur400200].[t_oamt]'
                        WHEN 't_oamt DESC' THEN '[ttdpur400200].[t_oamt] DESC'
                        WHEN 't_comm' THEN '[ttdpur400200].[t_comm]'
                        WHEN 't_comm DESC' THEN '[ttdpur400200].[t_comm] DESC'
                        WHEN 't_iebp' THEN '[ttdpur400200].[t_iebp]'
                        WHEN 't_iebp DESC' THEN '[ttdpur400200].[t_iebp] DESC'
                        WHEN 't_iafc' THEN '[ttdpur400200].[t_iafc]'
                        WHEN 't_iafc DESC' THEN '[ttdpur400200].[t_iafc] DESC'
                        WHEN 't_lccl' THEN '[ttdpur400200].[t_lccl]'
                        WHEN 't_lccl DESC' THEN '[ttdpur400200].[t_lccl] DESC'
                        WHEN 't_hdst' THEN '[ttdpur400200].[t_hdst]'
                        WHEN 't_hdst DESC' THEN '[ttdpur400200].[t_hdst] DESC'
                        WHEN 't_hisp' THEN '[ttdpur400200].[t_hisp]'
                        WHEN 't_hisp DESC' THEN '[ttdpur400200].[t_hisp] DESC'
                        WHEN 't_hism' THEN '[ttdpur400200].[t_hism]'
                        WHEN 't_hism DESC' THEN '[ttdpur400200].[t_hism] DESC'
                        WHEN 't_ccty' THEN '[ttdpur400200].[t_ccty]'
                        WHEN 't_ccty DESC' THEN '[ttdpur400200].[t_ccty] DESC'
                        WHEN 't_cvyn' THEN '[ttdpur400200].[t_cvyn]'
                        WHEN 't_cvyn DESC' THEN '[ttdpur400200].[t_cvyn] DESC'
                        WHEN 't_bpid_l' THEN '[ttdpur400200].[t_bpid_l]'
                        WHEN 't_bpid_l DESC' THEN '[ttdpur400200].[t_bpid_l] DESC'
                        WHEN 't_impo_l' THEN '[ttdpur400200].[t_impo_l]'
                        WHEN 't_impo_l DESC' THEN '[ttdpur400200].[t_impo_l] DESC'
                        WHEN 't_ccty_l' THEN '[ttdpur400200].[t_ccty_l]'
                        WHEN 't_ccty_l DESC' THEN '[ttdpur400200].[t_ccty_l] DESC'
                        WHEN 't_cvat_l' THEN '[ttdpur400200].[t_cvat_l]'
                        WHEN 't_cvat_l DESC' THEN '[ttdpur400200].[t_cvat_l] DESC'
                        WHEN 't_exmt_l' THEN '[ttdpur400200].[t_exmt_l]'
                        WHEN 't_exmt_l DESC' THEN '[ttdpur400200].[t_exmt_l] DESC'
                        WHEN 't_catg_l' THEN '[ttdpur400200].[t_catg_l]'
                        WHEN 't_catg_l DESC' THEN '[ttdpur400200].[t_catg_l] DESC'
                        WHEN 't_ceno_l' THEN '[ttdpur400200].[t_ceno_l]'
                        WHEN 't_ceno_l DESC' THEN '[ttdpur400200].[t_ceno_l] DESC'
                        WHEN 't_bdbt_l' THEN '[ttdpur400200].[t_bdbt_l]'
                        WHEN 't_bdbt_l DESC' THEN '[ttdpur400200].[t_bdbt_l] DESC'
                        WHEN 't_bnoo_l' THEN '[ttdpur400200].[t_bnoo_l]'
                        WHEN 't_bnoo_l DESC' THEN '[ttdpur400200].[t_bnoo_l] DESC'
                        WHEN 't_txta' THEN '[ttdpur400200].[t_txta]'
                        WHEN 't_txta DESC' THEN '[ttdpur400200].[t_txta] DESC'
                        WHEN 't_txtb' THEN '[ttdpur400200].[t_txtb]'
                        WHEN 't_txtb DESC' THEN '[ttdpur400200].[t_txtb] DESC'
                        WHEN 't_cdf_adat' THEN '[ttdpur400200].[t_cdf_adat]'
                        WHEN 't_cdf_adat DESC' THEN '[ttdpur400200].[t_cdf_adat] DESC'
                        WHEN 't_cdf_alvl' THEN '[ttdpur400200].[t_cdf_alvl]'
                        WHEN 't_cdf_alvl DESC' THEN '[ttdpur400200].[t_cdf_alvl] DESC'
                        WHEN 't_cdf_onlr' THEN '[ttdpur400200].[t_cdf_onlr]'
                        WHEN 't_cdf_onlr DESC' THEN '[ttdpur400200].[t_cdf_onlr] DESC'
                        WHEN 't_cdf_prty' THEN '[ttdpur400200].[t_cdf_prty]'
                        WHEN 't_cdf_prty DESC' THEN '[ttdpur400200].[t_cdf_prty] DESC'
                        WHEN 't_cdf_qap' THEN '[ttdpur400200].[t_cdf_qap]'
                        WHEN 't_cdf_qap DESC' THEN '[ttdpur400200].[t_cdf_qap] DESC'
                        WHEN 't_cdf_qdat' THEN '[ttdpur400200].[t_cdf_qdat]'
                        WHEN 't_cdf_qdat DESC' THEN '[ttdpur400200].[t_cdf_qdat] DESC'
                        WHEN 't_cdf_refb' THEN '[ttdpur400200].[t_cdf_refb]'
                        WHEN 't_cdf_refb DESC' THEN '[ttdpur400200].[t_cdf_refb] DESC'
                        WHEN 't_Refcntd' THEN '[ttdpur400200].[t_Refcntd]'
                        WHEN 't_Refcntd DESC' THEN '[ttdpur400200].[t_Refcntd] DESC'
                        WHEN 't_Refcntu' THEN '[ttdpur400200].[t_Refcntu]'
                        WHEN 't_Refcntu DESC' THEN '[ttdpur400200].[t_Refcntu] DESC'
                        WHEN 't_cdf_reas' THEN '[ttdpur400200].[t_cdf_reas]'
                        WHEN 't_cdf_reas DESC' THEN '[ttdpur400200].[t_cdf_reas] DESC'
                        WHEN 't_cdf_qapa' THEN '[ttdpur400200].[t_cdf_qapa]'
                        WHEN 't_cdf_qapa DESC' THEN '[ttdpur400200].[t_cdf_qapa] DESC'
                        WHEN 't_atfr_l' THEN '[ttdpur400200].[t_atfr_l]'
                        WHEN 't_atfr_l DESC' THEN '[ttdpur400200].[t_atfr_l] DESC'
                        ELSE '[ttdpur400200].[t_orno]'
                    END
  EXEC (@LGSQL)

  SET @RecordCount = @@RowCount

  SELECT
    [ttdpur400200].*  
  FROM [ttdpur400200] 
      INNER JOIN #PageIndex
          ON [ttdpur400200].[t_orno] = #PageIndex.t_orno
  WHERE
        #PageIndex.IndexID > @StartRowIndex
        AND #PageIndex.IndexID < (@StartRowIndex + @MaximumRows + 1)
  ORDER BY
    #PageIndex.IndexID
  END
  GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sptdpur401SelectList]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sptdpur401SelectList]
GO
 
CREATE PROCEDURE [dbo].[sptdpur401SelectList]
  @LoginID NVarChar(8),
  @OrderBy NVarChar(50),
  @RecordCount Int = 0 OUTPUT
  AS
  SELECT
    [ttdpur401200].*  
  FROM [ttdpur401200] 
  WHERE 1 = 1  
  ORDER BY
     CASE @OrderBy WHEN 't_orno' THEN [ttdpur401200].[t_orno] END,
     CASE @OrderBy WHEN 't_orno DESC' THEN [ttdpur401200].[t_orno] END DESC,
     CASE @OrderBy WHEN 't_pono' THEN [ttdpur401200].[t_pono] END,
     CASE @OrderBy WHEN 't_pono DESC' THEN [ttdpur401200].[t_pono] END DESC,
     CASE @OrderBy WHEN 't_sqnb' THEN [ttdpur401200].[t_sqnb] END,
     CASE @OrderBy WHEN 't_sqnb DESC' THEN [ttdpur401200].[t_sqnb] END DESC,
     CASE @OrderBy WHEN 't_corg' THEN [ttdpur401200].[t_corg] END,
     CASE @OrderBy WHEN 't_corg DESC' THEN [ttdpur401200].[t_corg] END DESC,
     CASE @OrderBy WHEN 't_oltp' THEN [ttdpur401200].[t_oltp] END,
     CASE @OrderBy WHEN 't_oltp DESC' THEN [ttdpur401200].[t_oltp] END DESC,
     CASE @OrderBy WHEN 't_otbp' THEN [ttdpur401200].[t_otbp] END,
     CASE @OrderBy WHEN 't_otbp DESC' THEN [ttdpur401200].[t_otbp] END DESC,
     CASE @OrderBy WHEN 't_sfbp' THEN [ttdpur401200].[t_sfbp] END,
     CASE @OrderBy WHEN 't_sfbp DESC' THEN [ttdpur401200].[t_sfbp] END DESC,
     CASE @OrderBy WHEN 't_sfad' THEN [ttdpur401200].[t_sfad] END,
     CASE @OrderBy WHEN 't_sfad DESC' THEN [ttdpur401200].[t_sfad] END DESC,
     CASE @OrderBy WHEN 't_sfcn' THEN [ttdpur401200].[t_sfcn] END,
     CASE @OrderBy WHEN 't_sfcn DESC' THEN [ttdpur401200].[t_sfcn] END DESC,
     CASE @OrderBy WHEN 't_sfwh' THEN [ttdpur401200].[t_sfwh] END,
     CASE @OrderBy WHEN 't_sfwh DESC' THEN [ttdpur401200].[t_sfwh] END DESC,
     CASE @OrderBy WHEN 't_item' THEN [ttdpur401200].[t_item] END,
     CASE @OrderBy WHEN 't_item DESC' THEN [ttdpur401200].[t_item] END DESC,
     CASE @OrderBy WHEN 't_effn' THEN [ttdpur401200].[t_effn] END,
     CASE @OrderBy WHEN 't_effn DESC' THEN [ttdpur401200].[t_effn] END DESC,
     CASE @OrderBy WHEN 't_sdsc' THEN [ttdpur401200].[t_sdsc] END,
     CASE @OrderBy WHEN 't_sdsc DESC' THEN [ttdpur401200].[t_sdsc] END DESC,
     CASE @OrderBy WHEN 't_crrf' THEN [ttdpur401200].[t_crrf] END,
     CASE @OrderBy WHEN 't_crrf DESC' THEN [ttdpur401200].[t_crrf] END DESC,
     CASE @OrderBy WHEN 't_citt' THEN [ttdpur401200].[t_citt] END,
     CASE @OrderBy WHEN 't_citt DESC' THEN [ttdpur401200].[t_citt] END DESC,
     CASE @OrderBy WHEN 't_crit' THEN [ttdpur401200].[t_crit] END,
     CASE @OrderBy WHEN 't_crit DESC' THEN [ttdpur401200].[t_crit] END DESC,
     CASE @OrderBy WHEN 't_mpnr' THEN [ttdpur401200].[t_mpnr] END,
     CASE @OrderBy WHEN 't_mpnr DESC' THEN [ttdpur401200].[t_mpnr] END DESC,
     CASE @OrderBy WHEN 't_subc' THEN [ttdpur401200].[t_subc] END,
     CASE @OrderBy WHEN 't_subc DESC' THEN [ttdpur401200].[t_subc] END DESC,
     CASE @OrderBy WHEN 't_mpsn' THEN [ttdpur401200].[t_mpsn] END,
     CASE @OrderBy WHEN 't_mpsn DESC' THEN [ttdpur401200].[t_mpsn] END DESC,
     CASE @OrderBy WHEN 't_cmnf' THEN [ttdpur401200].[t_cmnf] END,
     CASE @OrderBy WHEN 't_cmnf DESC' THEN [ttdpur401200].[t_cmnf] END DESC,
     CASE @OrderBy WHEN 't_mitm' THEN [ttdpur401200].[t_mitm] END,
     CASE @OrderBy WHEN 't_mitm DESC' THEN [ttdpur401200].[t_mitm] END DESC,
     CASE @OrderBy WHEN 't_revi' THEN [ttdpur401200].[t_revi] END,
     CASE @OrderBy WHEN 't_revi DESC' THEN [ttdpur401200].[t_revi] END DESC,
     CASE @OrderBy WHEN 't_btsp' THEN [ttdpur401200].[t_btsp] END,
     CASE @OrderBy WHEN 't_btsp DESC' THEN [ttdpur401200].[t_btsp] END DESC,
     CASE @OrderBy WHEN 't_qual' THEN [ttdpur401200].[t_qual] END,
     CASE @OrderBy WHEN 't_qual DESC' THEN [ttdpur401200].[t_qual] END DESC,
     CASE @OrderBy WHEN 't_qoor' THEN [ttdpur401200].[t_qoor] END,
     CASE @OrderBy WHEN 't_qoor DESC' THEN [ttdpur401200].[t_qoor] END DESC,
     CASE @OrderBy WHEN 't_cuqp' THEN [ttdpur401200].[t_cuqp] END,
     CASE @OrderBy WHEN 't_cuqp DESC' THEN [ttdpur401200].[t_cuqp] END DESC,
     CASE @OrderBy WHEN 't_cvqp' THEN [ttdpur401200].[t_cvqp] END,
     CASE @OrderBy WHEN 't_cvqp DESC' THEN [ttdpur401200].[t_cvqp] END DESC,
     CASE @OrderBy WHEN 't_leng' THEN [ttdpur401200].[t_leng] END,
     CASE @OrderBy WHEN 't_leng DESC' THEN [ttdpur401200].[t_leng] END DESC,
     CASE @OrderBy WHEN 't_widt' THEN [ttdpur401200].[t_widt] END,
     CASE @OrderBy WHEN 't_widt DESC' THEN [ttdpur401200].[t_widt] END DESC,
     CASE @OrderBy WHEN 't_thic' THEN [ttdpur401200].[t_thic] END,
     CASE @OrderBy WHEN 't_thic DESC' THEN [ttdpur401200].[t_thic] END DESC,
     CASE @OrderBy WHEN 't_odat' THEN [ttdpur401200].[t_odat] END,
     CASE @OrderBy WHEN 't_odat DESC' THEN [ttdpur401200].[t_odat] END DESC,
     CASE @OrderBy WHEN 't_ddta' THEN [ttdpur401200].[t_ddta] END,
     CASE @OrderBy WHEN 't_ddta DESC' THEN [ttdpur401200].[t_ddta] END DESC,
     CASE @OrderBy WHEN 't_ddtb' THEN [ttdpur401200].[t_ddtb] END,
     CASE @OrderBy WHEN 't_ddtb DESC' THEN [ttdpur401200].[t_ddtb] END DESC,
     CASE @OrderBy WHEN 't_ddtc' THEN [ttdpur401200].[t_ddtc] END,
     CASE @OrderBy WHEN 't_ddtc DESC' THEN [ttdpur401200].[t_ddtc] END DESC,
     CASE @OrderBy WHEN 't_ddtd' THEN [ttdpur401200].[t_ddtd] END,
     CASE @OrderBy WHEN 't_ddtd DESC' THEN [ttdpur401200].[t_ddtd] END DESC,
     CASE @OrderBy WHEN 't_ddte' THEN [ttdpur401200].[t_ddte] END,
     CASE @OrderBy WHEN 't_ddte DESC' THEN [ttdpur401200].[t_ddte] END DESC,
     CASE @OrderBy WHEN 't_ddtf' THEN [ttdpur401200].[t_ddtf] END,
     CASE @OrderBy WHEN 't_ddtf DESC' THEN [ttdpur401200].[t_ddtf] END DESC,
     CASE @OrderBy WHEN 't_rdta' THEN [ttdpur401200].[t_rdta] END,
     CASE @OrderBy WHEN 't_rdta DESC' THEN [ttdpur401200].[t_rdta] END DESC,
     CASE @OrderBy WHEN 't_pric' THEN [ttdpur401200].[t_pric] END,
     CASE @OrderBy WHEN 't_pric DESC' THEN [ttdpur401200].[t_pric] END DESC,
     CASE @OrderBy WHEN 't_porg' THEN [ttdpur401200].[t_porg] END,
     CASE @OrderBy WHEN 't_porg DESC' THEN [ttdpur401200].[t_porg] END DESC,
     CASE @OrderBy WHEN 't_pmde' THEN [ttdpur401200].[t_pmde] END,
     CASE @OrderBy WHEN 't_pmde DESC' THEN [ttdpur401200].[t_pmde] END DESC,
     CASE @OrderBy WHEN 't_pmse' THEN [ttdpur401200].[t_pmse] END,
     CASE @OrderBy WHEN 't_pmse DESC' THEN [ttdpur401200].[t_pmse] END DESC,
     CASE @OrderBy WHEN 't_cupp' THEN [ttdpur401200].[t_cupp] END,
     CASE @OrderBy WHEN 't_cupp DESC' THEN [ttdpur401200].[t_cupp] END DESC,
     CASE @OrderBy WHEN 't_cvpp' THEN [ttdpur401200].[t_cvpp] END,
     CASE @OrderBy WHEN 't_cvpp DESC' THEN [ttdpur401200].[t_cvpp] END DESC,
     CASE @OrderBy WHEN 't_disc_1' THEN [ttdpur401200].[t_disc_1] END,
     CASE @OrderBy WHEN 't_disc_1 DESC' THEN [ttdpur401200].[t_disc_1] END DESC,
     CASE @OrderBy WHEN 't_disc_2' THEN [ttdpur401200].[t_disc_2] END,
     CASE @OrderBy WHEN 't_disc_2 DESC' THEN [ttdpur401200].[t_disc_2] END DESC,
     CASE @OrderBy WHEN 't_disc_3' THEN [ttdpur401200].[t_disc_3] END,
     CASE @OrderBy WHEN 't_disc_3 DESC' THEN [ttdpur401200].[t_disc_3] END DESC,
     CASE @OrderBy WHEN 't_disc_4' THEN [ttdpur401200].[t_disc_4] END,
     CASE @OrderBy WHEN 't_disc_4 DESC' THEN [ttdpur401200].[t_disc_4] END DESC,
     CASE @OrderBy WHEN 't_disc_5' THEN [ttdpur401200].[t_disc_5] END,
     CASE @OrderBy WHEN 't_disc_5 DESC' THEN [ttdpur401200].[t_disc_5] END DESC,
     CASE @OrderBy WHEN 't_disc_6' THEN [ttdpur401200].[t_disc_6] END,
     CASE @OrderBy WHEN 't_disc_6 DESC' THEN [ttdpur401200].[t_disc_6] END DESC,
     CASE @OrderBy WHEN 't_disc_7' THEN [ttdpur401200].[t_disc_7] END,
     CASE @OrderBy WHEN 't_disc_7 DESC' THEN [ttdpur401200].[t_disc_7] END DESC,
     CASE @OrderBy WHEN 't_disc_8' THEN [ttdpur401200].[t_disc_8] END,
     CASE @OrderBy WHEN 't_disc_8 DESC' THEN [ttdpur401200].[t_disc_8] END DESC,
     CASE @OrderBy WHEN 't_disc_9' THEN [ttdpur401200].[t_disc_9] END,
     CASE @OrderBy WHEN 't_disc_9 DESC' THEN [ttdpur401200].[t_disc_9] END DESC,
     CASE @OrderBy WHEN 't_disc_10' THEN [ttdpur401200].[t_disc_10] END,
     CASE @OrderBy WHEN 't_disc_10 DESC' THEN [ttdpur401200].[t_disc_10] END DESC,
     CASE @OrderBy WHEN 't_disc_11' THEN [ttdpur401200].[t_disc_11] END,
     CASE @OrderBy WHEN 't_disc_11 DESC' THEN [ttdpur401200].[t_disc_11] END DESC,
     CASE @OrderBy WHEN 't_ldam_1' THEN [ttdpur401200].[t_ldam_1] END,
     CASE @OrderBy WHEN 't_ldam_1 DESC' THEN [ttdpur401200].[t_ldam_1] END DESC,
     CASE @OrderBy WHEN 't_ldam_2' THEN [ttdpur401200].[t_ldam_2] END,
     CASE @OrderBy WHEN 't_ldam_2 DESC' THEN [ttdpur401200].[t_ldam_2] END DESC,
     CASE @OrderBy WHEN 't_ldam_3' THEN [ttdpur401200].[t_ldam_3] END,
     CASE @OrderBy WHEN 't_ldam_3 DESC' THEN [ttdpur401200].[t_ldam_3] END DESC,
     CASE @OrderBy WHEN 't_ldam_4' THEN [ttdpur401200].[t_ldam_4] END,
     CASE @OrderBy WHEN 't_ldam_4 DESC' THEN [ttdpur401200].[t_ldam_4] END DESC,
     CASE @OrderBy WHEN 't_ldam_5' THEN [ttdpur401200].[t_ldam_5] END,
     CASE @OrderBy WHEN 't_ldam_5 DESC' THEN [ttdpur401200].[t_ldam_5] END DESC,
     CASE @OrderBy WHEN 't_ldam_6' THEN [ttdpur401200].[t_ldam_6] END,
     CASE @OrderBy WHEN 't_ldam_6 DESC' THEN [ttdpur401200].[t_ldam_6] END DESC,
     CASE @OrderBy WHEN 't_ldam_7' THEN [ttdpur401200].[t_ldam_7] END,
     CASE @OrderBy WHEN 't_ldam_7 DESC' THEN [ttdpur401200].[t_ldam_7] END DESC,
     CASE @OrderBy WHEN 't_ldam_8' THEN [ttdpur401200].[t_ldam_8] END,
     CASE @OrderBy WHEN 't_ldam_8 DESC' THEN [ttdpur401200].[t_ldam_8] END DESC,
     CASE @OrderBy WHEN 't_ldam_9' THEN [ttdpur401200].[t_ldam_9] END,
     CASE @OrderBy WHEN 't_ldam_9 DESC' THEN [ttdpur401200].[t_ldam_9] END DESC,
     CASE @OrderBy WHEN 't_ldam_10' THEN [ttdpur401200].[t_ldam_10] END,
     CASE @OrderBy WHEN 't_ldam_10 DESC' THEN [ttdpur401200].[t_ldam_10] END DESC,
     CASE @OrderBy WHEN 't_ldam_11' THEN [ttdpur401200].[t_ldam_11] END,
     CASE @OrderBy WHEN 't_ldam_11 DESC' THEN [ttdpur401200].[t_ldam_11] END DESC,
     CASE @OrderBy WHEN 't_dorg_1' THEN [ttdpur401200].[t_dorg_1] END,
     CASE @OrderBy WHEN 't_dorg_1 DESC' THEN [ttdpur401200].[t_dorg_1] END DESC,
     CASE @OrderBy WHEN 't_dorg_2' THEN [ttdpur401200].[t_dorg_2] END,
     CASE @OrderBy WHEN 't_dorg_2 DESC' THEN [ttdpur401200].[t_dorg_2] END DESC,
     CASE @OrderBy WHEN 't_dorg_3' THEN [ttdpur401200].[t_dorg_3] END,
     CASE @OrderBy WHEN 't_dorg_3 DESC' THEN [ttdpur401200].[t_dorg_3] END DESC,
     CASE @OrderBy WHEN 't_dorg_4' THEN [ttdpur401200].[t_dorg_4] END,
     CASE @OrderBy WHEN 't_dorg_4 DESC' THEN [ttdpur401200].[t_dorg_4] END DESC,
     CASE @OrderBy WHEN 't_dorg_5' THEN [ttdpur401200].[t_dorg_5] END,
     CASE @OrderBy WHEN 't_dorg_5 DESC' THEN [ttdpur401200].[t_dorg_5] END DESC,
     CASE @OrderBy WHEN 't_dorg_6' THEN [ttdpur401200].[t_dorg_6] END,
     CASE @OrderBy WHEN 't_dorg_6 DESC' THEN [ttdpur401200].[t_dorg_6] END DESC,
     CASE @OrderBy WHEN 't_dorg_7' THEN [ttdpur401200].[t_dorg_7] END,
     CASE @OrderBy WHEN 't_dorg_7 DESC' THEN [ttdpur401200].[t_dorg_7] END DESC,
     CASE @OrderBy WHEN 't_dorg_8' THEN [ttdpur401200].[t_dorg_8] END,
     CASE @OrderBy WHEN 't_dorg_8 DESC' THEN [ttdpur401200].[t_dorg_8] END DESC,
     CASE @OrderBy WHEN 't_dorg_9' THEN [ttdpur401200].[t_dorg_9] END,
     CASE @OrderBy WHEN 't_dorg_9 DESC' THEN [ttdpur401200].[t_dorg_9] END DESC,
     CASE @OrderBy WHEN 't_dorg_10' THEN [ttdpur401200].[t_dorg_10] END,
     CASE @OrderBy WHEN 't_dorg_10 DESC' THEN [ttdpur401200].[t_dorg_10] END DESC,
     CASE @OrderBy WHEN 't_dorg_11' THEN [ttdpur401200].[t_dorg_11] END,
     CASE @OrderBy WHEN 't_dorg_11 DESC' THEN [ttdpur401200].[t_dorg_11] END DESC,
     CASE @OrderBy WHEN 't_dmty_1' THEN [ttdpur401200].[t_dmty_1] END,
     CASE @OrderBy WHEN 't_dmty_1 DESC' THEN [ttdpur401200].[t_dmty_1] END DESC,
     CASE @OrderBy WHEN 't_dmty_2' THEN [ttdpur401200].[t_dmty_2] END,
     CASE @OrderBy WHEN 't_dmty_2 DESC' THEN [ttdpur401200].[t_dmty_2] END DESC,
     CASE @OrderBy WHEN 't_dmty_3' THEN [ttdpur401200].[t_dmty_3] END,
     CASE @OrderBy WHEN 't_dmty_3 DESC' THEN [ttdpur401200].[t_dmty_3] END DESC,
     CASE @OrderBy WHEN 't_dmty_4' THEN [ttdpur401200].[t_dmty_4] END,
     CASE @OrderBy WHEN 't_dmty_4 DESC' THEN [ttdpur401200].[t_dmty_4] END DESC,
     CASE @OrderBy WHEN 't_dmty_5' THEN [ttdpur401200].[t_dmty_5] END,
     CASE @OrderBy WHEN 't_dmty_5 DESC' THEN [ttdpur401200].[t_dmty_5] END DESC,
     CASE @OrderBy WHEN 't_dmty_6' THEN [ttdpur401200].[t_dmty_6] END,
     CASE @OrderBy WHEN 't_dmty_6 DESC' THEN [ttdpur401200].[t_dmty_6] END DESC,
     CASE @OrderBy WHEN 't_dmty_7' THEN [ttdpur401200].[t_dmty_7] END,
     CASE @OrderBy WHEN 't_dmty_7 DESC' THEN [ttdpur401200].[t_dmty_7] END DESC,
     CASE @OrderBy WHEN 't_dmty_8' THEN [ttdpur401200].[t_dmty_8] END,
     CASE @OrderBy WHEN 't_dmty_8 DESC' THEN [ttdpur401200].[t_dmty_8] END DESC,
     CASE @OrderBy WHEN 't_dmty_9' THEN [ttdpur401200].[t_dmty_9] END,
     CASE @OrderBy WHEN 't_dmty_9 DESC' THEN [ttdpur401200].[t_dmty_9] END DESC,
     CASE @OrderBy WHEN 't_dmty_10' THEN [ttdpur401200].[t_dmty_10] END,
     CASE @OrderBy WHEN 't_dmty_10 DESC' THEN [ttdpur401200].[t_dmty_10] END DESC,
     CASE @OrderBy WHEN 't_dmty_11' THEN [ttdpur401200].[t_dmty_11] END,
     CASE @OrderBy WHEN 't_dmty_11 DESC' THEN [ttdpur401200].[t_dmty_11] END DESC,
     CASE @OrderBy WHEN 't_dmde_1' THEN [ttdpur401200].[t_dmde_1] END,
     CASE @OrderBy WHEN 't_dmde_1 DESC' THEN [ttdpur401200].[t_dmde_1] END DESC,
     CASE @OrderBy WHEN 't_dmde_2' THEN [ttdpur401200].[t_dmde_2] END,
     CASE @OrderBy WHEN 't_dmde_2 DESC' THEN [ttdpur401200].[t_dmde_2] END DESC,
     CASE @OrderBy WHEN 't_dmde_3' THEN [ttdpur401200].[t_dmde_3] END,
     CASE @OrderBy WHEN 't_dmde_3 DESC' THEN [ttdpur401200].[t_dmde_3] END DESC,
     CASE @OrderBy WHEN 't_dmde_4' THEN [ttdpur401200].[t_dmde_4] END,
     CASE @OrderBy WHEN 't_dmde_4 DESC' THEN [ttdpur401200].[t_dmde_4] END DESC,
     CASE @OrderBy WHEN 't_dmde_5' THEN [ttdpur401200].[t_dmde_5] END,
     CASE @OrderBy WHEN 't_dmde_5 DESC' THEN [ttdpur401200].[t_dmde_5] END DESC,
     CASE @OrderBy WHEN 't_dmde_6' THEN [ttdpur401200].[t_dmde_6] END,
     CASE @OrderBy WHEN 't_dmde_6 DESC' THEN [ttdpur401200].[t_dmde_6] END DESC,
     CASE @OrderBy WHEN 't_dmde_7' THEN [ttdpur401200].[t_dmde_7] END,
     CASE @OrderBy WHEN 't_dmde_7 DESC' THEN [ttdpur401200].[t_dmde_7] END DESC,
     CASE @OrderBy WHEN 't_dmde_8' THEN [ttdpur401200].[t_dmde_8] END,
     CASE @OrderBy WHEN 't_dmde_8 DESC' THEN [ttdpur401200].[t_dmde_8] END DESC,
     CASE @OrderBy WHEN 't_dmde_9' THEN [ttdpur401200].[t_dmde_9] END,
     CASE @OrderBy WHEN 't_dmde_9 DESC' THEN [ttdpur401200].[t_dmde_9] END DESC,
     CASE @OrderBy WHEN 't_dmde_10' THEN [ttdpur401200].[t_dmde_10] END,
     CASE @OrderBy WHEN 't_dmde_10 DESC' THEN [ttdpur401200].[t_dmde_10] END DESC,
     CASE @OrderBy WHEN 't_dmde_11' THEN [ttdpur401200].[t_dmde_11] END,
     CASE @OrderBy WHEN 't_dmde_11 DESC' THEN [ttdpur401200].[t_dmde_11] END DESC,
     CASE @OrderBy WHEN 't_dmse_1' THEN [ttdpur401200].[t_dmse_1] END,
     CASE @OrderBy WHEN 't_dmse_1 DESC' THEN [ttdpur401200].[t_dmse_1] END DESC,
     CASE @OrderBy WHEN 't_dmse_2' THEN [ttdpur401200].[t_dmse_2] END,
     CASE @OrderBy WHEN 't_dmse_2 DESC' THEN [ttdpur401200].[t_dmse_2] END DESC,
     CASE @OrderBy WHEN 't_dmse_3' THEN [ttdpur401200].[t_dmse_3] END,
     CASE @OrderBy WHEN 't_dmse_3 DESC' THEN [ttdpur401200].[t_dmse_3] END DESC,
     CASE @OrderBy WHEN 't_dmse_4' THEN [ttdpur401200].[t_dmse_4] END,
     CASE @OrderBy WHEN 't_dmse_4 DESC' THEN [ttdpur401200].[t_dmse_4] END DESC,
     CASE @OrderBy WHEN 't_dmse_5' THEN [ttdpur401200].[t_dmse_5] END,
     CASE @OrderBy WHEN 't_dmse_5 DESC' THEN [ttdpur401200].[t_dmse_5] END DESC,
     CASE @OrderBy WHEN 't_dmse_6' THEN [ttdpur401200].[t_dmse_6] END,
     CASE @OrderBy WHEN 't_dmse_6 DESC' THEN [ttdpur401200].[t_dmse_6] END DESC,
     CASE @OrderBy WHEN 't_dmse_7' THEN [ttdpur401200].[t_dmse_7] END,
     CASE @OrderBy WHEN 't_dmse_7 DESC' THEN [ttdpur401200].[t_dmse_7] END DESC,
     CASE @OrderBy WHEN 't_dmse_8' THEN [ttdpur401200].[t_dmse_8] END,
     CASE @OrderBy WHEN 't_dmse_8 DESC' THEN [ttdpur401200].[t_dmse_8] END DESC,
     CASE @OrderBy WHEN 't_dmse_9' THEN [ttdpur401200].[t_dmse_9] END,
     CASE @OrderBy WHEN 't_dmse_9 DESC' THEN [ttdpur401200].[t_dmse_9] END DESC,
     CASE @OrderBy WHEN 't_dmse_10' THEN [ttdpur401200].[t_dmse_10] END,
     CASE @OrderBy WHEN 't_dmse_10 DESC' THEN [ttdpur401200].[t_dmse_10] END DESC,
     CASE @OrderBy WHEN 't_dmse_11' THEN [ttdpur401200].[t_dmse_11] END,
     CASE @OrderBy WHEN 't_dmse_11 DESC' THEN [ttdpur401200].[t_dmse_11] END DESC,
     CASE @OrderBy WHEN 't_dmth_1' THEN [ttdpur401200].[t_dmth_1] END,
     CASE @OrderBy WHEN 't_dmth_1 DESC' THEN [ttdpur401200].[t_dmth_1] END DESC,
     CASE @OrderBy WHEN 't_dmth_2' THEN [ttdpur401200].[t_dmth_2] END,
     CASE @OrderBy WHEN 't_dmth_2 DESC' THEN [ttdpur401200].[t_dmth_2] END DESC,
     CASE @OrderBy WHEN 't_dmth_3' THEN [ttdpur401200].[t_dmth_3] END,
     CASE @OrderBy WHEN 't_dmth_3 DESC' THEN [ttdpur401200].[t_dmth_3] END DESC,
     CASE @OrderBy WHEN 't_dmth_4' THEN [ttdpur401200].[t_dmth_4] END,
     CASE @OrderBy WHEN 't_dmth_4 DESC' THEN [ttdpur401200].[t_dmth_4] END DESC,
     CASE @OrderBy WHEN 't_dmth_5' THEN [ttdpur401200].[t_dmth_5] END,
     CASE @OrderBy WHEN 't_dmth_5 DESC' THEN [ttdpur401200].[t_dmth_5] END DESC,
     CASE @OrderBy WHEN 't_dmth_6' THEN [ttdpur401200].[t_dmth_6] END,
     CASE @OrderBy WHEN 't_dmth_6 DESC' THEN [ttdpur401200].[t_dmth_6] END DESC,
     CASE @OrderBy WHEN 't_dmth_7' THEN [ttdpur401200].[t_dmth_7] END,
     CASE @OrderBy WHEN 't_dmth_7 DESC' THEN [ttdpur401200].[t_dmth_7] END DESC,
     CASE @OrderBy WHEN 't_dmth_8' THEN [ttdpur401200].[t_dmth_8] END,
     CASE @OrderBy WHEN 't_dmth_8 DESC' THEN [ttdpur401200].[t_dmth_8] END DESC,
     CASE @OrderBy WHEN 't_dmth_9' THEN [ttdpur401200].[t_dmth_9] END,
     CASE @OrderBy WHEN 't_dmth_9 DESC' THEN [ttdpur401200].[t_dmth_9] END DESC,
     CASE @OrderBy WHEN 't_dmth_10' THEN [ttdpur401200].[t_dmth_10] END,
     CASE @OrderBy WHEN 't_dmth_10 DESC' THEN [ttdpur401200].[t_dmth_10] END DESC,
     CASE @OrderBy WHEN 't_dmth_11' THEN [ttdpur401200].[t_dmth_11] END,
     CASE @OrderBy WHEN 't_dmth_11 DESC' THEN [ttdpur401200].[t_dmth_11] END DESC,
     CASE @OrderBy WHEN 't_cdis_1' THEN [ttdpur401200].[t_cdis_1] END,
     CASE @OrderBy WHEN 't_cdis_1 DESC' THEN [ttdpur401200].[t_cdis_1] END DESC,
     CASE @OrderBy WHEN 't_cdis_2' THEN [ttdpur401200].[t_cdis_2] END,
     CASE @OrderBy WHEN 't_cdis_2 DESC' THEN [ttdpur401200].[t_cdis_2] END DESC,
     CASE @OrderBy WHEN 't_cdis_3' THEN [ttdpur401200].[t_cdis_3] END,
     CASE @OrderBy WHEN 't_cdis_3 DESC' THEN [ttdpur401200].[t_cdis_3] END DESC,
     CASE @OrderBy WHEN 't_cdis_4' THEN [ttdpur401200].[t_cdis_4] END,
     CASE @OrderBy WHEN 't_cdis_4 DESC' THEN [ttdpur401200].[t_cdis_4] END DESC,
     CASE @OrderBy WHEN 't_cdis_5' THEN [ttdpur401200].[t_cdis_5] END,
     CASE @OrderBy WHEN 't_cdis_5 DESC' THEN [ttdpur401200].[t_cdis_5] END DESC,
     CASE @OrderBy WHEN 't_cdis_6' THEN [ttdpur401200].[t_cdis_6] END,
     CASE @OrderBy WHEN 't_cdis_6 DESC' THEN [ttdpur401200].[t_cdis_6] END DESC,
     CASE @OrderBy WHEN 't_cdis_7' THEN [ttdpur401200].[t_cdis_7] END,
     CASE @OrderBy WHEN 't_cdis_7 DESC' THEN [ttdpur401200].[t_cdis_7] END DESC,
     CASE @OrderBy WHEN 't_cdis_8' THEN [ttdpur401200].[t_cdis_8] END,
     CASE @OrderBy WHEN 't_cdis_8 DESC' THEN [ttdpur401200].[t_cdis_8] END DESC,
     CASE @OrderBy WHEN 't_cdis_9' THEN [ttdpur401200].[t_cdis_9] END,
     CASE @OrderBy WHEN 't_cdis_9 DESC' THEN [ttdpur401200].[t_cdis_9] END DESC,
     CASE @OrderBy WHEN 't_cdis_10' THEN [ttdpur401200].[t_cdis_10] END,
     CASE @OrderBy WHEN 't_cdis_10 DESC' THEN [ttdpur401200].[t_cdis_10] END DESC,
     CASE @OrderBy WHEN 't_cdis_11' THEN [ttdpur401200].[t_cdis_11] END,
     CASE @OrderBy WHEN 't_cdis_11 DESC' THEN [ttdpur401200].[t_cdis_11] END DESC,
     CASE @OrderBy WHEN 't_dtrm' THEN [ttdpur401200].[t_dtrm] END,
     CASE @OrderBy WHEN 't_dtrm DESC' THEN [ttdpur401200].[t_dtrm] END DESC,
     CASE @OrderBy WHEN 't_elgb' THEN [ttdpur401200].[t_elgb] END,
     CASE @OrderBy WHEN 't_elgb DESC' THEN [ttdpur401200].[t_elgb] END DESC,
     CASE @OrderBy WHEN 't_stdc' THEN [ttdpur401200].[t_stdc] END,
     CASE @OrderBy WHEN 't_stdc DESC' THEN [ttdpur401200].[t_stdc] END DESC,
     CASE @OrderBy WHEN 't_oamt' THEN [ttdpur401200].[t_oamt] END,
     CASE @OrderBy WHEN 't_oamt DESC' THEN [ttdpur401200].[t_oamt] END DESC,
     CASE @OrderBy WHEN 't_rcno' THEN [ttdpur401200].[t_rcno] END,
     CASE @OrderBy WHEN 't_rcno DESC' THEN [ttdpur401200].[t_rcno] END DESC,
     CASE @OrderBy WHEN 't_rseq' THEN [ttdpur401200].[t_rseq] END,
     CASE @OrderBy WHEN 't_rseq DESC' THEN [ttdpur401200].[t_rseq] END DESC,
     CASE @OrderBy WHEN 't_dino' THEN [ttdpur401200].[t_dino] END,
     CASE @OrderBy WHEN 't_dino DESC' THEN [ttdpur401200].[t_dino] END DESC,
     CASE @OrderBy WHEN 't_qips' THEN [ttdpur401200].[t_qips] END,
     CASE @OrderBy WHEN 't_qips DESC' THEN [ttdpur401200].[t_qips] END DESC,
     CASE @OrderBy WHEN 't_qidl' THEN [ttdpur401200].[t_qidl] END,
     CASE @OrderBy WHEN 't_qidl DESC' THEN [ttdpur401200].[t_qidl] END DESC,
     CASE @OrderBy WHEN 't_qiap' THEN [ttdpur401200].[t_qiap] END,
     CASE @OrderBy WHEN 't_qiap DESC' THEN [ttdpur401200].[t_qiap] END DESC,
     CASE @OrderBy WHEN 't_crej' THEN [ttdpur401200].[t_crej] END,
     CASE @OrderBy WHEN 't_crej DESC' THEN [ttdpur401200].[t_crej] END DESC,
     CASE @OrderBy WHEN 't_qirj' THEN [ttdpur401200].[t_qirj] END,
     CASE @OrderBy WHEN 't_qirj DESC' THEN [ttdpur401200].[t_qirj] END DESC,
     CASE @OrderBy WHEN 't_qibo' THEN [ttdpur401200].[t_qibo] END,
     CASE @OrderBy WHEN 't_qibo DESC' THEN [ttdpur401200].[t_qibo] END DESC,
     CASE @OrderBy WHEN 't_qbbc' THEN [ttdpur401200].[t_qbbc] END,
     CASE @OrderBy WHEN 't_qbbc DESC' THEN [ttdpur401200].[t_qbbc] END DESC,
     CASE @OrderBy WHEN 't_cubp' THEN [ttdpur401200].[t_cubp] END,
     CASE @OrderBy WHEN 't_cubp DESC' THEN [ttdpur401200].[t_cubp] END DESC,
     CASE @OrderBy WHEN 't_cvbp' THEN [ttdpur401200].[t_cvbp] END,
     CASE @OrderBy WHEN 't_cvbp DESC' THEN [ttdpur401200].[t_cvbp] END DESC,
     CASE @OrderBy WHEN 't_fire' THEN [ttdpur401200].[t_fire] END,
     CASE @OrderBy WHEN 't_fire DESC' THEN [ttdpur401200].[t_fire] END DESC,
     CASE @OrderBy WHEN 't_qibp' THEN [ttdpur401200].[t_qibp] END,
     CASE @OrderBy WHEN 't_qibp DESC' THEN [ttdpur401200].[t_qibp] END DESC,
     CASE @OrderBy WHEN 't_ddon' THEN [ttdpur401200].[t_ddon] END,
     CASE @OrderBy WHEN 't_ddon DESC' THEN [ttdpur401200].[t_ddon] END DESC,
     CASE @OrderBy WHEN 't_lseq' THEN [ttdpur401200].[t_lseq] END,
     CASE @OrderBy WHEN 't_lseq DESC' THEN [ttdpur401200].[t_lseq] END DESC,
     CASE @OrderBy WHEN 't_pseq' THEN [ttdpur401200].[t_pseq] END,
     CASE @OrderBy WHEN 't_pseq DESC' THEN [ttdpur401200].[t_pseq] END DESC,
     CASE @OrderBy WHEN 't_amld' THEN [ttdpur401200].[t_amld] END,
     CASE @OrderBy WHEN 't_amld DESC' THEN [ttdpur401200].[t_amld] END DESC,
     CASE @OrderBy WHEN 't_amod' THEN [ttdpur401200].[t_amod] END,
     CASE @OrderBy WHEN 't_amod DESC' THEN [ttdpur401200].[t_amod] END DESC,
     CASE @OrderBy WHEN 't_damt' THEN [ttdpur401200].[t_damt] END,
     CASE @OrderBy WHEN 't_damt DESC' THEN [ttdpur401200].[t_damt] END DESC,
     CASE @OrderBy WHEN 't_stsc' THEN [ttdpur401200].[t_stsc] END,
     CASE @OrderBy WHEN 't_stsc DESC' THEN [ttdpur401200].[t_stsc] END DESC,
     CASE @OrderBy WHEN 't_stsd' THEN [ttdpur401200].[t_stsd] END,
     CASE @OrderBy WHEN 't_stsd DESC' THEN [ttdpur401200].[t_stsd] END DESC,
     CASE @OrderBy WHEN 't_vryn' THEN [ttdpur401200].[t_vryn] END,
     CASE @OrderBy WHEN 't_vryn DESC' THEN [ttdpur401200].[t_vryn] END DESC,
     CASE @OrderBy WHEN 't_invn' THEN [ttdpur401200].[t_invn] END,
     CASE @OrderBy WHEN 't_invn DESC' THEN [ttdpur401200].[t_invn] END DESC,
     CASE @OrderBy WHEN 't_invd' THEN [ttdpur401200].[t_invd] END,
     CASE @OrderBy WHEN 't_invd DESC' THEN [ttdpur401200].[t_invd] END DESC,
     CASE @OrderBy WHEN 't_copr_1' THEN [ttdpur401200].[t_copr_1] END,
     CASE @OrderBy WHEN 't_copr_1 DESC' THEN [ttdpur401200].[t_copr_1] END DESC,
     CASE @OrderBy WHEN 't_copr_2' THEN [ttdpur401200].[t_copr_2] END,
     CASE @OrderBy WHEN 't_copr_2 DESC' THEN [ttdpur401200].[t_copr_2] END DESC,
     CASE @OrderBy WHEN 't_copr_3' THEN [ttdpur401200].[t_copr_3] END,
     CASE @OrderBy WHEN 't_copr_3 DESC' THEN [ttdpur401200].[t_copr_3] END DESC,
     CASE @OrderBy WHEN 't_coop_1' THEN [ttdpur401200].[t_coop_1] END,
     CASE @OrderBy WHEN 't_coop_1 DESC' THEN [ttdpur401200].[t_coop_1] END DESC,
     CASE @OrderBy WHEN 't_coop_2' THEN [ttdpur401200].[t_coop_2] END,
     CASE @OrderBy WHEN 't_coop_2 DESC' THEN [ttdpur401200].[t_coop_2] END DESC,
     CASE @OrderBy WHEN 't_coop_3' THEN [ttdpur401200].[t_coop_3] END,
     CASE @OrderBy WHEN 't_coop_3 DESC' THEN [ttdpur401200].[t_coop_3] END DESC,
     CASE @OrderBy WHEN 't_cpcp' THEN [ttdpur401200].[t_cpcp] END,
     CASE @OrderBy WHEN 't_cpcp DESC' THEN [ttdpur401200].[t_cpcp] END DESC,
     CASE @OrderBy WHEN 't_cwar' THEN [ttdpur401200].[t_cwar] END,
     CASE @OrderBy WHEN 't_cwar DESC' THEN [ttdpur401200].[t_cwar] END DESC,
     CASE @OrderBy WHEN 't_cadr' THEN [ttdpur401200].[t_cadr] END,
     CASE @OrderBy WHEN 't_cadr DESC' THEN [ttdpur401200].[t_cadr] END DESC,
     CASE @OrderBy WHEN 't_lsel' THEN [ttdpur401200].[t_lsel] END,
     CASE @OrderBy WHEN 't_lsel DESC' THEN [ttdpur401200].[t_lsel] END DESC,
     CASE @OrderBy WHEN 't_clot' THEN [ttdpur401200].[t_clot] END,
     CASE @OrderBy WHEN 't_clot DESC' THEN [ttdpur401200].[t_clot] END DESC,
     CASE @OrderBy WHEN 't_cprj' THEN [ttdpur401200].[t_cprj] END,
     CASE @OrderBy WHEN 't_cprj DESC' THEN [ttdpur401200].[t_cprj] END DESC,
     CASE @OrderBy WHEN 't_cspa' THEN [ttdpur401200].[t_cspa] END,
     CASE @OrderBy WHEN 't_cspa DESC' THEN [ttdpur401200].[t_cspa] END DESC,
     CASE @OrderBy WHEN 't_cact' THEN [ttdpur401200].[t_cact] END,
     CASE @OrderBy WHEN 't_cact DESC' THEN [ttdpur401200].[t_cact] END DESC,
     CASE @OrderBy WHEN 't_cstl' THEN [ttdpur401200].[t_cstl] END,
     CASE @OrderBy WHEN 't_cstl DESC' THEN [ttdpur401200].[t_cstl] END DESC,
     CASE @OrderBy WHEN 't_ccco' THEN [ttdpur401200].[t_ccco] END,
     CASE @OrderBy WHEN 't_ccco DESC' THEN [ttdpur401200].[t_ccco] END DESC,
     CASE @OrderBy WHEN 't_ctrj' THEN [ttdpur401200].[t_ctrj] END,
     CASE @OrderBy WHEN 't_ctrj DESC' THEN [ttdpur401200].[t_ctrj] END DESC,
     CASE @OrderBy WHEN 't_akcd' THEN [ttdpur401200].[t_akcd] END,
     CASE @OrderBy WHEN 't_akcd DESC' THEN [ttdpur401200].[t_akcd] END DESC,
     CASE @OrderBy WHEN 't_cfrw' THEN [ttdpur401200].[t_cfrw] END,
     CASE @OrderBy WHEN 't_cfrw DESC' THEN [ttdpur401200].[t_cfrw] END DESC,
     CASE @OrderBy WHEN 't_crbn' THEN [ttdpur401200].[t_crbn] END,
     CASE @OrderBy WHEN 't_crbn DESC' THEN [ttdpur401200].[t_crbn] END DESC,
     CASE @OrderBy WHEN 't_clyn' THEN [ttdpur401200].[t_clyn] END,
     CASE @OrderBy WHEN 't_clyn DESC' THEN [ttdpur401200].[t_clyn] END DESC,
     CASE @OrderBy WHEN 't_cpva' THEN [ttdpur401200].[t_cpva] END,
     CASE @OrderBy WHEN 't_cpva DESC' THEN [ttdpur401200].[t_cpva] END DESC,
     CASE @OrderBy WHEN 't_crcd' THEN [ttdpur401200].[t_crcd] END,
     CASE @OrderBy WHEN 't_crcd DESC' THEN [ttdpur401200].[t_crcd] END DESC,
     CASE @OrderBy WHEN 't_ctcd' THEN [ttdpur401200].[t_ctcd] END,
     CASE @OrderBy WHEN 't_ctcd DESC' THEN [ttdpur401200].[t_ctcd] END DESC,
     CASE @OrderBy WHEN 't_cosn' THEN [ttdpur401200].[t_cosn] END,
     CASE @OrderBy WHEN 't_cosn DESC' THEN [ttdpur401200].[t_cosn] END DESC,
     CASE @OrderBy WHEN 't_qiiv' THEN [ttdpur401200].[t_qiiv] END,
     CASE @OrderBy WHEN 't_qiiv DESC' THEN [ttdpur401200].[t_qiiv] END DESC,
     CASE @OrderBy WHEN 't_iamt' THEN [ttdpur401200].[t_iamt] END,
     CASE @OrderBy WHEN 't_iamt DESC' THEN [ttdpur401200].[t_iamt] END DESC,
     CASE @OrderBy WHEN 't_comm' THEN [ttdpur401200].[t_comm] END,
     CASE @OrderBy WHEN 't_comm DESC' THEN [ttdpur401200].[t_comm] END DESC,
     CASE @OrderBy WHEN 't_appr' THEN [ttdpur401200].[t_appr] END,
     CASE @OrderBy WHEN 't_appr DESC' THEN [ttdpur401200].[t_appr] END DESC,
     CASE @OrderBy WHEN 't_ccty' THEN [ttdpur401200].[t_ccty] END,
     CASE @OrderBy WHEN 't_ccty DESC' THEN [ttdpur401200].[t_ccty] END DESC,
     CASE @OrderBy WHEN 't_cvat' THEN [ttdpur401200].[t_cvat] END,
     CASE @OrderBy WHEN 't_cvat DESC' THEN [ttdpur401200].[t_cvat] END DESC,
     CASE @OrderBy WHEN 't_bptc' THEN [ttdpur401200].[t_bptc] END,
     CASE @OrderBy WHEN 't_bptc DESC' THEN [ttdpur401200].[t_bptc] END DESC,
     CASE @OrderBy WHEN 't_exmt' THEN [ttdpur401200].[t_exmt] END,
     CASE @OrderBy WHEN 't_exmt DESC' THEN [ttdpur401200].[t_exmt] END DESC,
     CASE @OrderBy WHEN 't_ceno' THEN [ttdpur401200].[t_ceno] END,
     CASE @OrderBy WHEN 't_ceno DESC' THEN [ttdpur401200].[t_ceno] END DESC,
     CASE @OrderBy WHEN 't_rcod' THEN [ttdpur401200].[t_rcod] END,
     CASE @OrderBy WHEN 't_rcod DESC' THEN [ttdpur401200].[t_rcod] END DESC,
     CASE @OrderBy WHEN 't_bpcl' THEN [ttdpur401200].[t_bpcl] END,
     CASE @OrderBy WHEN 't_bpcl DESC' THEN [ttdpur401200].[t_bpcl] END DESC,
     CASE @OrderBy WHEN 't_taxp' THEN [ttdpur401200].[t_taxp] END,
     CASE @OrderBy WHEN 't_taxp DESC' THEN [ttdpur401200].[t_taxp] END DESC,
     CASE @OrderBy WHEN 't_gefo' THEN [ttdpur401200].[t_gefo] END,
     CASE @OrderBy WHEN 't_gefo DESC' THEN [ttdpur401200].[t_gefo] END DESC,
     CASE @OrderBy WHEN 't_ldat' THEN [ttdpur401200].[t_ldat] END,
     CASE @OrderBy WHEN 't_ldat DESC' THEN [ttdpur401200].[t_ldat] END DESC,
     CASE @OrderBy WHEN 't_serv' THEN [ttdpur401200].[t_serv] END,
     CASE @OrderBy WHEN 't_serv DESC' THEN [ttdpur401200].[t_serv] END DESC,
     CASE @OrderBy WHEN 't_casi' THEN [ttdpur401200].[t_casi] END,
     CASE @OrderBy WHEN 't_casi DESC' THEN [ttdpur401200].[t_casi] END DESC,
     CASE @OrderBy WHEN 't_ptpe' THEN [ttdpur401200].[t_ptpe] END,
     CASE @OrderBy WHEN 't_ptpe DESC' THEN [ttdpur401200].[t_ptpe] END DESC,
     CASE @OrderBy WHEN 't_glco' THEN [ttdpur401200].[t_glco] END,
     CASE @OrderBy WHEN 't_glco DESC' THEN [ttdpur401200].[t_glco] END DESC,
     CASE @OrderBy WHEN 't_sbim' THEN [ttdpur401200].[t_sbim] END,
     CASE @OrderBy WHEN 't_sbim DESC' THEN [ttdpur401200].[t_sbim] END DESC,
     CASE @OrderBy WHEN 't_paft' THEN [ttdpur401200].[t_paft] END,
     CASE @OrderBy WHEN 't_paft DESC' THEN [ttdpur401200].[t_paft] END DESC,
     CASE @OrderBy WHEN 't_sbmt' THEN [ttdpur401200].[t_sbmt] END,
     CASE @OrderBy WHEN 't_sbmt DESC' THEN [ttdpur401200].[t_sbmt] END DESC,
     CASE @OrderBy WHEN 't_cuva' THEN [ttdpur401200].[t_cuva] END,
     CASE @OrderBy WHEN 't_cuva DESC' THEN [ttdpur401200].[t_cuva] END DESC,
     CASE @OrderBy WHEN 't_cono' THEN [ttdpur401200].[t_cono] END,
     CASE @OrderBy WHEN 't_cono DESC' THEN [ttdpur401200].[t_cono] END DESC,
     CASE @OrderBy WHEN 't_cpon' THEN [ttdpur401200].[t_cpon] END,
     CASE @OrderBy WHEN 't_cpon DESC' THEN [ttdpur401200].[t_cpon] END DESC,
     CASE @OrderBy WHEN 't_ccof' THEN [ttdpur401200].[t_ccof] END,
     CASE @OrderBy WHEN 't_ccof DESC' THEN [ttdpur401200].[t_ccof] END DESC,
     CASE @OrderBy WHEN 't_cnig' THEN [ttdpur401200].[t_cnig] END,
     CASE @OrderBy WHEN 't_cnig DESC' THEN [ttdpur401200].[t_cnig] END DESC,
     CASE @OrderBy WHEN 't_paya' THEN [ttdpur401200].[t_paya] END,
     CASE @OrderBy WHEN 't_paya DESC' THEN [ttdpur401200].[t_paya] END DESC,
     CASE @OrderBy WHEN 't_cpay' THEN [ttdpur401200].[t_cpay] END,
     CASE @OrderBy WHEN 't_cpay DESC' THEN [ttdpur401200].[t_cpay] END DESC,
     CASE @OrderBy WHEN 't_cdec' THEN [ttdpur401200].[t_cdec] END,
     CASE @OrderBy WHEN 't_cdec DESC' THEN [ttdpur401200].[t_cdec] END DESC,
     CASE @OrderBy WHEN 't_ptpa' THEN [ttdpur401200].[t_ptpa] END,
     CASE @OrderBy WHEN 't_ptpa DESC' THEN [ttdpur401200].[t_ptpa] END DESC,
     CASE @OrderBy WHEN 't_pmnt' THEN [ttdpur401200].[t_pmnt] END,
     CASE @OrderBy WHEN 't_pmnt DESC' THEN [ttdpur401200].[t_pmnt] END DESC,
     CASE @OrderBy WHEN 't_pmni' THEN [ttdpur401200].[t_pmni] END,
     CASE @OrderBy WHEN 't_pmni DESC' THEN [ttdpur401200].[t_pmni] END DESC,
     CASE @OrderBy WHEN 't_pmnd' THEN [ttdpur401200].[t_pmnd] END,
     CASE @OrderBy WHEN 't_pmnd DESC' THEN [ttdpur401200].[t_pmnd] END DESC,
     CASE @OrderBy WHEN 't_owns' THEN [ttdpur401200].[t_owns] END,
     CASE @OrderBy WHEN 't_owns DESC' THEN [ttdpur401200].[t_owns] END DESC,
     CASE @OrderBy WHEN 't_lccl' THEN [ttdpur401200].[t_lccl] END,
     CASE @OrderBy WHEN 't_lccl DESC' THEN [ttdpur401200].[t_lccl] END DESC,
     CASE @OrderBy WHEN 't_spcn' THEN [ttdpur401200].[t_spcn] END,
     CASE @OrderBy WHEN 't_spcn DESC' THEN [ttdpur401200].[t_spcn] END DESC,
     CASE @OrderBy WHEN 't_bgxc' THEN [ttdpur401200].[t_bgxc] END,
     CASE @OrderBy WHEN 't_bgxc DESC' THEN [ttdpur401200].[t_bgxc] END DESC,
     CASE @OrderBy WHEN 't_cpcl' THEN [ttdpur401200].[t_cpcl] END,
     CASE @OrderBy WHEN 't_cpcl DESC' THEN [ttdpur401200].[t_cpcl] END DESC,
     CASE @OrderBy WHEN 't_cpln' THEN [ttdpur401200].[t_cpln] END,
     CASE @OrderBy WHEN 't_cpln DESC' THEN [ttdpur401200].[t_cpln] END DESC,
     CASE @OrderBy WHEN 't_csgp' THEN [ttdpur401200].[t_csgp] END,
     CASE @OrderBy WHEN 't_csgp DESC' THEN [ttdpur401200].[t_csgp] END DESC,
     CASE @OrderBy WHEN 't_acti' THEN [ttdpur401200].[t_acti] END,
     CASE @OrderBy WHEN 't_acti DESC' THEN [ttdpur401200].[t_acti] END DESC,
     CASE @OrderBy WHEN 't_pmsk' THEN [ttdpur401200].[t_pmsk] END,
     CASE @OrderBy WHEN 't_pmsk DESC' THEN [ttdpur401200].[t_pmsk] END DESC,
     CASE @OrderBy WHEN 't_rnso_l' THEN [ttdpur401200].[t_rnso_l] END,
     CASE @OrderBy WHEN 't_rnso_l DESC' THEN [ttdpur401200].[t_rnso_l] END DESC,
     CASE @OrderBy WHEN 't_rnsb_l' THEN [ttdpur401200].[t_rnsb_l] END,
     CASE @OrderBy WHEN 't_rnsb_l DESC' THEN [ttdpur401200].[t_rnsb_l] END DESC,
     CASE @OrderBy WHEN 't_ecif_l' THEN [ttdpur401200].[t_ecif_l] END,
     CASE @OrderBy WHEN 't_ecif_l DESC' THEN [ttdpur401200].[t_ecif_l] END DESC,
     CASE @OrderBy WHEN 't_assv_l' THEN [ttdpur401200].[t_assv_l] END,
     CASE @OrderBy WHEN 't_assv_l DESC' THEN [ttdpur401200].[t_assv_l] END DESC,
     CASE @OrderBy WHEN 't_elco_l' THEN [ttdpur401200].[t_elco_l] END,
     CASE @OrderBy WHEN 't_elco_l DESC' THEN [ttdpur401200].[t_elco_l] END DESC,
     CASE @OrderBy WHEN 't_ihsn_l' THEN [ttdpur401200].[t_ihsn_l] END,
     CASE @OrderBy WHEN 't_ihsn_l DESC' THEN [ttdpur401200].[t_ihsn_l] END DESC,
     CASE @OrderBy WHEN 't_mrpo_l' THEN [ttdpur401200].[t_mrpo_l] END,
     CASE @OrderBy WHEN 't_mrpo_l DESC' THEN [ttdpur401200].[t_mrpo_l] END DESC,
     CASE @OrderBy WHEN 't_iexb_l' THEN [ttdpur401200].[t_iexb_l] END,
     CASE @OrderBy WHEN 't_iexb_l DESC' THEN [ttdpur401200].[t_iexb_l] END DESC,
     CASE @OrderBy WHEN 't_icen_l' THEN [ttdpur401200].[t_icen_l] END,
     CASE @OrderBy WHEN 't_icen_l DESC' THEN [ttdpur401200].[t_icen_l] END DESC,
     CASE @OrderBy WHEN 't_imca_l' THEN [ttdpur401200].[t_imca_l] END,
     CASE @OrderBy WHEN 't_imca_l DESC' THEN [ttdpur401200].[t_imca_l] END DESC,
     CASE @OrderBy WHEN 't_exca_l' THEN [ttdpur401200].[t_exca_l] END,
     CASE @OrderBy WHEN 't_exca_l DESC' THEN [ttdpur401200].[t_exca_l] END DESC,
     CASE @OrderBy WHEN 't_mrpe_l' THEN [ttdpur401200].[t_mrpe_l] END,
     CASE @OrderBy WHEN 't_mrpe_l DESC' THEN [ttdpur401200].[t_mrpe_l] END DESC,
     CASE @OrderBy WHEN 't_hcod_l' THEN [ttdpur401200].[t_hcod_l] END,
     CASE @OrderBy WHEN 't_hcod_l DESC' THEN [ttdpur401200].[t_hcod_l] END DESC,
     CASE @OrderBy WHEN 't_cenv_l' THEN [ttdpur401200].[t_cenv_l] END,
     CASE @OrderBy WHEN 't_cenv_l DESC' THEN [ttdpur401200].[t_cenv_l] END DESC,
     CASE @OrderBy WHEN 't_icat_l' THEN [ttdpur401200].[t_icat_l] END,
     CASE @OrderBy WHEN 't_icat_l DESC' THEN [ttdpur401200].[t_icat_l] END DESC,
     CASE @OrderBy WHEN 't_asoe_l' THEN [ttdpur401200].[t_asoe_l] END,
     CASE @OrderBy WHEN 't_asoe_l DESC' THEN [ttdpur401200].[t_asoe_l] END DESC,
     CASE @OrderBy WHEN 't_asve_l' THEN [ttdpur401200].[t_asve_l] END,
     CASE @OrderBy WHEN 't_asve_l DESC' THEN [ttdpur401200].[t_asve_l] END DESC,
     CASE @OrderBy WHEN 't_dise_l' THEN [ttdpur401200].[t_dise_l] END,
     CASE @OrderBy WHEN 't_dise_l DESC' THEN [ttdpur401200].[t_dise_l] END DESC,
     CASE @OrderBy WHEN 't_fase_l' THEN [ttdpur401200].[t_fase_l] END,
     CASE @OrderBy WHEN 't_fase_l DESC' THEN [ttdpur401200].[t_fase_l] END DESC,
     CASE @OrderBy WHEN 't_asov_l' THEN [ttdpur401200].[t_asov_l] END,
     CASE @OrderBy WHEN 't_asov_l DESC' THEN [ttdpur401200].[t_asov_l] END DESC,
     CASE @OrderBy WHEN 't_asvv_l' THEN [ttdpur401200].[t_asvv_l] END,
     CASE @OrderBy WHEN 't_asvv_l DESC' THEN [ttdpur401200].[t_asvv_l] END DESC,
     CASE @OrderBy WHEN 't_disv_l' THEN [ttdpur401200].[t_disv_l] END,
     CASE @OrderBy WHEN 't_disv_l DESC' THEN [ttdpur401200].[t_disv_l] END DESC,
     CASE @OrderBy WHEN 't_fasv_l' THEN [ttdpur401200].[t_fasv_l] END,
     CASE @OrderBy WHEN 't_fasv_l DESC' THEN [ttdpur401200].[t_fasv_l] END DESC,
     CASE @OrderBy WHEN 't_asos_l' THEN [ttdpur401200].[t_asos_l] END,
     CASE @OrderBy WHEN 't_asos_l DESC' THEN [ttdpur401200].[t_asos_l] END DESC,
     CASE @OrderBy WHEN 't_asvs_l' THEN [ttdpur401200].[t_asvs_l] END,
     CASE @OrderBy WHEN 't_asvs_l DESC' THEN [ttdpur401200].[t_asvs_l] END DESC,
     CASE @OrderBy WHEN 't_diss_l' THEN [ttdpur401200].[t_diss_l] END,
     CASE @OrderBy WHEN 't_diss_l DESC' THEN [ttdpur401200].[t_diss_l] END DESC,
     CASE @OrderBy WHEN 't_fass_l' THEN [ttdpur401200].[t_fass_l] END,
     CASE @OrderBy WHEN 't_fass_l DESC' THEN [ttdpur401200].[t_fass_l] END DESC,
     CASE @OrderBy WHEN 't_iecc_l' THEN [ttdpur401200].[t_iecc_l] END,
     CASE @OrderBy WHEN 't_iecc_l DESC' THEN [ttdpur401200].[t_iecc_l] END DESC,
     CASE @OrderBy WHEN 't_mrpv_l' THEN [ttdpur401200].[t_mrpv_l] END,
     CASE @OrderBy WHEN 't_mrpv_l DESC' THEN [ttdpur401200].[t_mrpv_l] END DESC,
     CASE @OrderBy WHEN 't_mrps_l' THEN [ttdpur401200].[t_mrps_l] END,
     CASE @OrderBy WHEN 't_mrps_l DESC' THEN [ttdpur401200].[t_mrps_l] END DESC,
     CASE @OrderBy WHEN 't_reno_l' THEN [ttdpur401200].[t_reno_l] END,
     CASE @OrderBy WHEN 't_reno_l DESC' THEN [ttdpur401200].[t_reno_l] END DESC,
     CASE @OrderBy WHEN 't_rcln_l' THEN [ttdpur401200].[t_rcln_l] END,
     CASE @OrderBy WHEN 't_rcln_l DESC' THEN [ttdpur401200].[t_rcln_l] END DESC,
     CASE @OrderBy WHEN 't_mrpi_l' THEN [ttdpur401200].[t_mrpi_l] END,
     CASE @OrderBy WHEN 't_mrpi_l DESC' THEN [ttdpur401200].[t_mrpi_l] END DESC,
     CASE @OrderBy WHEN 't_ocim_l' THEN [ttdpur401200].[t_ocim_l] END,
     CASE @OrderBy WHEN 't_ocim_l DESC' THEN [ttdpur401200].[t_ocim_l] END DESC,
     CASE @OrderBy WHEN 't_ocio_l' THEN [ttdpur401200].[t_ocio_l] END,
     CASE @OrderBy WHEN 't_ocio_l DESC' THEN [ttdpur401200].[t_ocio_l] END DESC,
     CASE @OrderBy WHEN 't_extx_l' THEN [ttdpur401200].[t_extx_l] END,
     CASE @OrderBy WHEN 't_extx_l DESC' THEN [ttdpur401200].[t_extx_l] END DESC,
     CASE @OrderBy WHEN 't_cltx_l' THEN [ttdpur401200].[t_cltx_l] END,
     CASE @OrderBy WHEN 't_cltx_l DESC' THEN [ttdpur401200].[t_cltx_l] END DESC,
     CASE @OrderBy WHEN 't_lacm_l' THEN [ttdpur401200].[t_lacm_l] END,
     CASE @OrderBy WHEN 't_lacm_l DESC' THEN [ttdpur401200].[t_lacm_l] END DESC,
     CASE @OrderBy WHEN 't_tase_l' THEN [ttdpur401200].[t_tase_l] END,
     CASE @OrderBy WHEN 't_tase_l DESC' THEN [ttdpur401200].[t_tase_l] END DESC,
     CASE @OrderBy WHEN 't_tasv_l' THEN [ttdpur401200].[t_tasv_l] END,
     CASE @OrderBy WHEN 't_tasv_l DESC' THEN [ttdpur401200].[t_tasv_l] END DESC,
     CASE @OrderBy WHEN 't_tass_l' THEN [ttdpur401200].[t_tass_l] END,
     CASE @OrderBy WHEN 't_tass_l DESC' THEN [ttdpur401200].[t_tass_l] END DESC,
     CASE @OrderBy WHEN 't_uiac_l' THEN [ttdpur401200].[t_uiac_l] END,
     CASE @OrderBy WHEN 't_uiac_l DESC' THEN [ttdpur401200].[t_uiac_l] END DESC,
     CASE @OrderBy WHEN 't_uaig_l' THEN [ttdpur401200].[t_uaig_l] END,
     CASE @OrderBy WHEN 't_uaig_l DESC' THEN [ttdpur401200].[t_uaig_l] END DESC,
     CASE @OrderBy WHEN 't_txin_l' THEN [ttdpur401200].[t_txin_l] END,
     CASE @OrderBy WHEN 't_txin_l DESC' THEN [ttdpur401200].[t_txin_l] END DESC,
     CASE @OrderBy WHEN 't_gsub_l' THEN [ttdpur401200].[t_gsub_l] END,
     CASE @OrderBy WHEN 't_gsub_l DESC' THEN [ttdpur401200].[t_gsub_l] END DESC,
     CASE @OrderBy WHEN 't_txta' THEN [ttdpur401200].[t_txta] END,
     CASE @OrderBy WHEN 't_txta DESC' THEN [ttdpur401200].[t_txta] END DESC,
     CASE @OrderBy WHEN 't_btx1' THEN [ttdpur401200].[t_btx1] END,
     CASE @OrderBy WHEN 't_btx1 DESC' THEN [ttdpur401200].[t_btx1] END DESC,
     CASE @OrderBy WHEN 't_btx2' THEN [ttdpur401200].[t_btx2] END,
     CASE @OrderBy WHEN 't_btx2 DESC' THEN [ttdpur401200].[t_btx2] END DESC,
     CASE @OrderBy WHEN 't_cdf_ldat' THEN [ttdpur401200].[t_cdf_ldat] END,
     CASE @OrderBy WHEN 't_cdf_ldat DESC' THEN [ttdpur401200].[t_cdf_ldat] END DESC,
     CASE @OrderBy WHEN 't_Refcntd' THEN [ttdpur401200].[t_Refcntd] END,
     CASE @OrderBy WHEN 't_Refcntd DESC' THEN [ttdpur401200].[t_Refcntd] END DESC,
     CASE @OrderBy WHEN 't_Refcntu' THEN [ttdpur401200].[t_Refcntu] END,
     CASE @OrderBy WHEN 't_Refcntu DESC' THEN [ttdpur401200].[t_Refcntu] END DESC,
     CASE @OrderBy WHEN 't_asog_l' THEN [ttdpur401200].[t_asog_l] END,
     CASE @OrderBy WHEN 't_asog_l DESC' THEN [ttdpur401200].[t_asog_l] END DESC,
     CASE @OrderBy WHEN 't_asoi_l' THEN [ttdpur401200].[t_asoi_l] END,
     CASE @OrderBy WHEN 't_asoi_l DESC' THEN [ttdpur401200].[t_asoi_l] END DESC,
     CASE @OrderBy WHEN 't_asvg_l' THEN [ttdpur401200].[t_asvg_l] END,
     CASE @OrderBy WHEN 't_asvg_l DESC' THEN [ttdpur401200].[t_asvg_l] END DESC,
     CASE @OrderBy WHEN 't_atfr_l' THEN [ttdpur401200].[t_atfr_l] END,
     CASE @OrderBy WHEN 't_atfr_l DESC' THEN [ttdpur401200].[t_atfr_l] END DESC,
     CASE @OrderBy WHEN 't_gsta_l' THEN [ttdpur401200].[t_gsta_l] END,
     CASE @OrderBy WHEN 't_gsta_l DESC' THEN [ttdpur401200].[t_gsta_l] END DESC,
     CASE @OrderBy WHEN 't_tasg_l' THEN [ttdpur401200].[t_tasg_l] END,
     CASE @OrderBy WHEN 't_tasg_l DESC' THEN [ttdpur401200].[t_tasg_l] END DESC 
  SET @RecordCount = @@RowCount
  GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sptdpur401AutoCompleteList]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sptdpur401AutoCompleteList]
GO
 
CREATE PROCEDURE [dbo].[sptdpur401AutoCompleteList]
  @DF_t_orno VarChar(9),
  @LoginID NVarChar(8),
  @Prefix NVarChar(250),
  @Records Int,
  @ByCode Int 
  AS 
  BEGIN 
  DECLARE @Prefix1 VarChar(260)
  SET @Prefix1 = LOWER(@Prefix) + '%'
  DECLARE @LGSQL VarChar(8000)
  SET @LGSQL = 'SELECT TOP (' + STR(@Records) + ') ' 
  SET @LGSQL = @LGSQL + ' [ttdpur401200].[t_item]' 
  SET @LGSQL = @LGSQL + ',[ttdpur401200].[t_orno]' 
  SET @LGSQL = @LGSQL + ',[ttdpur401200].[t_pono]' 
  SET @LGSQL = @LGSQL + ',[ttdpur401200].[t_sqnb]' 
  SET @LGSQL = @LGSQL + ' FROM [ttdpur401200] ' 
  SET @LGSQL = @LGSQL + ' WHERE 1 = 1 ' 
  SET @LGSQL = @LGSQL + ' AND (LOWER(ISNULL([ttdpur401200].[t_orno],'''')) LIKE ''' + @Prefix1 + ''''
  SET @LGSQL = @LGSQL + ' OR LTRIM(STR(ISNULL([ttdpur401200].[t_pono],0))) LIKE ''' + @Prefix1 + ''''
  SET @LGSQL = @LGSQL + ' OR LTRIM(STR(ISNULL([ttdpur401200].[t_sqnb],0))) LIKE ''' + @Prefix1 + ''''
  SET @LGSQL = @LGSQL + ' OR LOWER(ISNULL([ttdpur401200].[t_item],'''')) LIKE ''' + @Prefix1 + ''''
  SET @LGSQL = @LGSQL + ')' 
  IF (@DF_t_orno > '') 
    SET @LGSQL = @LGSQL + ' AND LOWER([ttdpur401200].[t_orno]) = ''' + LOWER(@DF_t_orno) + ''''
  
  EXEC (@LGSQL)
  END 
  GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sptdpur401SelectByID]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sptdpur401SelectByID]
GO
 
CREATE PROCEDURE [dbo].[sptdpur401SelectByID]
  @LoginID NVarChar(8),
  @t_orno VarChar(9),
  @t_pono Int,
  @t_sqnb Int 
  AS
  SELECT
    [ttdpur401200].*  
  FROM [ttdpur401200] 
  WHERE
  [ttdpur401200].[t_orno] = @t_orno
  AND [ttdpur401200].[t_pono] = @t_pono
  AND [ttdpur401200].[t_sqnb] = @t_sqnb
  GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sptdpur401SelectListSearch]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sptdpur401SelectListSearch]
GO
 
CREATE PROCEDURE [dbo].[sptdpur401SelectListSearch]
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
 ,t_orno VarChar(9) NOT NULL
 ,t_pono Int NOT NULL
 ,t_sqnb Int NOT NULL
  )
  INSERT INTO #PageIndex (t_orno, t_pono, t_sqnb)
  SELECT [ttdpur401200].[t_orno], [ttdpur401200].[t_pono], [ttdpur401200].[t_sqnb] FROM [ttdpur401200]
 WHERE  
   ( 
         LOWER(ISNULL([ttdpur401200].[t_orno],'')) LIKE @KeyWord1
     OR STR(ISNULL([ttdpur401200].[t_pono], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttdpur401200].[t_sqnb], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttdpur401200].[t_corg], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttdpur401200].[t_oltp], 0)) LIKE @KeyWord1
     OR LOWER(ISNULL([ttdpur401200].[t_otbp],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ttdpur401200].[t_sfbp],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ttdpur401200].[t_sfad],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ttdpur401200].[t_sfcn],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ttdpur401200].[t_sfwh],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ttdpur401200].[t_item],'')) LIKE @KeyWord1
     OR STR(ISNULL([ttdpur401200].[t_effn], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttdpur401200].[t_sdsc], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttdpur401200].[t_crrf], 0)) LIKE @KeyWord1
     OR LOWER(ISNULL([ttdpur401200].[t_citt],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ttdpur401200].[t_crit],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ttdpur401200].[t_mpnr],'')) LIKE @KeyWord1
     OR STR(ISNULL([ttdpur401200].[t_subc], 0)) LIKE @KeyWord1
     OR LOWER(ISNULL([ttdpur401200].[t_mpsn],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ttdpur401200].[t_cmnf],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ttdpur401200].[t_mitm],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ttdpur401200].[t_revi],'')) LIKE @KeyWord1
     OR STR(ISNULL([ttdpur401200].[t_btsp], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttdpur401200].[t_qual], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttdpur401200].[t_qoor], 0)) LIKE @KeyWord1
     OR LOWER(ISNULL([ttdpur401200].[t_cuqp],'')) LIKE @KeyWord1
     OR STR(ISNULL([ttdpur401200].[t_cvqp], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttdpur401200].[t_leng], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttdpur401200].[t_widt], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttdpur401200].[t_thic], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttdpur401200].[t_pric], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttdpur401200].[t_porg], 0)) LIKE @KeyWord1
     OR LOWER(ISNULL([ttdpur401200].[t_pmde],'')) LIKE @KeyWord1
     OR STR(ISNULL([ttdpur401200].[t_pmse], 0)) LIKE @KeyWord1
     OR LOWER(ISNULL([ttdpur401200].[t_cupp],'')) LIKE @KeyWord1
     OR STR(ISNULL([ttdpur401200].[t_cvpp], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttdpur401200].[t_ldam_1], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttdpur401200].[t_ldam_2], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttdpur401200].[t_ldam_3], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttdpur401200].[t_ldam_4], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttdpur401200].[t_ldam_5], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttdpur401200].[t_ldam_6], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttdpur401200].[t_ldam_7], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttdpur401200].[t_ldam_8], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttdpur401200].[t_ldam_9], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttdpur401200].[t_ldam_10], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttdpur401200].[t_ldam_11], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttdpur401200].[t_dorg_1], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttdpur401200].[t_dorg_2], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttdpur401200].[t_dorg_3], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttdpur401200].[t_dorg_4], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttdpur401200].[t_dorg_5], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttdpur401200].[t_dorg_6], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttdpur401200].[t_dorg_7], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttdpur401200].[t_dorg_8], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttdpur401200].[t_dorg_9], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttdpur401200].[t_dorg_10], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttdpur401200].[t_dorg_11], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttdpur401200].[t_dmty_1], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttdpur401200].[t_dmty_2], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttdpur401200].[t_dmty_3], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttdpur401200].[t_dmty_4], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttdpur401200].[t_dmty_5], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttdpur401200].[t_dmty_6], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttdpur401200].[t_dmty_7], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttdpur401200].[t_dmty_8], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttdpur401200].[t_dmty_9], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttdpur401200].[t_dmty_10], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttdpur401200].[t_dmty_11], 0)) LIKE @KeyWord1
     OR LOWER(ISNULL([ttdpur401200].[t_dmde_1],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ttdpur401200].[t_dmde_2],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ttdpur401200].[t_dmde_3],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ttdpur401200].[t_dmde_4],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ttdpur401200].[t_dmde_5],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ttdpur401200].[t_dmde_6],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ttdpur401200].[t_dmde_7],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ttdpur401200].[t_dmde_8],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ttdpur401200].[t_dmde_9],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ttdpur401200].[t_dmde_10],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ttdpur401200].[t_dmde_11],'')) LIKE @KeyWord1
     OR STR(ISNULL([ttdpur401200].[t_dmse_1], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttdpur401200].[t_dmse_2], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttdpur401200].[t_dmse_3], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttdpur401200].[t_dmse_4], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttdpur401200].[t_dmse_5], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttdpur401200].[t_dmse_6], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttdpur401200].[t_dmse_7], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttdpur401200].[t_dmse_8], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttdpur401200].[t_dmse_9], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttdpur401200].[t_dmse_10], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttdpur401200].[t_dmse_11], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttdpur401200].[t_dmth_1], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttdpur401200].[t_dmth_2], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttdpur401200].[t_dmth_3], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttdpur401200].[t_dmth_4], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttdpur401200].[t_dmth_5], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttdpur401200].[t_dmth_6], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttdpur401200].[t_dmth_7], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttdpur401200].[t_dmth_8], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttdpur401200].[t_dmth_9], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttdpur401200].[t_dmth_10], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttdpur401200].[t_dmth_11], 0)) LIKE @KeyWord1
     OR LOWER(ISNULL([ttdpur401200].[t_cdis_1],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ttdpur401200].[t_cdis_2],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ttdpur401200].[t_cdis_3],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ttdpur401200].[t_cdis_4],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ttdpur401200].[t_cdis_5],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ttdpur401200].[t_cdis_6],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ttdpur401200].[t_cdis_7],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ttdpur401200].[t_cdis_8],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ttdpur401200].[t_cdis_9],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ttdpur401200].[t_cdis_10],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ttdpur401200].[t_cdis_11],'')) LIKE @KeyWord1
     OR STR(ISNULL([ttdpur401200].[t_dtrm], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttdpur401200].[t_elgb], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttdpur401200].[t_stdc], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttdpur401200].[t_oamt], 0)) LIKE @KeyWord1
     OR LOWER(ISNULL([ttdpur401200].[t_rcno],'')) LIKE @KeyWord1
     OR STR(ISNULL([ttdpur401200].[t_rseq], 0)) LIKE @KeyWord1
     OR LOWER(ISNULL([ttdpur401200].[t_dino],'')) LIKE @KeyWord1
     OR STR(ISNULL([ttdpur401200].[t_qips], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttdpur401200].[t_qidl], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttdpur401200].[t_qiap], 0)) LIKE @KeyWord1
     OR LOWER(ISNULL([ttdpur401200].[t_crej],'')) LIKE @KeyWord1
     OR STR(ISNULL([ttdpur401200].[t_qirj], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttdpur401200].[t_qibo], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttdpur401200].[t_qbbc], 0)) LIKE @KeyWord1
     OR LOWER(ISNULL([ttdpur401200].[t_cubp],'')) LIKE @KeyWord1
     OR STR(ISNULL([ttdpur401200].[t_cvbp], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttdpur401200].[t_fire], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttdpur401200].[t_qibp], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttdpur401200].[t_ddon], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttdpur401200].[t_lseq], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttdpur401200].[t_pseq], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttdpur401200].[t_amld], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttdpur401200].[t_amod], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttdpur401200].[t_damt], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttdpur401200].[t_stsc], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttdpur401200].[t_stsd], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttdpur401200].[t_vryn], 0)) LIKE @KeyWord1
     OR LOWER(ISNULL([ttdpur401200].[t_invn],'')) LIKE @KeyWord1
     OR STR(ISNULL([ttdpur401200].[t_copr_1], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttdpur401200].[t_copr_2], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttdpur401200].[t_copr_3], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttdpur401200].[t_coop_1], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttdpur401200].[t_coop_2], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttdpur401200].[t_coop_3], 0)) LIKE @KeyWord1
     OR LOWER(ISNULL([ttdpur401200].[t_cpcp],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ttdpur401200].[t_cwar],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ttdpur401200].[t_cadr],'')) LIKE @KeyWord1
     OR STR(ISNULL([ttdpur401200].[t_lsel], 0)) LIKE @KeyWord1
     OR LOWER(ISNULL([ttdpur401200].[t_clot],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ttdpur401200].[t_cprj],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ttdpur401200].[t_cspa],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ttdpur401200].[t_cact],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ttdpur401200].[t_cstl],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ttdpur401200].[t_ccco],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ttdpur401200].[t_ctrj],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ttdpur401200].[t_akcd],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ttdpur401200].[t_cfrw],'')) LIKE @KeyWord1
     OR STR(ISNULL([ttdpur401200].[t_crbn], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttdpur401200].[t_clyn], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttdpur401200].[t_cpva], 0)) LIKE @KeyWord1
     OR LOWER(ISNULL([ttdpur401200].[t_crcd],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ttdpur401200].[t_ctcd],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ttdpur401200].[t_cosn],'')) LIKE @KeyWord1
     OR STR(ISNULL([ttdpur401200].[t_qiiv], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttdpur401200].[t_iamt], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttdpur401200].[t_comm], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttdpur401200].[t_appr], 0)) LIKE @KeyWord1
     OR LOWER(ISNULL([ttdpur401200].[t_ccty],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ttdpur401200].[t_cvat],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ttdpur401200].[t_bptc],'')) LIKE @KeyWord1
     OR STR(ISNULL([ttdpur401200].[t_exmt], 0)) LIKE @KeyWord1
     OR LOWER(ISNULL([ttdpur401200].[t_ceno],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ttdpur401200].[t_rcod],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ttdpur401200].[t_bpcl],'')) LIKE @KeyWord1
     OR STR(ISNULL([ttdpur401200].[t_taxp], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttdpur401200].[t_gefo], 0)) LIKE @KeyWord1
     OR LOWER(ISNULL([ttdpur401200].[t_serv],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ttdpur401200].[t_casi],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ttdpur401200].[t_ptpe],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ttdpur401200].[t_glco],'')) LIKE @KeyWord1
     OR STR(ISNULL([ttdpur401200].[t_sbim], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttdpur401200].[t_paft], 0)) LIKE @KeyWord1
     OR LOWER(ISNULL([ttdpur401200].[t_sbmt],'')) LIKE @KeyWord1
     OR STR(ISNULL([ttdpur401200].[t_cuva], 0)) LIKE @KeyWord1
     OR LOWER(ISNULL([ttdpur401200].[t_cono],'')) LIKE @KeyWord1
     OR STR(ISNULL([ttdpur401200].[t_cpon], 0)) LIKE @KeyWord1
     OR LOWER(ISNULL([ttdpur401200].[t_ccof],'')) LIKE @KeyWord1
     OR STR(ISNULL([ttdpur401200].[t_cnig], 0)) LIKE @KeyWord1
     OR LOWER(ISNULL([ttdpur401200].[t_paya],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ttdpur401200].[t_cpay],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ttdpur401200].[t_cdec],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ttdpur401200].[t_ptpa],'')) LIKE @KeyWord1
     OR STR(ISNULL([ttdpur401200].[t_pmnt], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttdpur401200].[t_pmni], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttdpur401200].[t_pmnd], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttdpur401200].[t_owns], 0)) LIKE @KeyWord1
     OR LOWER(ISNULL([ttdpur401200].[t_lccl],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ttdpur401200].[t_spcn],'')) LIKE @KeyWord1
     OR STR(ISNULL([ttdpur401200].[t_bgxc], 0)) LIKE @KeyWord1
     OR LOWER(ISNULL([ttdpur401200].[t_cpcl],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ttdpur401200].[t_cpln],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ttdpur401200].[t_csgp],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ttdpur401200].[t_acti],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ttdpur401200].[t_pmsk],'')) LIKE @KeyWord1
     OR STR(ISNULL([ttdpur401200].[t_rnso_l], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttdpur401200].[t_rnsb_l], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttdpur401200].[t_ecif_l], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttdpur401200].[t_assv_l], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttdpur401200].[t_elco_l], 0)) LIKE @KeyWord1
     OR LOWER(ISNULL([ttdpur401200].[t_ihsn_l],'')) LIKE @KeyWord1
     OR STR(ISNULL([ttdpur401200].[t_mrpo_l], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttdpur401200].[t_iexb_l], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttdpur401200].[t_icen_l], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttdpur401200].[t_imca_l], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttdpur401200].[t_exca_l], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttdpur401200].[t_mrpe_l], 0)) LIKE @KeyWord1
     OR LOWER(ISNULL([ttdpur401200].[t_hcod_l],'')) LIKE @KeyWord1
     OR STR(ISNULL([ttdpur401200].[t_cenv_l], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttdpur401200].[t_icat_l], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttdpur401200].[t_asoe_l], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttdpur401200].[t_asve_l], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttdpur401200].[t_fase_l], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttdpur401200].[t_asov_l], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttdpur401200].[t_asvv_l], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttdpur401200].[t_fasv_l], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttdpur401200].[t_asos_l], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttdpur401200].[t_asvs_l], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttdpur401200].[t_fass_l], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttdpur401200].[t_iecc_l], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttdpur401200].[t_mrpv_l], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttdpur401200].[t_mrps_l], 0)) LIKE @KeyWord1
     OR LOWER(ISNULL([ttdpur401200].[t_reno_l],'')) LIKE @KeyWord1
     OR STR(ISNULL([ttdpur401200].[t_rcln_l], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttdpur401200].[t_mrpi_l], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttdpur401200].[t_ocim_l], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttdpur401200].[t_ocio_l], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttdpur401200].[t_extx_l], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttdpur401200].[t_cltx_l], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttdpur401200].[t_lacm_l], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttdpur401200].[t_tase_l], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttdpur401200].[t_tasv_l], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttdpur401200].[t_tass_l], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttdpur401200].[t_uiac_l], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttdpur401200].[t_uaig_l], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttdpur401200].[t_txin_l], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttdpur401200].[t_gsub_l], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttdpur401200].[t_txta], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttdpur401200].[t_btx1], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttdpur401200].[t_btx2], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttdpur401200].[t_Refcntd], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttdpur401200].[t_Refcntu], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttdpur401200].[t_asog_l], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttdpur401200].[t_asoi_l], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttdpur401200].[t_asvg_l], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttdpur401200].[t_atfr_l], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttdpur401200].[t_gsta_l], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttdpur401200].[t_tasg_l], 0)) LIKE @KeyWord1
   ) 
  ORDER BY
     CASE @OrderBy WHEN 't_orno' THEN [ttdpur401200].[t_orno] END,
     CASE @OrderBy WHEN 't_orno DESC' THEN [ttdpur401200].[t_orno] END DESC,
     CASE @OrderBy WHEN 't_pono' THEN [ttdpur401200].[t_pono] END,
     CASE @OrderBy WHEN 't_pono DESC' THEN [ttdpur401200].[t_pono] END DESC,
     CASE @OrderBy WHEN 't_sqnb' THEN [ttdpur401200].[t_sqnb] END,
     CASE @OrderBy WHEN 't_sqnb DESC' THEN [ttdpur401200].[t_sqnb] END DESC,
     CASE @OrderBy WHEN 't_corg' THEN [ttdpur401200].[t_corg] END,
     CASE @OrderBy WHEN 't_corg DESC' THEN [ttdpur401200].[t_corg] END DESC,
     CASE @OrderBy WHEN 't_oltp' THEN [ttdpur401200].[t_oltp] END,
     CASE @OrderBy WHEN 't_oltp DESC' THEN [ttdpur401200].[t_oltp] END DESC,
     CASE @OrderBy WHEN 't_otbp' THEN [ttdpur401200].[t_otbp] END,
     CASE @OrderBy WHEN 't_otbp DESC' THEN [ttdpur401200].[t_otbp] END DESC,
     CASE @OrderBy WHEN 't_sfbp' THEN [ttdpur401200].[t_sfbp] END,
     CASE @OrderBy WHEN 't_sfbp DESC' THEN [ttdpur401200].[t_sfbp] END DESC,
     CASE @OrderBy WHEN 't_sfad' THEN [ttdpur401200].[t_sfad] END,
     CASE @OrderBy WHEN 't_sfad DESC' THEN [ttdpur401200].[t_sfad] END DESC,
     CASE @OrderBy WHEN 't_sfcn' THEN [ttdpur401200].[t_sfcn] END,
     CASE @OrderBy WHEN 't_sfcn DESC' THEN [ttdpur401200].[t_sfcn] END DESC,
     CASE @OrderBy WHEN 't_sfwh' THEN [ttdpur401200].[t_sfwh] END,
     CASE @OrderBy WHEN 't_sfwh DESC' THEN [ttdpur401200].[t_sfwh] END DESC,
     CASE @OrderBy WHEN 't_item' THEN [ttdpur401200].[t_item] END,
     CASE @OrderBy WHEN 't_item DESC' THEN [ttdpur401200].[t_item] END DESC,
     CASE @OrderBy WHEN 't_effn' THEN [ttdpur401200].[t_effn] END,
     CASE @OrderBy WHEN 't_effn DESC' THEN [ttdpur401200].[t_effn] END DESC,
     CASE @OrderBy WHEN 't_sdsc' THEN [ttdpur401200].[t_sdsc] END,
     CASE @OrderBy WHEN 't_sdsc DESC' THEN [ttdpur401200].[t_sdsc] END DESC,
     CASE @OrderBy WHEN 't_crrf' THEN [ttdpur401200].[t_crrf] END,
     CASE @OrderBy WHEN 't_crrf DESC' THEN [ttdpur401200].[t_crrf] END DESC,
     CASE @OrderBy WHEN 't_citt' THEN [ttdpur401200].[t_citt] END,
     CASE @OrderBy WHEN 't_citt DESC' THEN [ttdpur401200].[t_citt] END DESC,
     CASE @OrderBy WHEN 't_crit' THEN [ttdpur401200].[t_crit] END,
     CASE @OrderBy WHEN 't_crit DESC' THEN [ttdpur401200].[t_crit] END DESC,
     CASE @OrderBy WHEN 't_mpnr' THEN [ttdpur401200].[t_mpnr] END,
     CASE @OrderBy WHEN 't_mpnr DESC' THEN [ttdpur401200].[t_mpnr] END DESC,
     CASE @OrderBy WHEN 't_subc' THEN [ttdpur401200].[t_subc] END,
     CASE @OrderBy WHEN 't_subc DESC' THEN [ttdpur401200].[t_subc] END DESC,
     CASE @OrderBy WHEN 't_mpsn' THEN [ttdpur401200].[t_mpsn] END,
     CASE @OrderBy WHEN 't_mpsn DESC' THEN [ttdpur401200].[t_mpsn] END DESC,
     CASE @OrderBy WHEN 't_cmnf' THEN [ttdpur401200].[t_cmnf] END,
     CASE @OrderBy WHEN 't_cmnf DESC' THEN [ttdpur401200].[t_cmnf] END DESC,
     CASE @OrderBy WHEN 't_mitm' THEN [ttdpur401200].[t_mitm] END,
     CASE @OrderBy WHEN 't_mitm DESC' THEN [ttdpur401200].[t_mitm] END DESC,
     CASE @OrderBy WHEN 't_revi' THEN [ttdpur401200].[t_revi] END,
     CASE @OrderBy WHEN 't_revi DESC' THEN [ttdpur401200].[t_revi] END DESC,
     CASE @OrderBy WHEN 't_btsp' THEN [ttdpur401200].[t_btsp] END,
     CASE @OrderBy WHEN 't_btsp DESC' THEN [ttdpur401200].[t_btsp] END DESC,
     CASE @OrderBy WHEN 't_qual' THEN [ttdpur401200].[t_qual] END,
     CASE @OrderBy WHEN 't_qual DESC' THEN [ttdpur401200].[t_qual] END DESC,
     CASE @OrderBy WHEN 't_qoor' THEN [ttdpur401200].[t_qoor] END,
     CASE @OrderBy WHEN 't_qoor DESC' THEN [ttdpur401200].[t_qoor] END DESC,
     CASE @OrderBy WHEN 't_cuqp' THEN [ttdpur401200].[t_cuqp] END,
     CASE @OrderBy WHEN 't_cuqp DESC' THEN [ttdpur401200].[t_cuqp] END DESC,
     CASE @OrderBy WHEN 't_cvqp' THEN [ttdpur401200].[t_cvqp] END,
     CASE @OrderBy WHEN 't_cvqp DESC' THEN [ttdpur401200].[t_cvqp] END DESC,
     CASE @OrderBy WHEN 't_leng' THEN [ttdpur401200].[t_leng] END,
     CASE @OrderBy WHEN 't_leng DESC' THEN [ttdpur401200].[t_leng] END DESC,
     CASE @OrderBy WHEN 't_widt' THEN [ttdpur401200].[t_widt] END,
     CASE @OrderBy WHEN 't_widt DESC' THEN [ttdpur401200].[t_widt] END DESC,
     CASE @OrderBy WHEN 't_thic' THEN [ttdpur401200].[t_thic] END,
     CASE @OrderBy WHEN 't_thic DESC' THEN [ttdpur401200].[t_thic] END DESC,
     CASE @OrderBy WHEN 't_odat' THEN [ttdpur401200].[t_odat] END,
     CASE @OrderBy WHEN 't_odat DESC' THEN [ttdpur401200].[t_odat] END DESC,
     CASE @OrderBy WHEN 't_ddta' THEN [ttdpur401200].[t_ddta] END,
     CASE @OrderBy WHEN 't_ddta DESC' THEN [ttdpur401200].[t_ddta] END DESC,
     CASE @OrderBy WHEN 't_ddtb' THEN [ttdpur401200].[t_ddtb] END,
     CASE @OrderBy WHEN 't_ddtb DESC' THEN [ttdpur401200].[t_ddtb] END DESC,
     CASE @OrderBy WHEN 't_ddtc' THEN [ttdpur401200].[t_ddtc] END,
     CASE @OrderBy WHEN 't_ddtc DESC' THEN [ttdpur401200].[t_ddtc] END DESC,
     CASE @OrderBy WHEN 't_ddtd' THEN [ttdpur401200].[t_ddtd] END,
     CASE @OrderBy WHEN 't_ddtd DESC' THEN [ttdpur401200].[t_ddtd] END DESC,
     CASE @OrderBy WHEN 't_ddte' THEN [ttdpur401200].[t_ddte] END,
     CASE @OrderBy WHEN 't_ddte DESC' THEN [ttdpur401200].[t_ddte] END DESC,
     CASE @OrderBy WHEN 't_ddtf' THEN [ttdpur401200].[t_ddtf] END,
     CASE @OrderBy WHEN 't_ddtf DESC' THEN [ttdpur401200].[t_ddtf] END DESC,
     CASE @OrderBy WHEN 't_rdta' THEN [ttdpur401200].[t_rdta] END,
     CASE @OrderBy WHEN 't_rdta DESC' THEN [ttdpur401200].[t_rdta] END DESC,
     CASE @OrderBy WHEN 't_pric' THEN [ttdpur401200].[t_pric] END,
     CASE @OrderBy WHEN 't_pric DESC' THEN [ttdpur401200].[t_pric] END DESC,
     CASE @OrderBy WHEN 't_porg' THEN [ttdpur401200].[t_porg] END,
     CASE @OrderBy WHEN 't_porg DESC' THEN [ttdpur401200].[t_porg] END DESC,
     CASE @OrderBy WHEN 't_pmde' THEN [ttdpur401200].[t_pmde] END,
     CASE @OrderBy WHEN 't_pmde DESC' THEN [ttdpur401200].[t_pmde] END DESC,
     CASE @OrderBy WHEN 't_pmse' THEN [ttdpur401200].[t_pmse] END,
     CASE @OrderBy WHEN 't_pmse DESC' THEN [ttdpur401200].[t_pmse] END DESC,
     CASE @OrderBy WHEN 't_cupp' THEN [ttdpur401200].[t_cupp] END,
     CASE @OrderBy WHEN 't_cupp DESC' THEN [ttdpur401200].[t_cupp] END DESC,
     CASE @OrderBy WHEN 't_cvpp' THEN [ttdpur401200].[t_cvpp] END,
     CASE @OrderBy WHEN 't_cvpp DESC' THEN [ttdpur401200].[t_cvpp] END DESC,
     CASE @OrderBy WHEN 't_disc_1' THEN [ttdpur401200].[t_disc_1] END,
     CASE @OrderBy WHEN 't_disc_1 DESC' THEN [ttdpur401200].[t_disc_1] END DESC,
     CASE @OrderBy WHEN 't_disc_2' THEN [ttdpur401200].[t_disc_2] END,
     CASE @OrderBy WHEN 't_disc_2 DESC' THEN [ttdpur401200].[t_disc_2] END DESC,
     CASE @OrderBy WHEN 't_disc_3' THEN [ttdpur401200].[t_disc_3] END,
     CASE @OrderBy WHEN 't_disc_3 DESC' THEN [ttdpur401200].[t_disc_3] END DESC,
     CASE @OrderBy WHEN 't_disc_4' THEN [ttdpur401200].[t_disc_4] END,
     CASE @OrderBy WHEN 't_disc_4 DESC' THEN [ttdpur401200].[t_disc_4] END DESC,
     CASE @OrderBy WHEN 't_disc_5' THEN [ttdpur401200].[t_disc_5] END,
     CASE @OrderBy WHEN 't_disc_5 DESC' THEN [ttdpur401200].[t_disc_5] END DESC,
     CASE @OrderBy WHEN 't_disc_6' THEN [ttdpur401200].[t_disc_6] END,
     CASE @OrderBy WHEN 't_disc_6 DESC' THEN [ttdpur401200].[t_disc_6] END DESC,
     CASE @OrderBy WHEN 't_disc_7' THEN [ttdpur401200].[t_disc_7] END,
     CASE @OrderBy WHEN 't_disc_7 DESC' THEN [ttdpur401200].[t_disc_7] END DESC,
     CASE @OrderBy WHEN 't_disc_8' THEN [ttdpur401200].[t_disc_8] END,
     CASE @OrderBy WHEN 't_disc_8 DESC' THEN [ttdpur401200].[t_disc_8] END DESC,
     CASE @OrderBy WHEN 't_disc_9' THEN [ttdpur401200].[t_disc_9] END,
     CASE @OrderBy WHEN 't_disc_9 DESC' THEN [ttdpur401200].[t_disc_9] END DESC,
     CASE @OrderBy WHEN 't_disc_10' THEN [ttdpur401200].[t_disc_10] END,
     CASE @OrderBy WHEN 't_disc_10 DESC' THEN [ttdpur401200].[t_disc_10] END DESC,
     CASE @OrderBy WHEN 't_disc_11' THEN [ttdpur401200].[t_disc_11] END,
     CASE @OrderBy WHEN 't_disc_11 DESC' THEN [ttdpur401200].[t_disc_11] END DESC,
     CASE @OrderBy WHEN 't_ldam_1' THEN [ttdpur401200].[t_ldam_1] END,
     CASE @OrderBy WHEN 't_ldam_1 DESC' THEN [ttdpur401200].[t_ldam_1] END DESC,
     CASE @OrderBy WHEN 't_ldam_2' THEN [ttdpur401200].[t_ldam_2] END,
     CASE @OrderBy WHEN 't_ldam_2 DESC' THEN [ttdpur401200].[t_ldam_2] END DESC,
     CASE @OrderBy WHEN 't_ldam_3' THEN [ttdpur401200].[t_ldam_3] END,
     CASE @OrderBy WHEN 't_ldam_3 DESC' THEN [ttdpur401200].[t_ldam_3] END DESC,
     CASE @OrderBy WHEN 't_ldam_4' THEN [ttdpur401200].[t_ldam_4] END,
     CASE @OrderBy WHEN 't_ldam_4 DESC' THEN [ttdpur401200].[t_ldam_4] END DESC,
     CASE @OrderBy WHEN 't_ldam_5' THEN [ttdpur401200].[t_ldam_5] END,
     CASE @OrderBy WHEN 't_ldam_5 DESC' THEN [ttdpur401200].[t_ldam_5] END DESC,
     CASE @OrderBy WHEN 't_ldam_6' THEN [ttdpur401200].[t_ldam_6] END,
     CASE @OrderBy WHEN 't_ldam_6 DESC' THEN [ttdpur401200].[t_ldam_6] END DESC,
     CASE @OrderBy WHEN 't_ldam_7' THEN [ttdpur401200].[t_ldam_7] END,
     CASE @OrderBy WHEN 't_ldam_7 DESC' THEN [ttdpur401200].[t_ldam_7] END DESC,
     CASE @OrderBy WHEN 't_ldam_8' THEN [ttdpur401200].[t_ldam_8] END,
     CASE @OrderBy WHEN 't_ldam_8 DESC' THEN [ttdpur401200].[t_ldam_8] END DESC,
     CASE @OrderBy WHEN 't_ldam_9' THEN [ttdpur401200].[t_ldam_9] END,
     CASE @OrderBy WHEN 't_ldam_9 DESC' THEN [ttdpur401200].[t_ldam_9] END DESC,
     CASE @OrderBy WHEN 't_ldam_10' THEN [ttdpur401200].[t_ldam_10] END,
     CASE @OrderBy WHEN 't_ldam_10 DESC' THEN [ttdpur401200].[t_ldam_10] END DESC,
     CASE @OrderBy WHEN 't_ldam_11' THEN [ttdpur401200].[t_ldam_11] END,
     CASE @OrderBy WHEN 't_ldam_11 DESC' THEN [ttdpur401200].[t_ldam_11] END DESC,
     CASE @OrderBy WHEN 't_dorg_1' THEN [ttdpur401200].[t_dorg_1] END,
     CASE @OrderBy WHEN 't_dorg_1 DESC' THEN [ttdpur401200].[t_dorg_1] END DESC,
     CASE @OrderBy WHEN 't_dorg_2' THEN [ttdpur401200].[t_dorg_2] END,
     CASE @OrderBy WHEN 't_dorg_2 DESC' THEN [ttdpur401200].[t_dorg_2] END DESC,
     CASE @OrderBy WHEN 't_dorg_3' THEN [ttdpur401200].[t_dorg_3] END,
     CASE @OrderBy WHEN 't_dorg_3 DESC' THEN [ttdpur401200].[t_dorg_3] END DESC,
     CASE @OrderBy WHEN 't_dorg_4' THEN [ttdpur401200].[t_dorg_4] END,
     CASE @OrderBy WHEN 't_dorg_4 DESC' THEN [ttdpur401200].[t_dorg_4] END DESC,
     CASE @OrderBy WHEN 't_dorg_5' THEN [ttdpur401200].[t_dorg_5] END,
     CASE @OrderBy WHEN 't_dorg_5 DESC' THEN [ttdpur401200].[t_dorg_5] END DESC,
     CASE @OrderBy WHEN 't_dorg_6' THEN [ttdpur401200].[t_dorg_6] END,
     CASE @OrderBy WHEN 't_dorg_6 DESC' THEN [ttdpur401200].[t_dorg_6] END DESC,
     CASE @OrderBy WHEN 't_dorg_7' THEN [ttdpur401200].[t_dorg_7] END,
     CASE @OrderBy WHEN 't_dorg_7 DESC' THEN [ttdpur401200].[t_dorg_7] END DESC,
     CASE @OrderBy WHEN 't_dorg_8' THEN [ttdpur401200].[t_dorg_8] END,
     CASE @OrderBy WHEN 't_dorg_8 DESC' THEN [ttdpur401200].[t_dorg_8] END DESC,
     CASE @OrderBy WHEN 't_dorg_9' THEN [ttdpur401200].[t_dorg_9] END,
     CASE @OrderBy WHEN 't_dorg_9 DESC' THEN [ttdpur401200].[t_dorg_9] END DESC,
     CASE @OrderBy WHEN 't_dorg_10' THEN [ttdpur401200].[t_dorg_10] END,
     CASE @OrderBy WHEN 't_dorg_10 DESC' THEN [ttdpur401200].[t_dorg_10] END DESC,
     CASE @OrderBy WHEN 't_dorg_11' THEN [ttdpur401200].[t_dorg_11] END,
     CASE @OrderBy WHEN 't_dorg_11 DESC' THEN [ttdpur401200].[t_dorg_11] END DESC,
     CASE @OrderBy WHEN 't_dmty_1' THEN [ttdpur401200].[t_dmty_1] END,
     CASE @OrderBy WHEN 't_dmty_1 DESC' THEN [ttdpur401200].[t_dmty_1] END DESC,
     CASE @OrderBy WHEN 't_dmty_2' THEN [ttdpur401200].[t_dmty_2] END,
     CASE @OrderBy WHEN 't_dmty_2 DESC' THEN [ttdpur401200].[t_dmty_2] END DESC,
     CASE @OrderBy WHEN 't_dmty_3' THEN [ttdpur401200].[t_dmty_3] END,
     CASE @OrderBy WHEN 't_dmty_3 DESC' THEN [ttdpur401200].[t_dmty_3] END DESC,
     CASE @OrderBy WHEN 't_dmty_4' THEN [ttdpur401200].[t_dmty_4] END,
     CASE @OrderBy WHEN 't_dmty_4 DESC' THEN [ttdpur401200].[t_dmty_4] END DESC,
     CASE @OrderBy WHEN 't_dmty_5' THEN [ttdpur401200].[t_dmty_5] END,
     CASE @OrderBy WHEN 't_dmty_5 DESC' THEN [ttdpur401200].[t_dmty_5] END DESC,
     CASE @OrderBy WHEN 't_dmty_6' THEN [ttdpur401200].[t_dmty_6] END,
     CASE @OrderBy WHEN 't_dmty_6 DESC' THEN [ttdpur401200].[t_dmty_6] END DESC,
     CASE @OrderBy WHEN 't_dmty_7' THEN [ttdpur401200].[t_dmty_7] END,
     CASE @OrderBy WHEN 't_dmty_7 DESC' THEN [ttdpur401200].[t_dmty_7] END DESC,
     CASE @OrderBy WHEN 't_dmty_8' THEN [ttdpur401200].[t_dmty_8] END,
     CASE @OrderBy WHEN 't_dmty_8 DESC' THEN [ttdpur401200].[t_dmty_8] END DESC,
     CASE @OrderBy WHEN 't_dmty_9' THEN [ttdpur401200].[t_dmty_9] END,
     CASE @OrderBy WHEN 't_dmty_9 DESC' THEN [ttdpur401200].[t_dmty_9] END DESC,
     CASE @OrderBy WHEN 't_dmty_10' THEN [ttdpur401200].[t_dmty_10] END,
     CASE @OrderBy WHEN 't_dmty_10 DESC' THEN [ttdpur401200].[t_dmty_10] END DESC,
     CASE @OrderBy WHEN 't_dmty_11' THEN [ttdpur401200].[t_dmty_11] END,
     CASE @OrderBy WHEN 't_dmty_11 DESC' THEN [ttdpur401200].[t_dmty_11] END DESC,
     CASE @OrderBy WHEN 't_dmde_1' THEN [ttdpur401200].[t_dmde_1] END,
     CASE @OrderBy WHEN 't_dmde_1 DESC' THEN [ttdpur401200].[t_dmde_1] END DESC,
     CASE @OrderBy WHEN 't_dmde_2' THEN [ttdpur401200].[t_dmde_2] END,
     CASE @OrderBy WHEN 't_dmde_2 DESC' THEN [ttdpur401200].[t_dmde_2] END DESC,
     CASE @OrderBy WHEN 't_dmde_3' THEN [ttdpur401200].[t_dmde_3] END,
     CASE @OrderBy WHEN 't_dmde_3 DESC' THEN [ttdpur401200].[t_dmde_3] END DESC,
     CASE @OrderBy WHEN 't_dmde_4' THEN [ttdpur401200].[t_dmde_4] END,
     CASE @OrderBy WHEN 't_dmde_4 DESC' THEN [ttdpur401200].[t_dmde_4] END DESC,
     CASE @OrderBy WHEN 't_dmde_5' THEN [ttdpur401200].[t_dmde_5] END,
     CASE @OrderBy WHEN 't_dmde_5 DESC' THEN [ttdpur401200].[t_dmde_5] END DESC,
     CASE @OrderBy WHEN 't_dmde_6' THEN [ttdpur401200].[t_dmde_6] END,
     CASE @OrderBy WHEN 't_dmde_6 DESC' THEN [ttdpur401200].[t_dmde_6] END DESC,
     CASE @OrderBy WHEN 't_dmde_7' THEN [ttdpur401200].[t_dmde_7] END,
     CASE @OrderBy WHEN 't_dmde_7 DESC' THEN [ttdpur401200].[t_dmde_7] END DESC,
     CASE @OrderBy WHEN 't_dmde_8' THEN [ttdpur401200].[t_dmde_8] END,
     CASE @OrderBy WHEN 't_dmde_8 DESC' THEN [ttdpur401200].[t_dmde_8] END DESC,
     CASE @OrderBy WHEN 't_dmde_9' THEN [ttdpur401200].[t_dmde_9] END,
     CASE @OrderBy WHEN 't_dmde_9 DESC' THEN [ttdpur401200].[t_dmde_9] END DESC,
     CASE @OrderBy WHEN 't_dmde_10' THEN [ttdpur401200].[t_dmde_10] END,
     CASE @OrderBy WHEN 't_dmde_10 DESC' THEN [ttdpur401200].[t_dmde_10] END DESC,
     CASE @OrderBy WHEN 't_dmde_11' THEN [ttdpur401200].[t_dmde_11] END,
     CASE @OrderBy WHEN 't_dmde_11 DESC' THEN [ttdpur401200].[t_dmde_11] END DESC,
     CASE @OrderBy WHEN 't_dmse_1' THEN [ttdpur401200].[t_dmse_1] END,
     CASE @OrderBy WHEN 't_dmse_1 DESC' THEN [ttdpur401200].[t_dmse_1] END DESC,
     CASE @OrderBy WHEN 't_dmse_2' THEN [ttdpur401200].[t_dmse_2] END,
     CASE @OrderBy WHEN 't_dmse_2 DESC' THEN [ttdpur401200].[t_dmse_2] END DESC,
     CASE @OrderBy WHEN 't_dmse_3' THEN [ttdpur401200].[t_dmse_3] END,
     CASE @OrderBy WHEN 't_dmse_3 DESC' THEN [ttdpur401200].[t_dmse_3] END DESC,
     CASE @OrderBy WHEN 't_dmse_4' THEN [ttdpur401200].[t_dmse_4] END,
     CASE @OrderBy WHEN 't_dmse_4 DESC' THEN [ttdpur401200].[t_dmse_4] END DESC,
     CASE @OrderBy WHEN 't_dmse_5' THEN [ttdpur401200].[t_dmse_5] END,
     CASE @OrderBy WHEN 't_dmse_5 DESC' THEN [ttdpur401200].[t_dmse_5] END DESC,
     CASE @OrderBy WHEN 't_dmse_6' THEN [ttdpur401200].[t_dmse_6] END,
     CASE @OrderBy WHEN 't_dmse_6 DESC' THEN [ttdpur401200].[t_dmse_6] END DESC,
     CASE @OrderBy WHEN 't_dmse_7' THEN [ttdpur401200].[t_dmse_7] END,
     CASE @OrderBy WHEN 't_dmse_7 DESC' THEN [ttdpur401200].[t_dmse_7] END DESC,
     CASE @OrderBy WHEN 't_dmse_8' THEN [ttdpur401200].[t_dmse_8] END,
     CASE @OrderBy WHEN 't_dmse_8 DESC' THEN [ttdpur401200].[t_dmse_8] END DESC,
     CASE @OrderBy WHEN 't_dmse_9' THEN [ttdpur401200].[t_dmse_9] END,
     CASE @OrderBy WHEN 't_dmse_9 DESC' THEN [ttdpur401200].[t_dmse_9] END DESC,
     CASE @OrderBy WHEN 't_dmse_10' THEN [ttdpur401200].[t_dmse_10] END,
     CASE @OrderBy WHEN 't_dmse_10 DESC' THEN [ttdpur401200].[t_dmse_10] END DESC,
     CASE @OrderBy WHEN 't_dmse_11' THEN [ttdpur401200].[t_dmse_11] END,
     CASE @OrderBy WHEN 't_dmse_11 DESC' THEN [ttdpur401200].[t_dmse_11] END DESC,
     CASE @OrderBy WHEN 't_dmth_1' THEN [ttdpur401200].[t_dmth_1] END,
     CASE @OrderBy WHEN 't_dmth_1 DESC' THEN [ttdpur401200].[t_dmth_1] END DESC,
     CASE @OrderBy WHEN 't_dmth_2' THEN [ttdpur401200].[t_dmth_2] END,
     CASE @OrderBy WHEN 't_dmth_2 DESC' THEN [ttdpur401200].[t_dmth_2] END DESC,
     CASE @OrderBy WHEN 't_dmth_3' THEN [ttdpur401200].[t_dmth_3] END,
     CASE @OrderBy WHEN 't_dmth_3 DESC' THEN [ttdpur401200].[t_dmth_3] END DESC,
     CASE @OrderBy WHEN 't_dmth_4' THEN [ttdpur401200].[t_dmth_4] END,
     CASE @OrderBy WHEN 't_dmth_4 DESC' THEN [ttdpur401200].[t_dmth_4] END DESC,
     CASE @OrderBy WHEN 't_dmth_5' THEN [ttdpur401200].[t_dmth_5] END,
     CASE @OrderBy WHEN 't_dmth_5 DESC' THEN [ttdpur401200].[t_dmth_5] END DESC,
     CASE @OrderBy WHEN 't_dmth_6' THEN [ttdpur401200].[t_dmth_6] END,
     CASE @OrderBy WHEN 't_dmth_6 DESC' THEN [ttdpur401200].[t_dmth_6] END DESC,
     CASE @OrderBy WHEN 't_dmth_7' THEN [ttdpur401200].[t_dmth_7] END,
     CASE @OrderBy WHEN 't_dmth_7 DESC' THEN [ttdpur401200].[t_dmth_7] END DESC,
     CASE @OrderBy WHEN 't_dmth_8' THEN [ttdpur401200].[t_dmth_8] END,
     CASE @OrderBy WHEN 't_dmth_8 DESC' THEN [ttdpur401200].[t_dmth_8] END DESC,
     CASE @OrderBy WHEN 't_dmth_9' THEN [ttdpur401200].[t_dmth_9] END,
     CASE @OrderBy WHEN 't_dmth_9 DESC' THEN [ttdpur401200].[t_dmth_9] END DESC,
     CASE @OrderBy WHEN 't_dmth_10' THEN [ttdpur401200].[t_dmth_10] END,
     CASE @OrderBy WHEN 't_dmth_10 DESC' THEN [ttdpur401200].[t_dmth_10] END DESC,
     CASE @OrderBy WHEN 't_dmth_11' THEN [ttdpur401200].[t_dmth_11] END,
     CASE @OrderBy WHEN 't_dmth_11 DESC' THEN [ttdpur401200].[t_dmth_11] END DESC,
     CASE @OrderBy WHEN 't_cdis_1' THEN [ttdpur401200].[t_cdis_1] END,
     CASE @OrderBy WHEN 't_cdis_1 DESC' THEN [ttdpur401200].[t_cdis_1] END DESC,
     CASE @OrderBy WHEN 't_cdis_2' THEN [ttdpur401200].[t_cdis_2] END,
     CASE @OrderBy WHEN 't_cdis_2 DESC' THEN [ttdpur401200].[t_cdis_2] END DESC,
     CASE @OrderBy WHEN 't_cdis_3' THEN [ttdpur401200].[t_cdis_3] END,
     CASE @OrderBy WHEN 't_cdis_3 DESC' THEN [ttdpur401200].[t_cdis_3] END DESC,
     CASE @OrderBy WHEN 't_cdis_4' THEN [ttdpur401200].[t_cdis_4] END,
     CASE @OrderBy WHEN 't_cdis_4 DESC' THEN [ttdpur401200].[t_cdis_4] END DESC,
     CASE @OrderBy WHEN 't_cdis_5' THEN [ttdpur401200].[t_cdis_5] END,
     CASE @OrderBy WHEN 't_cdis_5 DESC' THEN [ttdpur401200].[t_cdis_5] END DESC,
     CASE @OrderBy WHEN 't_cdis_6' THEN [ttdpur401200].[t_cdis_6] END,
     CASE @OrderBy WHEN 't_cdis_6 DESC' THEN [ttdpur401200].[t_cdis_6] END DESC,
     CASE @OrderBy WHEN 't_cdis_7' THEN [ttdpur401200].[t_cdis_7] END,
     CASE @OrderBy WHEN 't_cdis_7 DESC' THEN [ttdpur401200].[t_cdis_7] END DESC,
     CASE @OrderBy WHEN 't_cdis_8' THEN [ttdpur401200].[t_cdis_8] END,
     CASE @OrderBy WHEN 't_cdis_8 DESC' THEN [ttdpur401200].[t_cdis_8] END DESC,
     CASE @OrderBy WHEN 't_cdis_9' THEN [ttdpur401200].[t_cdis_9] END,
     CASE @OrderBy WHEN 't_cdis_9 DESC' THEN [ttdpur401200].[t_cdis_9] END DESC,
     CASE @OrderBy WHEN 't_cdis_10' THEN [ttdpur401200].[t_cdis_10] END,
     CASE @OrderBy WHEN 't_cdis_10 DESC' THEN [ttdpur401200].[t_cdis_10] END DESC,
     CASE @OrderBy WHEN 't_cdis_11' THEN [ttdpur401200].[t_cdis_11] END,
     CASE @OrderBy WHEN 't_cdis_11 DESC' THEN [ttdpur401200].[t_cdis_11] END DESC,
     CASE @OrderBy WHEN 't_dtrm' THEN [ttdpur401200].[t_dtrm] END,
     CASE @OrderBy WHEN 't_dtrm DESC' THEN [ttdpur401200].[t_dtrm] END DESC,
     CASE @OrderBy WHEN 't_elgb' THEN [ttdpur401200].[t_elgb] END,
     CASE @OrderBy WHEN 't_elgb DESC' THEN [ttdpur401200].[t_elgb] END DESC,
     CASE @OrderBy WHEN 't_stdc' THEN [ttdpur401200].[t_stdc] END,
     CASE @OrderBy WHEN 't_stdc DESC' THEN [ttdpur401200].[t_stdc] END DESC,
     CASE @OrderBy WHEN 't_oamt' THEN [ttdpur401200].[t_oamt] END,
     CASE @OrderBy WHEN 't_oamt DESC' THEN [ttdpur401200].[t_oamt] END DESC,
     CASE @OrderBy WHEN 't_rcno' THEN [ttdpur401200].[t_rcno] END,
     CASE @OrderBy WHEN 't_rcno DESC' THEN [ttdpur401200].[t_rcno] END DESC,
     CASE @OrderBy WHEN 't_rseq' THEN [ttdpur401200].[t_rseq] END,
     CASE @OrderBy WHEN 't_rseq DESC' THEN [ttdpur401200].[t_rseq] END DESC,
     CASE @OrderBy WHEN 't_dino' THEN [ttdpur401200].[t_dino] END,
     CASE @OrderBy WHEN 't_dino DESC' THEN [ttdpur401200].[t_dino] END DESC,
     CASE @OrderBy WHEN 't_qips' THEN [ttdpur401200].[t_qips] END,
     CASE @OrderBy WHEN 't_qips DESC' THEN [ttdpur401200].[t_qips] END DESC,
     CASE @OrderBy WHEN 't_qidl' THEN [ttdpur401200].[t_qidl] END,
     CASE @OrderBy WHEN 't_qidl DESC' THEN [ttdpur401200].[t_qidl] END DESC,
     CASE @OrderBy WHEN 't_qiap' THEN [ttdpur401200].[t_qiap] END,
     CASE @OrderBy WHEN 't_qiap DESC' THEN [ttdpur401200].[t_qiap] END DESC,
     CASE @OrderBy WHEN 't_crej' THEN [ttdpur401200].[t_crej] END,
     CASE @OrderBy WHEN 't_crej DESC' THEN [ttdpur401200].[t_crej] END DESC,
     CASE @OrderBy WHEN 't_qirj' THEN [ttdpur401200].[t_qirj] END,
     CASE @OrderBy WHEN 't_qirj DESC' THEN [ttdpur401200].[t_qirj] END DESC,
     CASE @OrderBy WHEN 't_qibo' THEN [ttdpur401200].[t_qibo] END,
     CASE @OrderBy WHEN 't_qibo DESC' THEN [ttdpur401200].[t_qibo] END DESC,
     CASE @OrderBy WHEN 't_qbbc' THEN [ttdpur401200].[t_qbbc] END,
     CASE @OrderBy WHEN 't_qbbc DESC' THEN [ttdpur401200].[t_qbbc] END DESC,
     CASE @OrderBy WHEN 't_cubp' THEN [ttdpur401200].[t_cubp] END,
     CASE @OrderBy WHEN 't_cubp DESC' THEN [ttdpur401200].[t_cubp] END DESC,
     CASE @OrderBy WHEN 't_cvbp' THEN [ttdpur401200].[t_cvbp] END,
     CASE @OrderBy WHEN 't_cvbp DESC' THEN [ttdpur401200].[t_cvbp] END DESC,
     CASE @OrderBy WHEN 't_fire' THEN [ttdpur401200].[t_fire] END,
     CASE @OrderBy WHEN 't_fire DESC' THEN [ttdpur401200].[t_fire] END DESC,
     CASE @OrderBy WHEN 't_qibp' THEN [ttdpur401200].[t_qibp] END,
     CASE @OrderBy WHEN 't_qibp DESC' THEN [ttdpur401200].[t_qibp] END DESC,
     CASE @OrderBy WHEN 't_ddon' THEN [ttdpur401200].[t_ddon] END,
     CASE @OrderBy WHEN 't_ddon DESC' THEN [ttdpur401200].[t_ddon] END DESC,
     CASE @OrderBy WHEN 't_lseq' THEN [ttdpur401200].[t_lseq] END,
     CASE @OrderBy WHEN 't_lseq DESC' THEN [ttdpur401200].[t_lseq] END DESC,
     CASE @OrderBy WHEN 't_pseq' THEN [ttdpur401200].[t_pseq] END,
     CASE @OrderBy WHEN 't_pseq DESC' THEN [ttdpur401200].[t_pseq] END DESC,
     CASE @OrderBy WHEN 't_amld' THEN [ttdpur401200].[t_amld] END,
     CASE @OrderBy WHEN 't_amld DESC' THEN [ttdpur401200].[t_amld] END DESC,
     CASE @OrderBy WHEN 't_amod' THEN [ttdpur401200].[t_amod] END,
     CASE @OrderBy WHEN 't_amod DESC' THEN [ttdpur401200].[t_amod] END DESC,
     CASE @OrderBy WHEN 't_damt' THEN [ttdpur401200].[t_damt] END,
     CASE @OrderBy WHEN 't_damt DESC' THEN [ttdpur401200].[t_damt] END DESC,
     CASE @OrderBy WHEN 't_stsc' THEN [ttdpur401200].[t_stsc] END,
     CASE @OrderBy WHEN 't_stsc DESC' THEN [ttdpur401200].[t_stsc] END DESC,
     CASE @OrderBy WHEN 't_stsd' THEN [ttdpur401200].[t_stsd] END,
     CASE @OrderBy WHEN 't_stsd DESC' THEN [ttdpur401200].[t_stsd] END DESC,
     CASE @OrderBy WHEN 't_vryn' THEN [ttdpur401200].[t_vryn] END,
     CASE @OrderBy WHEN 't_vryn DESC' THEN [ttdpur401200].[t_vryn] END DESC,
     CASE @OrderBy WHEN 't_invn' THEN [ttdpur401200].[t_invn] END,
     CASE @OrderBy WHEN 't_invn DESC' THEN [ttdpur401200].[t_invn] END DESC,
     CASE @OrderBy WHEN 't_invd' THEN [ttdpur401200].[t_invd] END,
     CASE @OrderBy WHEN 't_invd DESC' THEN [ttdpur401200].[t_invd] END DESC,
     CASE @OrderBy WHEN 't_copr_1' THEN [ttdpur401200].[t_copr_1] END,
     CASE @OrderBy WHEN 't_copr_1 DESC' THEN [ttdpur401200].[t_copr_1] END DESC,
     CASE @OrderBy WHEN 't_copr_2' THEN [ttdpur401200].[t_copr_2] END,
     CASE @OrderBy WHEN 't_copr_2 DESC' THEN [ttdpur401200].[t_copr_2] END DESC,
     CASE @OrderBy WHEN 't_copr_3' THEN [ttdpur401200].[t_copr_3] END,
     CASE @OrderBy WHEN 't_copr_3 DESC' THEN [ttdpur401200].[t_copr_3] END DESC,
     CASE @OrderBy WHEN 't_coop_1' THEN [ttdpur401200].[t_coop_1] END,
     CASE @OrderBy WHEN 't_coop_1 DESC' THEN [ttdpur401200].[t_coop_1] END DESC,
     CASE @OrderBy WHEN 't_coop_2' THEN [ttdpur401200].[t_coop_2] END,
     CASE @OrderBy WHEN 't_coop_2 DESC' THEN [ttdpur401200].[t_coop_2] END DESC,
     CASE @OrderBy WHEN 't_coop_3' THEN [ttdpur401200].[t_coop_3] END,
     CASE @OrderBy WHEN 't_coop_3 DESC' THEN [ttdpur401200].[t_coop_3] END DESC,
     CASE @OrderBy WHEN 't_cpcp' THEN [ttdpur401200].[t_cpcp] END,
     CASE @OrderBy WHEN 't_cpcp DESC' THEN [ttdpur401200].[t_cpcp] END DESC,
     CASE @OrderBy WHEN 't_cwar' THEN [ttdpur401200].[t_cwar] END,
     CASE @OrderBy WHEN 't_cwar DESC' THEN [ttdpur401200].[t_cwar] END DESC,
     CASE @OrderBy WHEN 't_cadr' THEN [ttdpur401200].[t_cadr] END,
     CASE @OrderBy WHEN 't_cadr DESC' THEN [ttdpur401200].[t_cadr] END DESC,
     CASE @OrderBy WHEN 't_lsel' THEN [ttdpur401200].[t_lsel] END,
     CASE @OrderBy WHEN 't_lsel DESC' THEN [ttdpur401200].[t_lsel] END DESC,
     CASE @OrderBy WHEN 't_clot' THEN [ttdpur401200].[t_clot] END,
     CASE @OrderBy WHEN 't_clot DESC' THEN [ttdpur401200].[t_clot] END DESC,
     CASE @OrderBy WHEN 't_cprj' THEN [ttdpur401200].[t_cprj] END,
     CASE @OrderBy WHEN 't_cprj DESC' THEN [ttdpur401200].[t_cprj] END DESC,
     CASE @OrderBy WHEN 't_cspa' THEN [ttdpur401200].[t_cspa] END,
     CASE @OrderBy WHEN 't_cspa DESC' THEN [ttdpur401200].[t_cspa] END DESC,
     CASE @OrderBy WHEN 't_cact' THEN [ttdpur401200].[t_cact] END,
     CASE @OrderBy WHEN 't_cact DESC' THEN [ttdpur401200].[t_cact] END DESC,
     CASE @OrderBy WHEN 't_cstl' THEN [ttdpur401200].[t_cstl] END,
     CASE @OrderBy WHEN 't_cstl DESC' THEN [ttdpur401200].[t_cstl] END DESC,
     CASE @OrderBy WHEN 't_ccco' THEN [ttdpur401200].[t_ccco] END,
     CASE @OrderBy WHEN 't_ccco DESC' THEN [ttdpur401200].[t_ccco] END DESC,
     CASE @OrderBy WHEN 't_ctrj' THEN [ttdpur401200].[t_ctrj] END,
     CASE @OrderBy WHEN 't_ctrj DESC' THEN [ttdpur401200].[t_ctrj] END DESC,
     CASE @OrderBy WHEN 't_akcd' THEN [ttdpur401200].[t_akcd] END,
     CASE @OrderBy WHEN 't_akcd DESC' THEN [ttdpur401200].[t_akcd] END DESC,
     CASE @OrderBy WHEN 't_cfrw' THEN [ttdpur401200].[t_cfrw] END,
     CASE @OrderBy WHEN 't_cfrw DESC' THEN [ttdpur401200].[t_cfrw] END DESC,
     CASE @OrderBy WHEN 't_crbn' THEN [ttdpur401200].[t_crbn] END,
     CASE @OrderBy WHEN 't_crbn DESC' THEN [ttdpur401200].[t_crbn] END DESC,
     CASE @OrderBy WHEN 't_clyn' THEN [ttdpur401200].[t_clyn] END,
     CASE @OrderBy WHEN 't_clyn DESC' THEN [ttdpur401200].[t_clyn] END DESC,
     CASE @OrderBy WHEN 't_cpva' THEN [ttdpur401200].[t_cpva] END,
     CASE @OrderBy WHEN 't_cpva DESC' THEN [ttdpur401200].[t_cpva] END DESC,
     CASE @OrderBy WHEN 't_crcd' THEN [ttdpur401200].[t_crcd] END,
     CASE @OrderBy WHEN 't_crcd DESC' THEN [ttdpur401200].[t_crcd] END DESC,
     CASE @OrderBy WHEN 't_ctcd' THEN [ttdpur401200].[t_ctcd] END,
     CASE @OrderBy WHEN 't_ctcd DESC' THEN [ttdpur401200].[t_ctcd] END DESC,
     CASE @OrderBy WHEN 't_cosn' THEN [ttdpur401200].[t_cosn] END,
     CASE @OrderBy WHEN 't_cosn DESC' THEN [ttdpur401200].[t_cosn] END DESC,
     CASE @OrderBy WHEN 't_qiiv' THEN [ttdpur401200].[t_qiiv] END,
     CASE @OrderBy WHEN 't_qiiv DESC' THEN [ttdpur401200].[t_qiiv] END DESC,
     CASE @OrderBy WHEN 't_iamt' THEN [ttdpur401200].[t_iamt] END,
     CASE @OrderBy WHEN 't_iamt DESC' THEN [ttdpur401200].[t_iamt] END DESC,
     CASE @OrderBy WHEN 't_comm' THEN [ttdpur401200].[t_comm] END,
     CASE @OrderBy WHEN 't_comm DESC' THEN [ttdpur401200].[t_comm] END DESC,
     CASE @OrderBy WHEN 't_appr' THEN [ttdpur401200].[t_appr] END,
     CASE @OrderBy WHEN 't_appr DESC' THEN [ttdpur401200].[t_appr] END DESC,
     CASE @OrderBy WHEN 't_ccty' THEN [ttdpur401200].[t_ccty] END,
     CASE @OrderBy WHEN 't_ccty DESC' THEN [ttdpur401200].[t_ccty] END DESC,
     CASE @OrderBy WHEN 't_cvat' THEN [ttdpur401200].[t_cvat] END,
     CASE @OrderBy WHEN 't_cvat DESC' THEN [ttdpur401200].[t_cvat] END DESC,
     CASE @OrderBy WHEN 't_bptc' THEN [ttdpur401200].[t_bptc] END,
     CASE @OrderBy WHEN 't_bptc DESC' THEN [ttdpur401200].[t_bptc] END DESC,
     CASE @OrderBy WHEN 't_exmt' THEN [ttdpur401200].[t_exmt] END,
     CASE @OrderBy WHEN 't_exmt DESC' THEN [ttdpur401200].[t_exmt] END DESC,
     CASE @OrderBy WHEN 't_ceno' THEN [ttdpur401200].[t_ceno] END,
     CASE @OrderBy WHEN 't_ceno DESC' THEN [ttdpur401200].[t_ceno] END DESC,
     CASE @OrderBy WHEN 't_rcod' THEN [ttdpur401200].[t_rcod] END,
     CASE @OrderBy WHEN 't_rcod DESC' THEN [ttdpur401200].[t_rcod] END DESC,
     CASE @OrderBy WHEN 't_bpcl' THEN [ttdpur401200].[t_bpcl] END,
     CASE @OrderBy WHEN 't_bpcl DESC' THEN [ttdpur401200].[t_bpcl] END DESC,
     CASE @OrderBy WHEN 't_taxp' THEN [ttdpur401200].[t_taxp] END,
     CASE @OrderBy WHEN 't_taxp DESC' THEN [ttdpur401200].[t_taxp] END DESC,
     CASE @OrderBy WHEN 't_gefo' THEN [ttdpur401200].[t_gefo] END,
     CASE @OrderBy WHEN 't_gefo DESC' THEN [ttdpur401200].[t_gefo] END DESC,
     CASE @OrderBy WHEN 't_ldat' THEN [ttdpur401200].[t_ldat] END,
     CASE @OrderBy WHEN 't_ldat DESC' THEN [ttdpur401200].[t_ldat] END DESC,
     CASE @OrderBy WHEN 't_serv' THEN [ttdpur401200].[t_serv] END,
     CASE @OrderBy WHEN 't_serv DESC' THEN [ttdpur401200].[t_serv] END DESC,
     CASE @OrderBy WHEN 't_casi' THEN [ttdpur401200].[t_casi] END,
     CASE @OrderBy WHEN 't_casi DESC' THEN [ttdpur401200].[t_casi] END DESC,
     CASE @OrderBy WHEN 't_ptpe' THEN [ttdpur401200].[t_ptpe] END,
     CASE @OrderBy WHEN 't_ptpe DESC' THEN [ttdpur401200].[t_ptpe] END DESC,
     CASE @OrderBy WHEN 't_glco' THEN [ttdpur401200].[t_glco] END,
     CASE @OrderBy WHEN 't_glco DESC' THEN [ttdpur401200].[t_glco] END DESC,
     CASE @OrderBy WHEN 't_sbim' THEN [ttdpur401200].[t_sbim] END,
     CASE @OrderBy WHEN 't_sbim DESC' THEN [ttdpur401200].[t_sbim] END DESC,
     CASE @OrderBy WHEN 't_paft' THEN [ttdpur401200].[t_paft] END,
     CASE @OrderBy WHEN 't_paft DESC' THEN [ttdpur401200].[t_paft] END DESC,
     CASE @OrderBy WHEN 't_sbmt' THEN [ttdpur401200].[t_sbmt] END,
     CASE @OrderBy WHEN 't_sbmt DESC' THEN [ttdpur401200].[t_sbmt] END DESC,
     CASE @OrderBy WHEN 't_cuva' THEN [ttdpur401200].[t_cuva] END,
     CASE @OrderBy WHEN 't_cuva DESC' THEN [ttdpur401200].[t_cuva] END DESC,
     CASE @OrderBy WHEN 't_cono' THEN [ttdpur401200].[t_cono] END,
     CASE @OrderBy WHEN 't_cono DESC' THEN [ttdpur401200].[t_cono] END DESC,
     CASE @OrderBy WHEN 't_cpon' THEN [ttdpur401200].[t_cpon] END,
     CASE @OrderBy WHEN 't_cpon DESC' THEN [ttdpur401200].[t_cpon] END DESC,
     CASE @OrderBy WHEN 't_ccof' THEN [ttdpur401200].[t_ccof] END,
     CASE @OrderBy WHEN 't_ccof DESC' THEN [ttdpur401200].[t_ccof] END DESC,
     CASE @OrderBy WHEN 't_cnig' THEN [ttdpur401200].[t_cnig] END,
     CASE @OrderBy WHEN 't_cnig DESC' THEN [ttdpur401200].[t_cnig] END DESC,
     CASE @OrderBy WHEN 't_paya' THEN [ttdpur401200].[t_paya] END,
     CASE @OrderBy WHEN 't_paya DESC' THEN [ttdpur401200].[t_paya] END DESC,
     CASE @OrderBy WHEN 't_cpay' THEN [ttdpur401200].[t_cpay] END,
     CASE @OrderBy WHEN 't_cpay DESC' THEN [ttdpur401200].[t_cpay] END DESC,
     CASE @OrderBy WHEN 't_cdec' THEN [ttdpur401200].[t_cdec] END,
     CASE @OrderBy WHEN 't_cdec DESC' THEN [ttdpur401200].[t_cdec] END DESC,
     CASE @OrderBy WHEN 't_ptpa' THEN [ttdpur401200].[t_ptpa] END,
     CASE @OrderBy WHEN 't_ptpa DESC' THEN [ttdpur401200].[t_ptpa] END DESC,
     CASE @OrderBy WHEN 't_pmnt' THEN [ttdpur401200].[t_pmnt] END,
     CASE @OrderBy WHEN 't_pmnt DESC' THEN [ttdpur401200].[t_pmnt] END DESC,
     CASE @OrderBy WHEN 't_pmni' THEN [ttdpur401200].[t_pmni] END,
     CASE @OrderBy WHEN 't_pmni DESC' THEN [ttdpur401200].[t_pmni] END DESC,
     CASE @OrderBy WHEN 't_pmnd' THEN [ttdpur401200].[t_pmnd] END,
     CASE @OrderBy WHEN 't_pmnd DESC' THEN [ttdpur401200].[t_pmnd] END DESC,
     CASE @OrderBy WHEN 't_owns' THEN [ttdpur401200].[t_owns] END,
     CASE @OrderBy WHEN 't_owns DESC' THEN [ttdpur401200].[t_owns] END DESC,
     CASE @OrderBy WHEN 't_lccl' THEN [ttdpur401200].[t_lccl] END,
     CASE @OrderBy WHEN 't_lccl DESC' THEN [ttdpur401200].[t_lccl] END DESC,
     CASE @OrderBy WHEN 't_spcn' THEN [ttdpur401200].[t_spcn] END,
     CASE @OrderBy WHEN 't_spcn DESC' THEN [ttdpur401200].[t_spcn] END DESC,
     CASE @OrderBy WHEN 't_bgxc' THEN [ttdpur401200].[t_bgxc] END,
     CASE @OrderBy WHEN 't_bgxc DESC' THEN [ttdpur401200].[t_bgxc] END DESC,
     CASE @OrderBy WHEN 't_cpcl' THEN [ttdpur401200].[t_cpcl] END,
     CASE @OrderBy WHEN 't_cpcl DESC' THEN [ttdpur401200].[t_cpcl] END DESC,
     CASE @OrderBy WHEN 't_cpln' THEN [ttdpur401200].[t_cpln] END,
     CASE @OrderBy WHEN 't_cpln DESC' THEN [ttdpur401200].[t_cpln] END DESC,
     CASE @OrderBy WHEN 't_csgp' THEN [ttdpur401200].[t_csgp] END,
     CASE @OrderBy WHEN 't_csgp DESC' THEN [ttdpur401200].[t_csgp] END DESC,
     CASE @OrderBy WHEN 't_acti' THEN [ttdpur401200].[t_acti] END,
     CASE @OrderBy WHEN 't_acti DESC' THEN [ttdpur401200].[t_acti] END DESC,
     CASE @OrderBy WHEN 't_pmsk' THEN [ttdpur401200].[t_pmsk] END,
     CASE @OrderBy WHEN 't_pmsk DESC' THEN [ttdpur401200].[t_pmsk] END DESC,
     CASE @OrderBy WHEN 't_rnso_l' THEN [ttdpur401200].[t_rnso_l] END,
     CASE @OrderBy WHEN 't_rnso_l DESC' THEN [ttdpur401200].[t_rnso_l] END DESC,
     CASE @OrderBy WHEN 't_rnsb_l' THEN [ttdpur401200].[t_rnsb_l] END,
     CASE @OrderBy WHEN 't_rnsb_l DESC' THEN [ttdpur401200].[t_rnsb_l] END DESC,
     CASE @OrderBy WHEN 't_ecif_l' THEN [ttdpur401200].[t_ecif_l] END,
     CASE @OrderBy WHEN 't_ecif_l DESC' THEN [ttdpur401200].[t_ecif_l] END DESC,
     CASE @OrderBy WHEN 't_assv_l' THEN [ttdpur401200].[t_assv_l] END,
     CASE @OrderBy WHEN 't_assv_l DESC' THEN [ttdpur401200].[t_assv_l] END DESC,
     CASE @OrderBy WHEN 't_elco_l' THEN [ttdpur401200].[t_elco_l] END,
     CASE @OrderBy WHEN 't_elco_l DESC' THEN [ttdpur401200].[t_elco_l] END DESC,
     CASE @OrderBy WHEN 't_ihsn_l' THEN [ttdpur401200].[t_ihsn_l] END,
     CASE @OrderBy WHEN 't_ihsn_l DESC' THEN [ttdpur401200].[t_ihsn_l] END DESC,
     CASE @OrderBy WHEN 't_mrpo_l' THEN [ttdpur401200].[t_mrpo_l] END,
     CASE @OrderBy WHEN 't_mrpo_l DESC' THEN [ttdpur401200].[t_mrpo_l] END DESC,
     CASE @OrderBy WHEN 't_iexb_l' THEN [ttdpur401200].[t_iexb_l] END,
     CASE @OrderBy WHEN 't_iexb_l DESC' THEN [ttdpur401200].[t_iexb_l] END DESC,
     CASE @OrderBy WHEN 't_icen_l' THEN [ttdpur401200].[t_icen_l] END,
     CASE @OrderBy WHEN 't_icen_l DESC' THEN [ttdpur401200].[t_icen_l] END DESC,
     CASE @OrderBy WHEN 't_imca_l' THEN [ttdpur401200].[t_imca_l] END,
     CASE @OrderBy WHEN 't_imca_l DESC' THEN [ttdpur401200].[t_imca_l] END DESC,
     CASE @OrderBy WHEN 't_exca_l' THEN [ttdpur401200].[t_exca_l] END,
     CASE @OrderBy WHEN 't_exca_l DESC' THEN [ttdpur401200].[t_exca_l] END DESC,
     CASE @OrderBy WHEN 't_mrpe_l' THEN [ttdpur401200].[t_mrpe_l] END,
     CASE @OrderBy WHEN 't_mrpe_l DESC' THEN [ttdpur401200].[t_mrpe_l] END DESC,
     CASE @OrderBy WHEN 't_hcod_l' THEN [ttdpur401200].[t_hcod_l] END,
     CASE @OrderBy WHEN 't_hcod_l DESC' THEN [ttdpur401200].[t_hcod_l] END DESC,
     CASE @OrderBy WHEN 't_cenv_l' THEN [ttdpur401200].[t_cenv_l] END,
     CASE @OrderBy WHEN 't_cenv_l DESC' THEN [ttdpur401200].[t_cenv_l] END DESC,
     CASE @OrderBy WHEN 't_icat_l' THEN [ttdpur401200].[t_icat_l] END,
     CASE @OrderBy WHEN 't_icat_l DESC' THEN [ttdpur401200].[t_icat_l] END DESC,
     CASE @OrderBy WHEN 't_asoe_l' THEN [ttdpur401200].[t_asoe_l] END,
     CASE @OrderBy WHEN 't_asoe_l DESC' THEN [ttdpur401200].[t_asoe_l] END DESC,
     CASE @OrderBy WHEN 't_asve_l' THEN [ttdpur401200].[t_asve_l] END,
     CASE @OrderBy WHEN 't_asve_l DESC' THEN [ttdpur401200].[t_asve_l] END DESC,
     CASE @OrderBy WHEN 't_dise_l' THEN [ttdpur401200].[t_dise_l] END,
     CASE @OrderBy WHEN 't_dise_l DESC' THEN [ttdpur401200].[t_dise_l] END DESC,
     CASE @OrderBy WHEN 't_fase_l' THEN [ttdpur401200].[t_fase_l] END,
     CASE @OrderBy WHEN 't_fase_l DESC' THEN [ttdpur401200].[t_fase_l] END DESC,
     CASE @OrderBy WHEN 't_asov_l' THEN [ttdpur401200].[t_asov_l] END,
     CASE @OrderBy WHEN 't_asov_l DESC' THEN [ttdpur401200].[t_asov_l] END DESC,
     CASE @OrderBy WHEN 't_asvv_l' THEN [ttdpur401200].[t_asvv_l] END,
     CASE @OrderBy WHEN 't_asvv_l DESC' THEN [ttdpur401200].[t_asvv_l] END DESC,
     CASE @OrderBy WHEN 't_disv_l' THEN [ttdpur401200].[t_disv_l] END,
     CASE @OrderBy WHEN 't_disv_l DESC' THEN [ttdpur401200].[t_disv_l] END DESC,
     CASE @OrderBy WHEN 't_fasv_l' THEN [ttdpur401200].[t_fasv_l] END,
     CASE @OrderBy WHEN 't_fasv_l DESC' THEN [ttdpur401200].[t_fasv_l] END DESC,
     CASE @OrderBy WHEN 't_asos_l' THEN [ttdpur401200].[t_asos_l] END,
     CASE @OrderBy WHEN 't_asos_l DESC' THEN [ttdpur401200].[t_asos_l] END DESC,
     CASE @OrderBy WHEN 't_asvs_l' THEN [ttdpur401200].[t_asvs_l] END,
     CASE @OrderBy WHEN 't_asvs_l DESC' THEN [ttdpur401200].[t_asvs_l] END DESC,
     CASE @OrderBy WHEN 't_diss_l' THEN [ttdpur401200].[t_diss_l] END,
     CASE @OrderBy WHEN 't_diss_l DESC' THEN [ttdpur401200].[t_diss_l] END DESC,
     CASE @OrderBy WHEN 't_fass_l' THEN [ttdpur401200].[t_fass_l] END,
     CASE @OrderBy WHEN 't_fass_l DESC' THEN [ttdpur401200].[t_fass_l] END DESC,
     CASE @OrderBy WHEN 't_iecc_l' THEN [ttdpur401200].[t_iecc_l] END,
     CASE @OrderBy WHEN 't_iecc_l DESC' THEN [ttdpur401200].[t_iecc_l] END DESC,
     CASE @OrderBy WHEN 't_mrpv_l' THEN [ttdpur401200].[t_mrpv_l] END,
     CASE @OrderBy WHEN 't_mrpv_l DESC' THEN [ttdpur401200].[t_mrpv_l] END DESC,
     CASE @OrderBy WHEN 't_mrps_l' THEN [ttdpur401200].[t_mrps_l] END,
     CASE @OrderBy WHEN 't_mrps_l DESC' THEN [ttdpur401200].[t_mrps_l] END DESC,
     CASE @OrderBy WHEN 't_reno_l' THEN [ttdpur401200].[t_reno_l] END,
     CASE @OrderBy WHEN 't_reno_l DESC' THEN [ttdpur401200].[t_reno_l] END DESC,
     CASE @OrderBy WHEN 't_rcln_l' THEN [ttdpur401200].[t_rcln_l] END,
     CASE @OrderBy WHEN 't_rcln_l DESC' THEN [ttdpur401200].[t_rcln_l] END DESC,
     CASE @OrderBy WHEN 't_mrpi_l' THEN [ttdpur401200].[t_mrpi_l] END,
     CASE @OrderBy WHEN 't_mrpi_l DESC' THEN [ttdpur401200].[t_mrpi_l] END DESC,
     CASE @OrderBy WHEN 't_ocim_l' THEN [ttdpur401200].[t_ocim_l] END,
     CASE @OrderBy WHEN 't_ocim_l DESC' THEN [ttdpur401200].[t_ocim_l] END DESC,
     CASE @OrderBy WHEN 't_ocio_l' THEN [ttdpur401200].[t_ocio_l] END,
     CASE @OrderBy WHEN 't_ocio_l DESC' THEN [ttdpur401200].[t_ocio_l] END DESC,
     CASE @OrderBy WHEN 't_extx_l' THEN [ttdpur401200].[t_extx_l] END,
     CASE @OrderBy WHEN 't_extx_l DESC' THEN [ttdpur401200].[t_extx_l] END DESC,
     CASE @OrderBy WHEN 't_cltx_l' THEN [ttdpur401200].[t_cltx_l] END,
     CASE @OrderBy WHEN 't_cltx_l DESC' THEN [ttdpur401200].[t_cltx_l] END DESC,
     CASE @OrderBy WHEN 't_lacm_l' THEN [ttdpur401200].[t_lacm_l] END,
     CASE @OrderBy WHEN 't_lacm_l DESC' THEN [ttdpur401200].[t_lacm_l] END DESC,
     CASE @OrderBy WHEN 't_tase_l' THEN [ttdpur401200].[t_tase_l] END,
     CASE @OrderBy WHEN 't_tase_l DESC' THEN [ttdpur401200].[t_tase_l] END DESC,
     CASE @OrderBy WHEN 't_tasv_l' THEN [ttdpur401200].[t_tasv_l] END,
     CASE @OrderBy WHEN 't_tasv_l DESC' THEN [ttdpur401200].[t_tasv_l] END DESC,
     CASE @OrderBy WHEN 't_tass_l' THEN [ttdpur401200].[t_tass_l] END,
     CASE @OrderBy WHEN 't_tass_l DESC' THEN [ttdpur401200].[t_tass_l] END DESC,
     CASE @OrderBy WHEN 't_uiac_l' THEN [ttdpur401200].[t_uiac_l] END,
     CASE @OrderBy WHEN 't_uiac_l DESC' THEN [ttdpur401200].[t_uiac_l] END DESC,
     CASE @OrderBy WHEN 't_uaig_l' THEN [ttdpur401200].[t_uaig_l] END,
     CASE @OrderBy WHEN 't_uaig_l DESC' THEN [ttdpur401200].[t_uaig_l] END DESC,
     CASE @OrderBy WHEN 't_txin_l' THEN [ttdpur401200].[t_txin_l] END,
     CASE @OrderBy WHEN 't_txin_l DESC' THEN [ttdpur401200].[t_txin_l] END DESC,
     CASE @OrderBy WHEN 't_gsub_l' THEN [ttdpur401200].[t_gsub_l] END,
     CASE @OrderBy WHEN 't_gsub_l DESC' THEN [ttdpur401200].[t_gsub_l] END DESC,
     CASE @OrderBy WHEN 't_txta' THEN [ttdpur401200].[t_txta] END,
     CASE @OrderBy WHEN 't_txta DESC' THEN [ttdpur401200].[t_txta] END DESC,
     CASE @OrderBy WHEN 't_btx1' THEN [ttdpur401200].[t_btx1] END,
     CASE @OrderBy WHEN 't_btx1 DESC' THEN [ttdpur401200].[t_btx1] END DESC,
     CASE @OrderBy WHEN 't_btx2' THEN [ttdpur401200].[t_btx2] END,
     CASE @OrderBy WHEN 't_btx2 DESC' THEN [ttdpur401200].[t_btx2] END DESC,
     CASE @OrderBy WHEN 't_cdf_ldat' THEN [ttdpur401200].[t_cdf_ldat] END,
     CASE @OrderBy WHEN 't_cdf_ldat DESC' THEN [ttdpur401200].[t_cdf_ldat] END DESC,
     CASE @OrderBy WHEN 't_Refcntd' THEN [ttdpur401200].[t_Refcntd] END,
     CASE @OrderBy WHEN 't_Refcntd DESC' THEN [ttdpur401200].[t_Refcntd] END DESC,
     CASE @OrderBy WHEN 't_Refcntu' THEN [ttdpur401200].[t_Refcntu] END,
     CASE @OrderBy WHEN 't_Refcntu DESC' THEN [ttdpur401200].[t_Refcntu] END DESC,
     CASE @OrderBy WHEN 't_asog_l' THEN [ttdpur401200].[t_asog_l] END,
     CASE @OrderBy WHEN 't_asog_l DESC' THEN [ttdpur401200].[t_asog_l] END DESC,
     CASE @OrderBy WHEN 't_asoi_l' THEN [ttdpur401200].[t_asoi_l] END,
     CASE @OrderBy WHEN 't_asoi_l DESC' THEN [ttdpur401200].[t_asoi_l] END DESC,
     CASE @OrderBy WHEN 't_asvg_l' THEN [ttdpur401200].[t_asvg_l] END,
     CASE @OrderBy WHEN 't_asvg_l DESC' THEN [ttdpur401200].[t_asvg_l] END DESC,
     CASE @OrderBy WHEN 't_atfr_l' THEN [ttdpur401200].[t_atfr_l] END,
     CASE @OrderBy WHEN 't_atfr_l DESC' THEN [ttdpur401200].[t_atfr_l] END DESC,
     CASE @OrderBy WHEN 't_gsta_l' THEN [ttdpur401200].[t_gsta_l] END,
     CASE @OrderBy WHEN 't_gsta_l DESC' THEN [ttdpur401200].[t_gsta_l] END DESC,
     CASE @OrderBy WHEN 't_tasg_l' THEN [ttdpur401200].[t_tasg_l] END,
     CASE @OrderBy WHEN 't_tasg_l DESC' THEN [ttdpur401200].[t_tasg_l] END DESC 

    SET @RecordCount = @@RowCount

  SELECT
    [ttdpur401200].*  
  FROM [ttdpur401200] 
      INNER JOIN #PageIndex
          ON [ttdpur401200].[t_orno] = #PageIndex.t_orno
          AND [ttdpur401200].[t_pono] = #PageIndex.t_pono
          AND [ttdpur401200].[t_sqnb] = #PageIndex.t_sqnb
  WHERE
        #PageIndex.IndexID > @StartRowIndex
        AND #PageIndex.IndexID < (@StartRowIndex + @MaximumRows + 1)
  ORDER BY
    #PageIndex.IndexID
  END
  GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sptdpur401SelectListFilteres]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sptdpur401SelectListFilteres]
GO
 
CREATE PROCEDURE [dbo].[sptdpur401SelectListFilteres]
  @LoginID NVarChar(8),
  @StartRowIndex int,
  @MaximumRows int,
  @OrderBy NVarChar(50),
  @RecordCount Int = 0 OUTPUT
  AS
  BEGIN
  DECLARE @LGSQL VarChar(8000)
  CREATE TABLE #PageIndex (
  IndexID INT IDENTITY (1, 1) NOT NULL
 ,t_orno VarChar(9) NOT NULL
 ,t_pono Int NOT NULL
 ,t_sqnb Int NOT NULL
  )
  SET @LGSQL = 'INSERT INTO #PageIndex (' 
  SET @LGSQL = @LGSQL + 't_orno'
  SET @LGSQL = @LGSQL + ', t_pono'
  SET @LGSQL = @LGSQL + ', t_sqnb'
  SET @LGSQL = @LGSQL + ')'
  SET @LGSQL = @LGSQL + ' SELECT '
  SET @LGSQL = @LGSQL + '[ttdpur401200].[t_orno]'
  SET @LGSQL = @LGSQL + ', [ttdpur401200].[t_pono]'
  SET @LGSQL = @LGSQL + ', [ttdpur401200].[t_sqnb]'
  SET @LGSQL = @LGSQL + ' FROM [ttdpur401200] '
  SET @LGSQL = @LGSQL + '  WHERE 1 = 1 '
  SET @LGSQL = @LGSQL + '  ORDER BY '
  SET @LGSQL = @LGSQL + CASE @OrderBy
                        WHEN 't_orno' THEN '[ttdpur401200].[t_orno]'
                        WHEN 't_orno DESC' THEN '[ttdpur401200].[t_orno] DESC'
                        WHEN 't_pono' THEN '[ttdpur401200].[t_pono]'
                        WHEN 't_pono DESC' THEN '[ttdpur401200].[t_pono] DESC'
                        WHEN 't_sqnb' THEN '[ttdpur401200].[t_sqnb]'
                        WHEN 't_sqnb DESC' THEN '[ttdpur401200].[t_sqnb] DESC'
                        WHEN 't_corg' THEN '[ttdpur401200].[t_corg]'
                        WHEN 't_corg DESC' THEN '[ttdpur401200].[t_corg] DESC'
                        WHEN 't_oltp' THEN '[ttdpur401200].[t_oltp]'
                        WHEN 't_oltp DESC' THEN '[ttdpur401200].[t_oltp] DESC'
                        WHEN 't_otbp' THEN '[ttdpur401200].[t_otbp]'
                        WHEN 't_otbp DESC' THEN '[ttdpur401200].[t_otbp] DESC'
                        WHEN 't_sfbp' THEN '[ttdpur401200].[t_sfbp]'
                        WHEN 't_sfbp DESC' THEN '[ttdpur401200].[t_sfbp] DESC'
                        WHEN 't_sfad' THEN '[ttdpur401200].[t_sfad]'
                        WHEN 't_sfad DESC' THEN '[ttdpur401200].[t_sfad] DESC'
                        WHEN 't_sfcn' THEN '[ttdpur401200].[t_sfcn]'
                        WHEN 't_sfcn DESC' THEN '[ttdpur401200].[t_sfcn] DESC'
                        WHEN 't_sfwh' THEN '[ttdpur401200].[t_sfwh]'
                        WHEN 't_sfwh DESC' THEN '[ttdpur401200].[t_sfwh] DESC'
                        WHEN 't_item' THEN '[ttdpur401200].[t_item]'
                        WHEN 't_item DESC' THEN '[ttdpur401200].[t_item] DESC'
                        WHEN 't_effn' THEN '[ttdpur401200].[t_effn]'
                        WHEN 't_effn DESC' THEN '[ttdpur401200].[t_effn] DESC'
                        WHEN 't_sdsc' THEN '[ttdpur401200].[t_sdsc]'
                        WHEN 't_sdsc DESC' THEN '[ttdpur401200].[t_sdsc] DESC'
                        WHEN 't_crrf' THEN '[ttdpur401200].[t_crrf]'
                        WHEN 't_crrf DESC' THEN '[ttdpur401200].[t_crrf] DESC'
                        WHEN 't_citt' THEN '[ttdpur401200].[t_citt]'
                        WHEN 't_citt DESC' THEN '[ttdpur401200].[t_citt] DESC'
                        WHEN 't_crit' THEN '[ttdpur401200].[t_crit]'
                        WHEN 't_crit DESC' THEN '[ttdpur401200].[t_crit] DESC'
                        WHEN 't_mpnr' THEN '[ttdpur401200].[t_mpnr]'
                        WHEN 't_mpnr DESC' THEN '[ttdpur401200].[t_mpnr] DESC'
                        WHEN 't_subc' THEN '[ttdpur401200].[t_subc]'
                        WHEN 't_subc DESC' THEN '[ttdpur401200].[t_subc] DESC'
                        WHEN 't_mpsn' THEN '[ttdpur401200].[t_mpsn]'
                        WHEN 't_mpsn DESC' THEN '[ttdpur401200].[t_mpsn] DESC'
                        WHEN 't_cmnf' THEN '[ttdpur401200].[t_cmnf]'
                        WHEN 't_cmnf DESC' THEN '[ttdpur401200].[t_cmnf] DESC'
                        WHEN 't_mitm' THEN '[ttdpur401200].[t_mitm]'
                        WHEN 't_mitm DESC' THEN '[ttdpur401200].[t_mitm] DESC'
                        WHEN 't_revi' THEN '[ttdpur401200].[t_revi]'
                        WHEN 't_revi DESC' THEN '[ttdpur401200].[t_revi] DESC'
                        WHEN 't_btsp' THEN '[ttdpur401200].[t_btsp]'
                        WHEN 't_btsp DESC' THEN '[ttdpur401200].[t_btsp] DESC'
                        WHEN 't_qual' THEN '[ttdpur401200].[t_qual]'
                        WHEN 't_qual DESC' THEN '[ttdpur401200].[t_qual] DESC'
                        WHEN 't_qoor' THEN '[ttdpur401200].[t_qoor]'
                        WHEN 't_qoor DESC' THEN '[ttdpur401200].[t_qoor] DESC'
                        WHEN 't_cuqp' THEN '[ttdpur401200].[t_cuqp]'
                        WHEN 't_cuqp DESC' THEN '[ttdpur401200].[t_cuqp] DESC'
                        WHEN 't_cvqp' THEN '[ttdpur401200].[t_cvqp]'
                        WHEN 't_cvqp DESC' THEN '[ttdpur401200].[t_cvqp] DESC'
                        WHEN 't_leng' THEN '[ttdpur401200].[t_leng]'
                        WHEN 't_leng DESC' THEN '[ttdpur401200].[t_leng] DESC'
                        WHEN 't_widt' THEN '[ttdpur401200].[t_widt]'
                        WHEN 't_widt DESC' THEN '[ttdpur401200].[t_widt] DESC'
                        WHEN 't_thic' THEN '[ttdpur401200].[t_thic]'
                        WHEN 't_thic DESC' THEN '[ttdpur401200].[t_thic] DESC'
                        WHEN 't_odat' THEN '[ttdpur401200].[t_odat]'
                        WHEN 't_odat DESC' THEN '[ttdpur401200].[t_odat] DESC'
                        WHEN 't_ddta' THEN '[ttdpur401200].[t_ddta]'
                        WHEN 't_ddta DESC' THEN '[ttdpur401200].[t_ddta] DESC'
                        WHEN 't_ddtb' THEN '[ttdpur401200].[t_ddtb]'
                        WHEN 't_ddtb DESC' THEN '[ttdpur401200].[t_ddtb] DESC'
                        WHEN 't_ddtc' THEN '[ttdpur401200].[t_ddtc]'
                        WHEN 't_ddtc DESC' THEN '[ttdpur401200].[t_ddtc] DESC'
                        WHEN 't_ddtd' THEN '[ttdpur401200].[t_ddtd]'
                        WHEN 't_ddtd DESC' THEN '[ttdpur401200].[t_ddtd] DESC'
                        WHEN 't_ddte' THEN '[ttdpur401200].[t_ddte]'
                        WHEN 't_ddte DESC' THEN '[ttdpur401200].[t_ddte] DESC'
                        WHEN 't_ddtf' THEN '[ttdpur401200].[t_ddtf]'
                        WHEN 't_ddtf DESC' THEN '[ttdpur401200].[t_ddtf] DESC'
                        WHEN 't_rdta' THEN '[ttdpur401200].[t_rdta]'
                        WHEN 't_rdta DESC' THEN '[ttdpur401200].[t_rdta] DESC'
                        WHEN 't_pric' THEN '[ttdpur401200].[t_pric]'
                        WHEN 't_pric DESC' THEN '[ttdpur401200].[t_pric] DESC'
                        WHEN 't_porg' THEN '[ttdpur401200].[t_porg]'
                        WHEN 't_porg DESC' THEN '[ttdpur401200].[t_porg] DESC'
                        WHEN 't_pmde' THEN '[ttdpur401200].[t_pmde]'
                        WHEN 't_pmde DESC' THEN '[ttdpur401200].[t_pmde] DESC'
                        WHEN 't_pmse' THEN '[ttdpur401200].[t_pmse]'
                        WHEN 't_pmse DESC' THEN '[ttdpur401200].[t_pmse] DESC'
                        WHEN 't_cupp' THEN '[ttdpur401200].[t_cupp]'
                        WHEN 't_cupp DESC' THEN '[ttdpur401200].[t_cupp] DESC'
                        WHEN 't_cvpp' THEN '[ttdpur401200].[t_cvpp]'
                        WHEN 't_cvpp DESC' THEN '[ttdpur401200].[t_cvpp] DESC'
                        WHEN 't_disc_1' THEN '[ttdpur401200].[t_disc_1]'
                        WHEN 't_disc_1 DESC' THEN '[ttdpur401200].[t_disc_1] DESC'
                        WHEN 't_disc_2' THEN '[ttdpur401200].[t_disc_2]'
                        WHEN 't_disc_2 DESC' THEN '[ttdpur401200].[t_disc_2] DESC'
                        WHEN 't_disc_3' THEN '[ttdpur401200].[t_disc_3]'
                        WHEN 't_disc_3 DESC' THEN '[ttdpur401200].[t_disc_3] DESC'
                        WHEN 't_disc_4' THEN '[ttdpur401200].[t_disc_4]'
                        WHEN 't_disc_4 DESC' THEN '[ttdpur401200].[t_disc_4] DESC'
                        WHEN 't_disc_5' THEN '[ttdpur401200].[t_disc_5]'
                        WHEN 't_disc_5 DESC' THEN '[ttdpur401200].[t_disc_5] DESC'
                        WHEN 't_disc_6' THEN '[ttdpur401200].[t_disc_6]'
                        WHEN 't_disc_6 DESC' THEN '[ttdpur401200].[t_disc_6] DESC'
                        WHEN 't_disc_7' THEN '[ttdpur401200].[t_disc_7]'
                        WHEN 't_disc_7 DESC' THEN '[ttdpur401200].[t_disc_7] DESC'
                        WHEN 't_disc_8' THEN '[ttdpur401200].[t_disc_8]'
                        WHEN 't_disc_8 DESC' THEN '[ttdpur401200].[t_disc_8] DESC'
                        WHEN 't_disc_9' THEN '[ttdpur401200].[t_disc_9]'
                        WHEN 't_disc_9 DESC' THEN '[ttdpur401200].[t_disc_9] DESC'
                        WHEN 't_disc_10' THEN '[ttdpur401200].[t_disc_10]'
                        WHEN 't_disc_10 DESC' THEN '[ttdpur401200].[t_disc_10] DESC'
                        WHEN 't_disc_11' THEN '[ttdpur401200].[t_disc_11]'
                        WHEN 't_disc_11 DESC' THEN '[ttdpur401200].[t_disc_11] DESC'
                        WHEN 't_ldam_1' THEN '[ttdpur401200].[t_ldam_1]'
                        WHEN 't_ldam_1 DESC' THEN '[ttdpur401200].[t_ldam_1] DESC'
                        WHEN 't_ldam_2' THEN '[ttdpur401200].[t_ldam_2]'
                        WHEN 't_ldam_2 DESC' THEN '[ttdpur401200].[t_ldam_2] DESC'
                        WHEN 't_ldam_3' THEN '[ttdpur401200].[t_ldam_3]'
                        WHEN 't_ldam_3 DESC' THEN '[ttdpur401200].[t_ldam_3] DESC'
                        WHEN 't_ldam_4' THEN '[ttdpur401200].[t_ldam_4]'
                        WHEN 't_ldam_4 DESC' THEN '[ttdpur401200].[t_ldam_4] DESC'
                        WHEN 't_ldam_5' THEN '[ttdpur401200].[t_ldam_5]'
                        WHEN 't_ldam_5 DESC' THEN '[ttdpur401200].[t_ldam_5] DESC'
                        WHEN 't_ldam_6' THEN '[ttdpur401200].[t_ldam_6]'
                        WHEN 't_ldam_6 DESC' THEN '[ttdpur401200].[t_ldam_6] DESC'
                        WHEN 't_ldam_7' THEN '[ttdpur401200].[t_ldam_7]'
                        WHEN 't_ldam_7 DESC' THEN '[ttdpur401200].[t_ldam_7] DESC'
                        WHEN 't_ldam_8' THEN '[ttdpur401200].[t_ldam_8]'
                        WHEN 't_ldam_8 DESC' THEN '[ttdpur401200].[t_ldam_8] DESC'
                        WHEN 't_ldam_9' THEN '[ttdpur401200].[t_ldam_9]'
                        WHEN 't_ldam_9 DESC' THEN '[ttdpur401200].[t_ldam_9] DESC'
                        WHEN 't_ldam_10' THEN '[ttdpur401200].[t_ldam_10]'
                        WHEN 't_ldam_10 DESC' THEN '[ttdpur401200].[t_ldam_10] DESC'
                        WHEN 't_ldam_11' THEN '[ttdpur401200].[t_ldam_11]'
                        WHEN 't_ldam_11 DESC' THEN '[ttdpur401200].[t_ldam_11] DESC'
                        WHEN 't_dorg_1' THEN '[ttdpur401200].[t_dorg_1]'
                        WHEN 't_dorg_1 DESC' THEN '[ttdpur401200].[t_dorg_1] DESC'
                        WHEN 't_dorg_2' THEN '[ttdpur401200].[t_dorg_2]'
                        WHEN 't_dorg_2 DESC' THEN '[ttdpur401200].[t_dorg_2] DESC'
                        WHEN 't_dorg_3' THEN '[ttdpur401200].[t_dorg_3]'
                        WHEN 't_dorg_3 DESC' THEN '[ttdpur401200].[t_dorg_3] DESC'
                        WHEN 't_dorg_4' THEN '[ttdpur401200].[t_dorg_4]'
                        WHEN 't_dorg_4 DESC' THEN '[ttdpur401200].[t_dorg_4] DESC'
                        WHEN 't_dorg_5' THEN '[ttdpur401200].[t_dorg_5]'
                        WHEN 't_dorg_5 DESC' THEN '[ttdpur401200].[t_dorg_5] DESC'
                        WHEN 't_dorg_6' THEN '[ttdpur401200].[t_dorg_6]'
                        WHEN 't_dorg_6 DESC' THEN '[ttdpur401200].[t_dorg_6] DESC'
                        WHEN 't_dorg_7' THEN '[ttdpur401200].[t_dorg_7]'
                        WHEN 't_dorg_7 DESC' THEN '[ttdpur401200].[t_dorg_7] DESC'
                        WHEN 't_dorg_8' THEN '[ttdpur401200].[t_dorg_8]'
                        WHEN 't_dorg_8 DESC' THEN '[ttdpur401200].[t_dorg_8] DESC'
                        WHEN 't_dorg_9' THEN '[ttdpur401200].[t_dorg_9]'
                        WHEN 't_dorg_9 DESC' THEN '[ttdpur401200].[t_dorg_9] DESC'
                        WHEN 't_dorg_10' THEN '[ttdpur401200].[t_dorg_10]'
                        WHEN 't_dorg_10 DESC' THEN '[ttdpur401200].[t_dorg_10] DESC'
                        WHEN 't_dorg_11' THEN '[ttdpur401200].[t_dorg_11]'
                        WHEN 't_dorg_11 DESC' THEN '[ttdpur401200].[t_dorg_11] DESC'
                        WHEN 't_dmty_1' THEN '[ttdpur401200].[t_dmty_1]'
                        WHEN 't_dmty_1 DESC' THEN '[ttdpur401200].[t_dmty_1] DESC'
                        WHEN 't_dmty_2' THEN '[ttdpur401200].[t_dmty_2]'
                        WHEN 't_dmty_2 DESC' THEN '[ttdpur401200].[t_dmty_2] DESC'
                        WHEN 't_dmty_3' THEN '[ttdpur401200].[t_dmty_3]'
                        WHEN 't_dmty_3 DESC' THEN '[ttdpur401200].[t_dmty_3] DESC'
                        WHEN 't_dmty_4' THEN '[ttdpur401200].[t_dmty_4]'
                        WHEN 't_dmty_4 DESC' THEN '[ttdpur401200].[t_dmty_4] DESC'
                        WHEN 't_dmty_5' THEN '[ttdpur401200].[t_dmty_5]'
                        WHEN 't_dmty_5 DESC' THEN '[ttdpur401200].[t_dmty_5] DESC'
                        WHEN 't_dmty_6' THEN '[ttdpur401200].[t_dmty_6]'
                        WHEN 't_dmty_6 DESC' THEN '[ttdpur401200].[t_dmty_6] DESC'
                        WHEN 't_dmty_7' THEN '[ttdpur401200].[t_dmty_7]'
                        WHEN 't_dmty_7 DESC' THEN '[ttdpur401200].[t_dmty_7] DESC'
                        WHEN 't_dmty_8' THEN '[ttdpur401200].[t_dmty_8]'
                        WHEN 't_dmty_8 DESC' THEN '[ttdpur401200].[t_dmty_8] DESC'
                        WHEN 't_dmty_9' THEN '[ttdpur401200].[t_dmty_9]'
                        WHEN 't_dmty_9 DESC' THEN '[ttdpur401200].[t_dmty_9] DESC'
                        WHEN 't_dmty_10' THEN '[ttdpur401200].[t_dmty_10]'
                        WHEN 't_dmty_10 DESC' THEN '[ttdpur401200].[t_dmty_10] DESC'
                        WHEN 't_dmty_11' THEN '[ttdpur401200].[t_dmty_11]'
                        WHEN 't_dmty_11 DESC' THEN '[ttdpur401200].[t_dmty_11] DESC'
                        WHEN 't_dmde_1' THEN '[ttdpur401200].[t_dmde_1]'
                        WHEN 't_dmde_1 DESC' THEN '[ttdpur401200].[t_dmde_1] DESC'
                        WHEN 't_dmde_2' THEN '[ttdpur401200].[t_dmde_2]'
                        WHEN 't_dmde_2 DESC' THEN '[ttdpur401200].[t_dmde_2] DESC'
                        WHEN 't_dmde_3' THEN '[ttdpur401200].[t_dmde_3]'
                        WHEN 't_dmde_3 DESC' THEN '[ttdpur401200].[t_dmde_3] DESC'
                        WHEN 't_dmde_4' THEN '[ttdpur401200].[t_dmde_4]'
                        WHEN 't_dmde_4 DESC' THEN '[ttdpur401200].[t_dmde_4] DESC'
                        WHEN 't_dmde_5' THEN '[ttdpur401200].[t_dmde_5]'
                        WHEN 't_dmde_5 DESC' THEN '[ttdpur401200].[t_dmde_5] DESC'
                        WHEN 't_dmde_6' THEN '[ttdpur401200].[t_dmde_6]'
                        WHEN 't_dmde_6 DESC' THEN '[ttdpur401200].[t_dmde_6] DESC'
                        WHEN 't_dmde_7' THEN '[ttdpur401200].[t_dmde_7]'
                        WHEN 't_dmde_7 DESC' THEN '[ttdpur401200].[t_dmde_7] DESC'
                        WHEN 't_dmde_8' THEN '[ttdpur401200].[t_dmde_8]'
                        WHEN 't_dmde_8 DESC' THEN '[ttdpur401200].[t_dmde_8] DESC'
                        WHEN 't_dmde_9' THEN '[ttdpur401200].[t_dmde_9]'
                        WHEN 't_dmde_9 DESC' THEN '[ttdpur401200].[t_dmde_9] DESC'
                        WHEN 't_dmde_10' THEN '[ttdpur401200].[t_dmde_10]'
                        WHEN 't_dmde_10 DESC' THEN '[ttdpur401200].[t_dmde_10] DESC'
                        WHEN 't_dmde_11' THEN '[ttdpur401200].[t_dmde_11]'
                        WHEN 't_dmde_11 DESC' THEN '[ttdpur401200].[t_dmde_11] DESC'
                        WHEN 't_dmse_1' THEN '[ttdpur401200].[t_dmse_1]'
                        WHEN 't_dmse_1 DESC' THEN '[ttdpur401200].[t_dmse_1] DESC'
                        WHEN 't_dmse_2' THEN '[ttdpur401200].[t_dmse_2]'
                        WHEN 't_dmse_2 DESC' THEN '[ttdpur401200].[t_dmse_2] DESC'
                        WHEN 't_dmse_3' THEN '[ttdpur401200].[t_dmse_3]'
                        WHEN 't_dmse_3 DESC' THEN '[ttdpur401200].[t_dmse_3] DESC'
                        WHEN 't_dmse_4' THEN '[ttdpur401200].[t_dmse_4]'
                        WHEN 't_dmse_4 DESC' THEN '[ttdpur401200].[t_dmse_4] DESC'
                        WHEN 't_dmse_5' THEN '[ttdpur401200].[t_dmse_5]'
                        WHEN 't_dmse_5 DESC' THEN '[ttdpur401200].[t_dmse_5] DESC'
                        WHEN 't_dmse_6' THEN '[ttdpur401200].[t_dmse_6]'
                        WHEN 't_dmse_6 DESC' THEN '[ttdpur401200].[t_dmse_6] DESC'
                        WHEN 't_dmse_7' THEN '[ttdpur401200].[t_dmse_7]'
                        WHEN 't_dmse_7 DESC' THEN '[ttdpur401200].[t_dmse_7] DESC'
                        WHEN 't_dmse_8' THEN '[ttdpur401200].[t_dmse_8]'
                        WHEN 't_dmse_8 DESC' THEN '[ttdpur401200].[t_dmse_8] DESC'
                        WHEN 't_dmse_9' THEN '[ttdpur401200].[t_dmse_9]'
                        WHEN 't_dmse_9 DESC' THEN '[ttdpur401200].[t_dmse_9] DESC'
                        WHEN 't_dmse_10' THEN '[ttdpur401200].[t_dmse_10]'
                        WHEN 't_dmse_10 DESC' THEN '[ttdpur401200].[t_dmse_10] DESC'
                        WHEN 't_dmse_11' THEN '[ttdpur401200].[t_dmse_11]'
                        WHEN 't_dmse_11 DESC' THEN '[ttdpur401200].[t_dmse_11] DESC'
                        WHEN 't_dmth_1' THEN '[ttdpur401200].[t_dmth_1]'
                        WHEN 't_dmth_1 DESC' THEN '[ttdpur401200].[t_dmth_1] DESC'
                        WHEN 't_dmth_2' THEN '[ttdpur401200].[t_dmth_2]'
                        WHEN 't_dmth_2 DESC' THEN '[ttdpur401200].[t_dmth_2] DESC'
                        WHEN 't_dmth_3' THEN '[ttdpur401200].[t_dmth_3]'
                        WHEN 't_dmth_3 DESC' THEN '[ttdpur401200].[t_dmth_3] DESC'
                        WHEN 't_dmth_4' THEN '[ttdpur401200].[t_dmth_4]'
                        WHEN 't_dmth_4 DESC' THEN '[ttdpur401200].[t_dmth_4] DESC'
                        WHEN 't_dmth_5' THEN '[ttdpur401200].[t_dmth_5]'
                        WHEN 't_dmth_5 DESC' THEN '[ttdpur401200].[t_dmth_5] DESC'
                        WHEN 't_dmth_6' THEN '[ttdpur401200].[t_dmth_6]'
                        WHEN 't_dmth_6 DESC' THEN '[ttdpur401200].[t_dmth_6] DESC'
                        WHEN 't_dmth_7' THEN '[ttdpur401200].[t_dmth_7]'
                        WHEN 't_dmth_7 DESC' THEN '[ttdpur401200].[t_dmth_7] DESC'
                        WHEN 't_dmth_8' THEN '[ttdpur401200].[t_dmth_8]'
                        WHEN 't_dmth_8 DESC' THEN '[ttdpur401200].[t_dmth_8] DESC'
                        WHEN 't_dmth_9' THEN '[ttdpur401200].[t_dmth_9]'
                        WHEN 't_dmth_9 DESC' THEN '[ttdpur401200].[t_dmth_9] DESC'
                        WHEN 't_dmth_10' THEN '[ttdpur401200].[t_dmth_10]'
                        WHEN 't_dmth_10 DESC' THEN '[ttdpur401200].[t_dmth_10] DESC'
                        WHEN 't_dmth_11' THEN '[ttdpur401200].[t_dmth_11]'
                        WHEN 't_dmth_11 DESC' THEN '[ttdpur401200].[t_dmth_11] DESC'
                        WHEN 't_cdis_1' THEN '[ttdpur401200].[t_cdis_1]'
                        WHEN 't_cdis_1 DESC' THEN '[ttdpur401200].[t_cdis_1] DESC'
                        WHEN 't_cdis_2' THEN '[ttdpur401200].[t_cdis_2]'
                        WHEN 't_cdis_2 DESC' THEN '[ttdpur401200].[t_cdis_2] DESC'
                        WHEN 't_cdis_3' THEN '[ttdpur401200].[t_cdis_3]'
                        WHEN 't_cdis_3 DESC' THEN '[ttdpur401200].[t_cdis_3] DESC'
                        WHEN 't_cdis_4' THEN '[ttdpur401200].[t_cdis_4]'
                        WHEN 't_cdis_4 DESC' THEN '[ttdpur401200].[t_cdis_4] DESC'
                        WHEN 't_cdis_5' THEN '[ttdpur401200].[t_cdis_5]'
                        WHEN 't_cdis_5 DESC' THEN '[ttdpur401200].[t_cdis_5] DESC'
                        WHEN 't_cdis_6' THEN '[ttdpur401200].[t_cdis_6]'
                        WHEN 't_cdis_6 DESC' THEN '[ttdpur401200].[t_cdis_6] DESC'
                        WHEN 't_cdis_7' THEN '[ttdpur401200].[t_cdis_7]'
                        WHEN 't_cdis_7 DESC' THEN '[ttdpur401200].[t_cdis_7] DESC'
                        WHEN 't_cdis_8' THEN '[ttdpur401200].[t_cdis_8]'
                        WHEN 't_cdis_8 DESC' THEN '[ttdpur401200].[t_cdis_8] DESC'
                        WHEN 't_cdis_9' THEN '[ttdpur401200].[t_cdis_9]'
                        WHEN 't_cdis_9 DESC' THEN '[ttdpur401200].[t_cdis_9] DESC'
                        WHEN 't_cdis_10' THEN '[ttdpur401200].[t_cdis_10]'
                        WHEN 't_cdis_10 DESC' THEN '[ttdpur401200].[t_cdis_10] DESC'
                        WHEN 't_cdis_11' THEN '[ttdpur401200].[t_cdis_11]'
                        WHEN 't_cdis_11 DESC' THEN '[ttdpur401200].[t_cdis_11] DESC'
                        WHEN 't_dtrm' THEN '[ttdpur401200].[t_dtrm]'
                        WHEN 't_dtrm DESC' THEN '[ttdpur401200].[t_dtrm] DESC'
                        WHEN 't_elgb' THEN '[ttdpur401200].[t_elgb]'
                        WHEN 't_elgb DESC' THEN '[ttdpur401200].[t_elgb] DESC'
                        WHEN 't_stdc' THEN '[ttdpur401200].[t_stdc]'
                        WHEN 't_stdc DESC' THEN '[ttdpur401200].[t_stdc] DESC'
                        WHEN 't_oamt' THEN '[ttdpur401200].[t_oamt]'
                        WHEN 't_oamt DESC' THEN '[ttdpur401200].[t_oamt] DESC'
                        WHEN 't_rcno' THEN '[ttdpur401200].[t_rcno]'
                        WHEN 't_rcno DESC' THEN '[ttdpur401200].[t_rcno] DESC'
                        WHEN 't_rseq' THEN '[ttdpur401200].[t_rseq]'
                        WHEN 't_rseq DESC' THEN '[ttdpur401200].[t_rseq] DESC'
                        WHEN 't_dino' THEN '[ttdpur401200].[t_dino]'
                        WHEN 't_dino DESC' THEN '[ttdpur401200].[t_dino] DESC'
                        WHEN 't_qips' THEN '[ttdpur401200].[t_qips]'
                        WHEN 't_qips DESC' THEN '[ttdpur401200].[t_qips] DESC'
                        WHEN 't_qidl' THEN '[ttdpur401200].[t_qidl]'
                        WHEN 't_qidl DESC' THEN '[ttdpur401200].[t_qidl] DESC'
                        WHEN 't_qiap' THEN '[ttdpur401200].[t_qiap]'
                        WHEN 't_qiap DESC' THEN '[ttdpur401200].[t_qiap] DESC'
                        WHEN 't_crej' THEN '[ttdpur401200].[t_crej]'
                        WHEN 't_crej DESC' THEN '[ttdpur401200].[t_crej] DESC'
                        WHEN 't_qirj' THEN '[ttdpur401200].[t_qirj]'
                        WHEN 't_qirj DESC' THEN '[ttdpur401200].[t_qirj] DESC'
                        WHEN 't_qibo' THEN '[ttdpur401200].[t_qibo]'
                        WHEN 't_qibo DESC' THEN '[ttdpur401200].[t_qibo] DESC'
                        WHEN 't_qbbc' THEN '[ttdpur401200].[t_qbbc]'
                        WHEN 't_qbbc DESC' THEN '[ttdpur401200].[t_qbbc] DESC'
                        WHEN 't_cubp' THEN '[ttdpur401200].[t_cubp]'
                        WHEN 't_cubp DESC' THEN '[ttdpur401200].[t_cubp] DESC'
                        WHEN 't_cvbp' THEN '[ttdpur401200].[t_cvbp]'
                        WHEN 't_cvbp DESC' THEN '[ttdpur401200].[t_cvbp] DESC'
                        WHEN 't_fire' THEN '[ttdpur401200].[t_fire]'
                        WHEN 't_fire DESC' THEN '[ttdpur401200].[t_fire] DESC'
                        WHEN 't_qibp' THEN '[ttdpur401200].[t_qibp]'
                        WHEN 't_qibp DESC' THEN '[ttdpur401200].[t_qibp] DESC'
                        WHEN 't_ddon' THEN '[ttdpur401200].[t_ddon]'
                        WHEN 't_ddon DESC' THEN '[ttdpur401200].[t_ddon] DESC'
                        WHEN 't_lseq' THEN '[ttdpur401200].[t_lseq]'
                        WHEN 't_lseq DESC' THEN '[ttdpur401200].[t_lseq] DESC'
                        WHEN 't_pseq' THEN '[ttdpur401200].[t_pseq]'
                        WHEN 't_pseq DESC' THEN '[ttdpur401200].[t_pseq] DESC'
                        WHEN 't_amld' THEN '[ttdpur401200].[t_amld]'
                        WHEN 't_amld DESC' THEN '[ttdpur401200].[t_amld] DESC'
                        WHEN 't_amod' THEN '[ttdpur401200].[t_amod]'
                        WHEN 't_amod DESC' THEN '[ttdpur401200].[t_amod] DESC'
                        WHEN 't_damt' THEN '[ttdpur401200].[t_damt]'
                        WHEN 't_damt DESC' THEN '[ttdpur401200].[t_damt] DESC'
                        WHEN 't_stsc' THEN '[ttdpur401200].[t_stsc]'
                        WHEN 't_stsc DESC' THEN '[ttdpur401200].[t_stsc] DESC'
                        WHEN 't_stsd' THEN '[ttdpur401200].[t_stsd]'
                        WHEN 't_stsd DESC' THEN '[ttdpur401200].[t_stsd] DESC'
                        WHEN 't_vryn' THEN '[ttdpur401200].[t_vryn]'
                        WHEN 't_vryn DESC' THEN '[ttdpur401200].[t_vryn] DESC'
                        WHEN 't_invn' THEN '[ttdpur401200].[t_invn]'
                        WHEN 't_invn DESC' THEN '[ttdpur401200].[t_invn] DESC'
                        WHEN 't_invd' THEN '[ttdpur401200].[t_invd]'
                        WHEN 't_invd DESC' THEN '[ttdpur401200].[t_invd] DESC'
                        WHEN 't_copr_1' THEN '[ttdpur401200].[t_copr_1]'
                        WHEN 't_copr_1 DESC' THEN '[ttdpur401200].[t_copr_1] DESC'
                        WHEN 't_copr_2' THEN '[ttdpur401200].[t_copr_2]'
                        WHEN 't_copr_2 DESC' THEN '[ttdpur401200].[t_copr_2] DESC'
                        WHEN 't_copr_3' THEN '[ttdpur401200].[t_copr_3]'
                        WHEN 't_copr_3 DESC' THEN '[ttdpur401200].[t_copr_3] DESC'
                        WHEN 't_coop_1' THEN '[ttdpur401200].[t_coop_1]'
                        WHEN 't_coop_1 DESC' THEN '[ttdpur401200].[t_coop_1] DESC'
                        WHEN 't_coop_2' THEN '[ttdpur401200].[t_coop_2]'
                        WHEN 't_coop_2 DESC' THEN '[ttdpur401200].[t_coop_2] DESC'
                        WHEN 't_coop_3' THEN '[ttdpur401200].[t_coop_3]'
                        WHEN 't_coop_3 DESC' THEN '[ttdpur401200].[t_coop_3] DESC'
                        WHEN 't_cpcp' THEN '[ttdpur401200].[t_cpcp]'
                        WHEN 't_cpcp DESC' THEN '[ttdpur401200].[t_cpcp] DESC'
                        WHEN 't_cwar' THEN '[ttdpur401200].[t_cwar]'
                        WHEN 't_cwar DESC' THEN '[ttdpur401200].[t_cwar] DESC'
                        WHEN 't_cadr' THEN '[ttdpur401200].[t_cadr]'
                        WHEN 't_cadr DESC' THEN '[ttdpur401200].[t_cadr] DESC'
                        WHEN 't_lsel' THEN '[ttdpur401200].[t_lsel]'
                        WHEN 't_lsel DESC' THEN '[ttdpur401200].[t_lsel] DESC'
                        WHEN 't_clot' THEN '[ttdpur401200].[t_clot]'
                        WHEN 't_clot DESC' THEN '[ttdpur401200].[t_clot] DESC'
                        WHEN 't_cprj' THEN '[ttdpur401200].[t_cprj]'
                        WHEN 't_cprj DESC' THEN '[ttdpur401200].[t_cprj] DESC'
                        WHEN 't_cspa' THEN '[ttdpur401200].[t_cspa]'
                        WHEN 't_cspa DESC' THEN '[ttdpur401200].[t_cspa] DESC'
                        WHEN 't_cact' THEN '[ttdpur401200].[t_cact]'
                        WHEN 't_cact DESC' THEN '[ttdpur401200].[t_cact] DESC'
                        WHEN 't_cstl' THEN '[ttdpur401200].[t_cstl]'
                        WHEN 't_cstl DESC' THEN '[ttdpur401200].[t_cstl] DESC'
                        WHEN 't_ccco' THEN '[ttdpur401200].[t_ccco]'
                        WHEN 't_ccco DESC' THEN '[ttdpur401200].[t_ccco] DESC'
                        WHEN 't_ctrj' THEN '[ttdpur401200].[t_ctrj]'
                        WHEN 't_ctrj DESC' THEN '[ttdpur401200].[t_ctrj] DESC'
                        WHEN 't_akcd' THEN '[ttdpur401200].[t_akcd]'
                        WHEN 't_akcd DESC' THEN '[ttdpur401200].[t_akcd] DESC'
                        WHEN 't_cfrw' THEN '[ttdpur401200].[t_cfrw]'
                        WHEN 't_cfrw DESC' THEN '[ttdpur401200].[t_cfrw] DESC'
                        WHEN 't_crbn' THEN '[ttdpur401200].[t_crbn]'
                        WHEN 't_crbn DESC' THEN '[ttdpur401200].[t_crbn] DESC'
                        WHEN 't_clyn' THEN '[ttdpur401200].[t_clyn]'
                        WHEN 't_clyn DESC' THEN '[ttdpur401200].[t_clyn] DESC'
                        WHEN 't_cpva' THEN '[ttdpur401200].[t_cpva]'
                        WHEN 't_cpva DESC' THEN '[ttdpur401200].[t_cpva] DESC'
                        WHEN 't_crcd' THEN '[ttdpur401200].[t_crcd]'
                        WHEN 't_crcd DESC' THEN '[ttdpur401200].[t_crcd] DESC'
                        WHEN 't_ctcd' THEN '[ttdpur401200].[t_ctcd]'
                        WHEN 't_ctcd DESC' THEN '[ttdpur401200].[t_ctcd] DESC'
                        WHEN 't_cosn' THEN '[ttdpur401200].[t_cosn]'
                        WHEN 't_cosn DESC' THEN '[ttdpur401200].[t_cosn] DESC'
                        WHEN 't_qiiv' THEN '[ttdpur401200].[t_qiiv]'
                        WHEN 't_qiiv DESC' THEN '[ttdpur401200].[t_qiiv] DESC'
                        WHEN 't_iamt' THEN '[ttdpur401200].[t_iamt]'
                        WHEN 't_iamt DESC' THEN '[ttdpur401200].[t_iamt] DESC'
                        WHEN 't_comm' THEN '[ttdpur401200].[t_comm]'
                        WHEN 't_comm DESC' THEN '[ttdpur401200].[t_comm] DESC'
                        WHEN 't_appr' THEN '[ttdpur401200].[t_appr]'
                        WHEN 't_appr DESC' THEN '[ttdpur401200].[t_appr] DESC'
                        WHEN 't_ccty' THEN '[ttdpur401200].[t_ccty]'
                        WHEN 't_ccty DESC' THEN '[ttdpur401200].[t_ccty] DESC'
                        WHEN 't_cvat' THEN '[ttdpur401200].[t_cvat]'
                        WHEN 't_cvat DESC' THEN '[ttdpur401200].[t_cvat] DESC'
                        WHEN 't_bptc' THEN '[ttdpur401200].[t_bptc]'
                        WHEN 't_bptc DESC' THEN '[ttdpur401200].[t_bptc] DESC'
                        WHEN 't_exmt' THEN '[ttdpur401200].[t_exmt]'
                        WHEN 't_exmt DESC' THEN '[ttdpur401200].[t_exmt] DESC'
                        WHEN 't_ceno' THEN '[ttdpur401200].[t_ceno]'
                        WHEN 't_ceno DESC' THEN '[ttdpur401200].[t_ceno] DESC'
                        WHEN 't_rcod' THEN '[ttdpur401200].[t_rcod]'
                        WHEN 't_rcod DESC' THEN '[ttdpur401200].[t_rcod] DESC'
                        WHEN 't_bpcl' THEN '[ttdpur401200].[t_bpcl]'
                        WHEN 't_bpcl DESC' THEN '[ttdpur401200].[t_bpcl] DESC'
                        WHEN 't_taxp' THEN '[ttdpur401200].[t_taxp]'
                        WHEN 't_taxp DESC' THEN '[ttdpur401200].[t_taxp] DESC'
                        WHEN 't_gefo' THEN '[ttdpur401200].[t_gefo]'
                        WHEN 't_gefo DESC' THEN '[ttdpur401200].[t_gefo] DESC'
                        WHEN 't_ldat' THEN '[ttdpur401200].[t_ldat]'
                        WHEN 't_ldat DESC' THEN '[ttdpur401200].[t_ldat] DESC'
                        WHEN 't_serv' THEN '[ttdpur401200].[t_serv]'
                        WHEN 't_serv DESC' THEN '[ttdpur401200].[t_serv] DESC'
                        WHEN 't_casi' THEN '[ttdpur401200].[t_casi]'
                        WHEN 't_casi DESC' THEN '[ttdpur401200].[t_casi] DESC'
                        WHEN 't_ptpe' THEN '[ttdpur401200].[t_ptpe]'
                        WHEN 't_ptpe DESC' THEN '[ttdpur401200].[t_ptpe] DESC'
                        WHEN 't_glco' THEN '[ttdpur401200].[t_glco]'
                        WHEN 't_glco DESC' THEN '[ttdpur401200].[t_glco] DESC'
                        WHEN 't_sbim' THEN '[ttdpur401200].[t_sbim]'
                        WHEN 't_sbim DESC' THEN '[ttdpur401200].[t_sbim] DESC'
                        WHEN 't_paft' THEN '[ttdpur401200].[t_paft]'
                        WHEN 't_paft DESC' THEN '[ttdpur401200].[t_paft] DESC'
                        WHEN 't_sbmt' THEN '[ttdpur401200].[t_sbmt]'
                        WHEN 't_sbmt DESC' THEN '[ttdpur401200].[t_sbmt] DESC'
                        WHEN 't_cuva' THEN '[ttdpur401200].[t_cuva]'
                        WHEN 't_cuva DESC' THEN '[ttdpur401200].[t_cuva] DESC'
                        WHEN 't_cono' THEN '[ttdpur401200].[t_cono]'
                        WHEN 't_cono DESC' THEN '[ttdpur401200].[t_cono] DESC'
                        WHEN 't_cpon' THEN '[ttdpur401200].[t_cpon]'
                        WHEN 't_cpon DESC' THEN '[ttdpur401200].[t_cpon] DESC'
                        WHEN 't_ccof' THEN '[ttdpur401200].[t_ccof]'
                        WHEN 't_ccof DESC' THEN '[ttdpur401200].[t_ccof] DESC'
                        WHEN 't_cnig' THEN '[ttdpur401200].[t_cnig]'
                        WHEN 't_cnig DESC' THEN '[ttdpur401200].[t_cnig] DESC'
                        WHEN 't_paya' THEN '[ttdpur401200].[t_paya]'
                        WHEN 't_paya DESC' THEN '[ttdpur401200].[t_paya] DESC'
                        WHEN 't_cpay' THEN '[ttdpur401200].[t_cpay]'
                        WHEN 't_cpay DESC' THEN '[ttdpur401200].[t_cpay] DESC'
                        WHEN 't_cdec' THEN '[ttdpur401200].[t_cdec]'
                        WHEN 't_cdec DESC' THEN '[ttdpur401200].[t_cdec] DESC'
                        WHEN 't_ptpa' THEN '[ttdpur401200].[t_ptpa]'
                        WHEN 't_ptpa DESC' THEN '[ttdpur401200].[t_ptpa] DESC'
                        WHEN 't_pmnt' THEN '[ttdpur401200].[t_pmnt]'
                        WHEN 't_pmnt DESC' THEN '[ttdpur401200].[t_pmnt] DESC'
                        WHEN 't_pmni' THEN '[ttdpur401200].[t_pmni]'
                        WHEN 't_pmni DESC' THEN '[ttdpur401200].[t_pmni] DESC'
                        WHEN 't_pmnd' THEN '[ttdpur401200].[t_pmnd]'
                        WHEN 't_pmnd DESC' THEN '[ttdpur401200].[t_pmnd] DESC'
                        WHEN 't_owns' THEN '[ttdpur401200].[t_owns]'
                        WHEN 't_owns DESC' THEN '[ttdpur401200].[t_owns] DESC'
                        WHEN 't_lccl' THEN '[ttdpur401200].[t_lccl]'
                        WHEN 't_lccl DESC' THEN '[ttdpur401200].[t_lccl] DESC'
                        WHEN 't_spcn' THEN '[ttdpur401200].[t_spcn]'
                        WHEN 't_spcn DESC' THEN '[ttdpur401200].[t_spcn] DESC'
                        WHEN 't_bgxc' THEN '[ttdpur401200].[t_bgxc]'
                        WHEN 't_bgxc DESC' THEN '[ttdpur401200].[t_bgxc] DESC'
                        WHEN 't_cpcl' THEN '[ttdpur401200].[t_cpcl]'
                        WHEN 't_cpcl DESC' THEN '[ttdpur401200].[t_cpcl] DESC'
                        WHEN 't_cpln' THEN '[ttdpur401200].[t_cpln]'
                        WHEN 't_cpln DESC' THEN '[ttdpur401200].[t_cpln] DESC'
                        WHEN 't_csgp' THEN '[ttdpur401200].[t_csgp]'
                        WHEN 't_csgp DESC' THEN '[ttdpur401200].[t_csgp] DESC'
                        WHEN 't_acti' THEN '[ttdpur401200].[t_acti]'
                        WHEN 't_acti DESC' THEN '[ttdpur401200].[t_acti] DESC'
                        WHEN 't_pmsk' THEN '[ttdpur401200].[t_pmsk]'
                        WHEN 't_pmsk DESC' THEN '[ttdpur401200].[t_pmsk] DESC'
                        WHEN 't_rnso_l' THEN '[ttdpur401200].[t_rnso_l]'
                        WHEN 't_rnso_l DESC' THEN '[ttdpur401200].[t_rnso_l] DESC'
                        WHEN 't_rnsb_l' THEN '[ttdpur401200].[t_rnsb_l]'
                        WHEN 't_rnsb_l DESC' THEN '[ttdpur401200].[t_rnsb_l] DESC'
                        WHEN 't_ecif_l' THEN '[ttdpur401200].[t_ecif_l]'
                        WHEN 't_ecif_l DESC' THEN '[ttdpur401200].[t_ecif_l] DESC'
                        WHEN 't_assv_l' THEN '[ttdpur401200].[t_assv_l]'
                        WHEN 't_assv_l DESC' THEN '[ttdpur401200].[t_assv_l] DESC'
                        WHEN 't_elco_l' THEN '[ttdpur401200].[t_elco_l]'
                        WHEN 't_elco_l DESC' THEN '[ttdpur401200].[t_elco_l] DESC'
                        WHEN 't_ihsn_l' THEN '[ttdpur401200].[t_ihsn_l]'
                        WHEN 't_ihsn_l DESC' THEN '[ttdpur401200].[t_ihsn_l] DESC'
                        WHEN 't_mrpo_l' THEN '[ttdpur401200].[t_mrpo_l]'
                        WHEN 't_mrpo_l DESC' THEN '[ttdpur401200].[t_mrpo_l] DESC'
                        WHEN 't_iexb_l' THEN '[ttdpur401200].[t_iexb_l]'
                        WHEN 't_iexb_l DESC' THEN '[ttdpur401200].[t_iexb_l] DESC'
                        WHEN 't_icen_l' THEN '[ttdpur401200].[t_icen_l]'
                        WHEN 't_icen_l DESC' THEN '[ttdpur401200].[t_icen_l] DESC'
                        WHEN 't_imca_l' THEN '[ttdpur401200].[t_imca_l]'
                        WHEN 't_imca_l DESC' THEN '[ttdpur401200].[t_imca_l] DESC'
                        WHEN 't_exca_l' THEN '[ttdpur401200].[t_exca_l]'
                        WHEN 't_exca_l DESC' THEN '[ttdpur401200].[t_exca_l] DESC'
                        WHEN 't_mrpe_l' THEN '[ttdpur401200].[t_mrpe_l]'
                        WHEN 't_mrpe_l DESC' THEN '[ttdpur401200].[t_mrpe_l] DESC'
                        WHEN 't_hcod_l' THEN '[ttdpur401200].[t_hcod_l]'
                        WHEN 't_hcod_l DESC' THEN '[ttdpur401200].[t_hcod_l] DESC'
                        WHEN 't_cenv_l' THEN '[ttdpur401200].[t_cenv_l]'
                        WHEN 't_cenv_l DESC' THEN '[ttdpur401200].[t_cenv_l] DESC'
                        WHEN 't_icat_l' THEN '[ttdpur401200].[t_icat_l]'
                        WHEN 't_icat_l DESC' THEN '[ttdpur401200].[t_icat_l] DESC'
                        WHEN 't_asoe_l' THEN '[ttdpur401200].[t_asoe_l]'
                        WHEN 't_asoe_l DESC' THEN '[ttdpur401200].[t_asoe_l] DESC'
                        WHEN 't_asve_l' THEN '[ttdpur401200].[t_asve_l]'
                        WHEN 't_asve_l DESC' THEN '[ttdpur401200].[t_asve_l] DESC'
                        WHEN 't_dise_l' THEN '[ttdpur401200].[t_dise_l]'
                        WHEN 't_dise_l DESC' THEN '[ttdpur401200].[t_dise_l] DESC'
                        WHEN 't_fase_l' THEN '[ttdpur401200].[t_fase_l]'
                        WHEN 't_fase_l DESC' THEN '[ttdpur401200].[t_fase_l] DESC'
                        WHEN 't_asov_l' THEN '[ttdpur401200].[t_asov_l]'
                        WHEN 't_asov_l DESC' THEN '[ttdpur401200].[t_asov_l] DESC'
                        WHEN 't_asvv_l' THEN '[ttdpur401200].[t_asvv_l]'
                        WHEN 't_asvv_l DESC' THEN '[ttdpur401200].[t_asvv_l] DESC'
                        WHEN 't_disv_l' THEN '[ttdpur401200].[t_disv_l]'
                        WHEN 't_disv_l DESC' THEN '[ttdpur401200].[t_disv_l] DESC'
                        WHEN 't_fasv_l' THEN '[ttdpur401200].[t_fasv_l]'
                        WHEN 't_fasv_l DESC' THEN '[ttdpur401200].[t_fasv_l] DESC'
                        WHEN 't_asos_l' THEN '[ttdpur401200].[t_asos_l]'
                        WHEN 't_asos_l DESC' THEN '[ttdpur401200].[t_asos_l] DESC'
                        WHEN 't_asvs_l' THEN '[ttdpur401200].[t_asvs_l]'
                        WHEN 't_asvs_l DESC' THEN '[ttdpur401200].[t_asvs_l] DESC'
                        WHEN 't_diss_l' THEN '[ttdpur401200].[t_diss_l]'
                        WHEN 't_diss_l DESC' THEN '[ttdpur401200].[t_diss_l] DESC'
                        WHEN 't_fass_l' THEN '[ttdpur401200].[t_fass_l]'
                        WHEN 't_fass_l DESC' THEN '[ttdpur401200].[t_fass_l] DESC'
                        WHEN 't_iecc_l' THEN '[ttdpur401200].[t_iecc_l]'
                        WHEN 't_iecc_l DESC' THEN '[ttdpur401200].[t_iecc_l] DESC'
                        WHEN 't_mrpv_l' THEN '[ttdpur401200].[t_mrpv_l]'
                        WHEN 't_mrpv_l DESC' THEN '[ttdpur401200].[t_mrpv_l] DESC'
                        WHEN 't_mrps_l' THEN '[ttdpur401200].[t_mrps_l]'
                        WHEN 't_mrps_l DESC' THEN '[ttdpur401200].[t_mrps_l] DESC'
                        WHEN 't_reno_l' THEN '[ttdpur401200].[t_reno_l]'
                        WHEN 't_reno_l DESC' THEN '[ttdpur401200].[t_reno_l] DESC'
                        WHEN 't_rcln_l' THEN '[ttdpur401200].[t_rcln_l]'
                        WHEN 't_rcln_l DESC' THEN '[ttdpur401200].[t_rcln_l] DESC'
                        WHEN 't_mrpi_l' THEN '[ttdpur401200].[t_mrpi_l]'
                        WHEN 't_mrpi_l DESC' THEN '[ttdpur401200].[t_mrpi_l] DESC'
                        WHEN 't_ocim_l' THEN '[ttdpur401200].[t_ocim_l]'
                        WHEN 't_ocim_l DESC' THEN '[ttdpur401200].[t_ocim_l] DESC'
                        WHEN 't_ocio_l' THEN '[ttdpur401200].[t_ocio_l]'
                        WHEN 't_ocio_l DESC' THEN '[ttdpur401200].[t_ocio_l] DESC'
                        WHEN 't_extx_l' THEN '[ttdpur401200].[t_extx_l]'
                        WHEN 't_extx_l DESC' THEN '[ttdpur401200].[t_extx_l] DESC'
                        WHEN 't_cltx_l' THEN '[ttdpur401200].[t_cltx_l]'
                        WHEN 't_cltx_l DESC' THEN '[ttdpur401200].[t_cltx_l] DESC'
                        WHEN 't_lacm_l' THEN '[ttdpur401200].[t_lacm_l]'
                        WHEN 't_lacm_l DESC' THEN '[ttdpur401200].[t_lacm_l] DESC'
                        WHEN 't_tase_l' THEN '[ttdpur401200].[t_tase_l]'
                        WHEN 't_tase_l DESC' THEN '[ttdpur401200].[t_tase_l] DESC'
                        WHEN 't_tasv_l' THEN '[ttdpur401200].[t_tasv_l]'
                        WHEN 't_tasv_l DESC' THEN '[ttdpur401200].[t_tasv_l] DESC'
                        WHEN 't_tass_l' THEN '[ttdpur401200].[t_tass_l]'
                        WHEN 't_tass_l DESC' THEN '[ttdpur401200].[t_tass_l] DESC'
                        WHEN 't_uiac_l' THEN '[ttdpur401200].[t_uiac_l]'
                        WHEN 't_uiac_l DESC' THEN '[ttdpur401200].[t_uiac_l] DESC'
                        WHEN 't_uaig_l' THEN '[ttdpur401200].[t_uaig_l]'
                        WHEN 't_uaig_l DESC' THEN '[ttdpur401200].[t_uaig_l] DESC'
                        WHEN 't_txin_l' THEN '[ttdpur401200].[t_txin_l]'
                        WHEN 't_txin_l DESC' THEN '[ttdpur401200].[t_txin_l] DESC'
                        WHEN 't_gsub_l' THEN '[ttdpur401200].[t_gsub_l]'
                        WHEN 't_gsub_l DESC' THEN '[ttdpur401200].[t_gsub_l] DESC'
                        WHEN 't_txta' THEN '[ttdpur401200].[t_txta]'
                        WHEN 't_txta DESC' THEN '[ttdpur401200].[t_txta] DESC'
                        WHEN 't_btx1' THEN '[ttdpur401200].[t_btx1]'
                        WHEN 't_btx1 DESC' THEN '[ttdpur401200].[t_btx1] DESC'
                        WHEN 't_btx2' THEN '[ttdpur401200].[t_btx2]'
                        WHEN 't_btx2 DESC' THEN '[ttdpur401200].[t_btx2] DESC'
                        WHEN 't_cdf_ldat' THEN '[ttdpur401200].[t_cdf_ldat]'
                        WHEN 't_cdf_ldat DESC' THEN '[ttdpur401200].[t_cdf_ldat] DESC'
                        WHEN 't_Refcntd' THEN '[ttdpur401200].[t_Refcntd]'
                        WHEN 't_Refcntd DESC' THEN '[ttdpur401200].[t_Refcntd] DESC'
                        WHEN 't_Refcntu' THEN '[ttdpur401200].[t_Refcntu]'
                        WHEN 't_Refcntu DESC' THEN '[ttdpur401200].[t_Refcntu] DESC'
                        WHEN 't_asog_l' THEN '[ttdpur401200].[t_asog_l]'
                        WHEN 't_asog_l DESC' THEN '[ttdpur401200].[t_asog_l] DESC'
                        WHEN 't_asoi_l' THEN '[ttdpur401200].[t_asoi_l]'
                        WHEN 't_asoi_l DESC' THEN '[ttdpur401200].[t_asoi_l] DESC'
                        WHEN 't_asvg_l' THEN '[ttdpur401200].[t_asvg_l]'
                        WHEN 't_asvg_l DESC' THEN '[ttdpur401200].[t_asvg_l] DESC'
                        WHEN 't_atfr_l' THEN '[ttdpur401200].[t_atfr_l]'
                        WHEN 't_atfr_l DESC' THEN '[ttdpur401200].[t_atfr_l] DESC'
                        WHEN 't_gsta_l' THEN '[ttdpur401200].[t_gsta_l]'
                        WHEN 't_gsta_l DESC' THEN '[ttdpur401200].[t_gsta_l] DESC'
                        WHEN 't_tasg_l' THEN '[ttdpur401200].[t_tasg_l]'
                        WHEN 't_tasg_l DESC' THEN '[ttdpur401200].[t_tasg_l] DESC'
                        ELSE '[ttdpur401200].[t_orno],[ttdpur401200].[t_pono],[ttdpur401200].[t_sqnb]'
                    END
  EXEC (@LGSQL)

  SET @RecordCount = @@RowCount

  SELECT
    [ttdpur401200].*  
  FROM [ttdpur401200] 
      INNER JOIN #PageIndex
          ON [ttdpur401200].[t_orno] = #PageIndex.t_orno
          AND [ttdpur401200].[t_pono] = #PageIndex.t_pono
          AND [ttdpur401200].[t_sqnb] = #PageIndex.t_sqnb
  WHERE
        #PageIndex.IndexID > @StartRowIndex
        AND #PageIndex.IndexID < (@StartRowIndex + @MaximumRows + 1)
  ORDER BY
    #PageIndex.IndexID
  END
  GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spttdisg002SelectByID]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spttdisg002SelectByID]
GO
 
CREATE PROCEDURE [dbo].[spttdisg002SelectByID]
  @LoginID NVarChar(8),
  @t_orno VarChar(9),
  @t_pono Int,
  @t_item VarChar(47) 
  AS
  SELECT
    [ttdisg002200].*  
  FROM [ttdisg002200] 
  WHERE
  [ttdisg002200].[t_orno] = @t_orno
  AND [ttdisg002200].[t_pono] = @t_pono
  AND [ttdisg002200].[t_item] = @t_item
  GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spttdisg002SelectListSearch]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spttdisg002SelectListSearch]
GO
 
CREATE PROCEDURE [dbo].[spttdisg002SelectListSearch]
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
 ,t_orno VarChar(9) NOT NULL
 ,t_pono Int NOT NULL
 ,t_item VarChar(47) NOT NULL
  )
  INSERT INTO #PageIndex (t_orno, t_pono, t_item)
  SELECT [ttdisg002200].[t_orno], [ttdisg002200].[t_pono], [ttdisg002200].[t_item] FROM [ttdisg002200]
 WHERE  
   ( 
         LOWER(ISNULL([ttdisg002200].[t_orno],'')) LIKE @KeyWord1
     OR STR(ISNULL([ttdisg002200].[t_vrsn], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttdisg002200].[t_pono], 0)) LIKE @KeyWord1
     OR LOWER(ISNULL([ttdisg002200].[t_item],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ttdisg002200].[t_desc],'')) LIKE @KeyWord1
     OR STR(ISNULL([ttdisg002200].[t_qnty], 0)) LIKE @KeyWord1
     OR LOWER(ISNULL([ttdisg002200].[t_quom],'')) LIKE @KeyWord1
     OR STR(ISNULL([ttdisg002200].[t_wght], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttdisg002200].[t_slct], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttdisg002200].[t_stat], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttdisg002200].[t_pric], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttdisg002200].[t_amnt], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttdisg002200].[t_qoor], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttdisg002200].[t_acht], 0)) LIKE @KeyWord1
     OR LOWER(ISNULL([ttdisg002200].[t_docn],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ttdisg002200].[t_revi],'')) LIKE @KeyWord1
     OR STR(ISNULL([ttdisg002200].[t_Refcntd], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttdisg002200].[t_Refcntu], 0)) LIKE @KeyWord1
   ) 
  ORDER BY
     CASE @OrderBy WHEN 't_orno' THEN [ttdisg002200].[t_orno] END,
     CASE @OrderBy WHEN 't_orno DESC' THEN [ttdisg002200].[t_orno] END DESC,
     CASE @OrderBy WHEN 't_vrsn' THEN [ttdisg002200].[t_vrsn] END,
     CASE @OrderBy WHEN 't_vrsn DESC' THEN [ttdisg002200].[t_vrsn] END DESC,
     CASE @OrderBy WHEN 't_pono' THEN [ttdisg002200].[t_pono] END,
     CASE @OrderBy WHEN 't_pono DESC' THEN [ttdisg002200].[t_pono] END DESC,
     CASE @OrderBy WHEN 't_item' THEN [ttdisg002200].[t_item] END,
     CASE @OrderBy WHEN 't_item DESC' THEN [ttdisg002200].[t_item] END DESC,
     CASE @OrderBy WHEN 't_desc' THEN [ttdisg002200].[t_desc] END,
     CASE @OrderBy WHEN 't_desc DESC' THEN [ttdisg002200].[t_desc] END DESC,
     CASE @OrderBy WHEN 't_qnty' THEN [ttdisg002200].[t_qnty] END,
     CASE @OrderBy WHEN 't_qnty DESC' THEN [ttdisg002200].[t_qnty] END DESC,
     CASE @OrderBy WHEN 't_quom' THEN [ttdisg002200].[t_quom] END,
     CASE @OrderBy WHEN 't_quom DESC' THEN [ttdisg002200].[t_quom] END DESC,
     CASE @OrderBy WHEN 't_wght' THEN [ttdisg002200].[t_wght] END,
     CASE @OrderBy WHEN 't_wght DESC' THEN [ttdisg002200].[t_wght] END DESC,
     CASE @OrderBy WHEN 't_slct' THEN [ttdisg002200].[t_slct] END,
     CASE @OrderBy WHEN 't_slct DESC' THEN [ttdisg002200].[t_slct] END DESC,
     CASE @OrderBy WHEN 't_stat' THEN [ttdisg002200].[t_stat] END,
     CASE @OrderBy WHEN 't_stat DESC' THEN [ttdisg002200].[t_stat] END DESC,
     CASE @OrderBy WHEN 't_pric' THEN [ttdisg002200].[t_pric] END,
     CASE @OrderBy WHEN 't_pric DESC' THEN [ttdisg002200].[t_pric] END DESC,
     CASE @OrderBy WHEN 't_amnt' THEN [ttdisg002200].[t_amnt] END,
     CASE @OrderBy WHEN 't_amnt DESC' THEN [ttdisg002200].[t_amnt] END DESC,
     CASE @OrderBy WHEN 't_qoor' THEN [ttdisg002200].[t_qoor] END,
     CASE @OrderBy WHEN 't_qoor DESC' THEN [ttdisg002200].[t_qoor] END DESC,
     CASE @OrderBy WHEN 't_acht' THEN [ttdisg002200].[t_acht] END,
     CASE @OrderBy WHEN 't_acht DESC' THEN [ttdisg002200].[t_acht] END DESC,
     CASE @OrderBy WHEN 't_docn' THEN [ttdisg002200].[t_docn] END,
     CASE @OrderBy WHEN 't_docn DESC' THEN [ttdisg002200].[t_docn] END DESC,
     CASE @OrderBy WHEN 't_revi' THEN [ttdisg002200].[t_revi] END,
     CASE @OrderBy WHEN 't_revi DESC' THEN [ttdisg002200].[t_revi] END DESC,
     CASE @OrderBy WHEN 't_Refcntd' THEN [ttdisg002200].[t_Refcntd] END,
     CASE @OrderBy WHEN 't_Refcntd DESC' THEN [ttdisg002200].[t_Refcntd] END DESC,
     CASE @OrderBy WHEN 't_Refcntu' THEN [ttdisg002200].[t_Refcntu] END,
     CASE @OrderBy WHEN 't_Refcntu DESC' THEN [ttdisg002200].[t_Refcntu] END DESC,
     CASE @OrderBy WHEN 't_pldt' THEN [ttdisg002200].[t_pldt] END,
     CASE @OrderBy WHEN 't_pldt DESC' THEN [ttdisg002200].[t_pldt] END DESC 

    SET @RecordCount = @@RowCount

  SELECT
    [ttdisg002200].*  
  FROM [ttdisg002200] 
      INNER JOIN #PageIndex
          ON [ttdisg002200].[t_orno] = #PageIndex.t_orno
          AND [ttdisg002200].[t_pono] = #PageIndex.t_pono
          AND [ttdisg002200].[t_item] = #PageIndex.t_item
  WHERE
        #PageIndex.IndexID > @StartRowIndex
        AND #PageIndex.IndexID < (@StartRowIndex + @MaximumRows + 1)
  ORDER BY
    #PageIndex.IndexID
  END
  GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spttdisg002SelectListFilteres]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spttdisg002SelectListFilteres]
GO
 
CREATE PROCEDURE [dbo].[spttdisg002SelectListFilteres]
  @LoginID NVarChar(8),
  @StartRowIndex int,
  @MaximumRows int,
  @OrderBy NVarChar(50),
  @RecordCount Int = 0 OUTPUT
  AS
  BEGIN
  DECLARE @LGSQL VarChar(8000)
  CREATE TABLE #PageIndex (
  IndexID INT IDENTITY (1, 1) NOT NULL
 ,t_orno VarChar(9) NOT NULL
 ,t_pono Int NOT NULL
 ,t_item VarChar(47) NOT NULL
  )
  SET @LGSQL = 'INSERT INTO #PageIndex (' 
  SET @LGSQL = @LGSQL + 't_orno'
  SET @LGSQL = @LGSQL + ', t_pono'
  SET @LGSQL = @LGSQL + ', t_item'
  SET @LGSQL = @LGSQL + ')'
  SET @LGSQL = @LGSQL + ' SELECT '
  SET @LGSQL = @LGSQL + '[ttdisg002200].[t_orno]'
  SET @LGSQL = @LGSQL + ', [ttdisg002200].[t_pono]'
  SET @LGSQL = @LGSQL + ', [ttdisg002200].[t_item]'
  SET @LGSQL = @LGSQL + ' FROM [ttdisg002200] '
  SET @LGSQL = @LGSQL + '  WHERE 1 = 1 '
  SET @LGSQL = @LGSQL + '  ORDER BY '
  SET @LGSQL = @LGSQL + CASE @OrderBy
                        WHEN 't_orno' THEN '[ttdisg002200].[t_orno]'
                        WHEN 't_orno DESC' THEN '[ttdisg002200].[t_orno] DESC'
                        WHEN 't_vrsn' THEN '[ttdisg002200].[t_vrsn]'
                        WHEN 't_vrsn DESC' THEN '[ttdisg002200].[t_vrsn] DESC'
                        WHEN 't_pono' THEN '[ttdisg002200].[t_pono]'
                        WHEN 't_pono DESC' THEN '[ttdisg002200].[t_pono] DESC'
                        WHEN 't_item' THEN '[ttdisg002200].[t_item]'
                        WHEN 't_item DESC' THEN '[ttdisg002200].[t_item] DESC'
                        WHEN 't_desc' THEN '[ttdisg002200].[t_desc]'
                        WHEN 't_desc DESC' THEN '[ttdisg002200].[t_desc] DESC'
                        WHEN 't_qnty' THEN '[ttdisg002200].[t_qnty]'
                        WHEN 't_qnty DESC' THEN '[ttdisg002200].[t_qnty] DESC'
                        WHEN 't_quom' THEN '[ttdisg002200].[t_quom]'
                        WHEN 't_quom DESC' THEN '[ttdisg002200].[t_quom] DESC'
                        WHEN 't_wght' THEN '[ttdisg002200].[t_wght]'
                        WHEN 't_wght DESC' THEN '[ttdisg002200].[t_wght] DESC'
                        WHEN 't_slct' THEN '[ttdisg002200].[t_slct]'
                        WHEN 't_slct DESC' THEN '[ttdisg002200].[t_slct] DESC'
                        WHEN 't_stat' THEN '[ttdisg002200].[t_stat]'
                        WHEN 't_stat DESC' THEN '[ttdisg002200].[t_stat] DESC'
                        WHEN 't_pric' THEN '[ttdisg002200].[t_pric]'
                        WHEN 't_pric DESC' THEN '[ttdisg002200].[t_pric] DESC'
                        WHEN 't_amnt' THEN '[ttdisg002200].[t_amnt]'
                        WHEN 't_amnt DESC' THEN '[ttdisg002200].[t_amnt] DESC'
                        WHEN 't_qoor' THEN '[ttdisg002200].[t_qoor]'
                        WHEN 't_qoor DESC' THEN '[ttdisg002200].[t_qoor] DESC'
                        WHEN 't_acht' THEN '[ttdisg002200].[t_acht]'
                        WHEN 't_acht DESC' THEN '[ttdisg002200].[t_acht] DESC'
                        WHEN 't_docn' THEN '[ttdisg002200].[t_docn]'
                        WHEN 't_docn DESC' THEN '[ttdisg002200].[t_docn] DESC'
                        WHEN 't_revi' THEN '[ttdisg002200].[t_revi]'
                        WHEN 't_revi DESC' THEN '[ttdisg002200].[t_revi] DESC'
                        WHEN 't_Refcntd' THEN '[ttdisg002200].[t_Refcntd]'
                        WHEN 't_Refcntd DESC' THEN '[ttdisg002200].[t_Refcntd] DESC'
                        WHEN 't_Refcntu' THEN '[ttdisg002200].[t_Refcntu]'
                        WHEN 't_Refcntu DESC' THEN '[ttdisg002200].[t_Refcntu] DESC'
                        WHEN 't_pldt' THEN '[ttdisg002200].[t_pldt]'
                        WHEN 't_pldt DESC' THEN '[ttdisg002200].[t_pldt] DESC'
                        ELSE '[ttdisg002200].[t_orno],[ttdisg002200].[t_pono],[ttdisg002200].[t_item]'
                    END
  EXEC (@LGSQL)

  SET @RecordCount = @@RowCount

  SELECT
    [ttdisg002200].*  
  FROM [ttdisg002200] 
      INNER JOIN #PageIndex
          ON [ttdisg002200].[t_orno] = #PageIndex.t_orno
          AND [ttdisg002200].[t_pono] = #PageIndex.t_pono
          AND [ttdisg002200].[t_item] = #PageIndex.t_item
  WHERE
        #PageIndex.IndexID > @StartRowIndex
        AND #PageIndex.IndexID < (@StartRowIndex + @MaximumRows + 1)
  ORDER BY
    #PageIndex.IndexID
  END
  GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spttdisg002Insert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spttdisg002Insert]
GO
 
CREATE PROCEDURE [dbo].[spttdisg002Insert]
  @t_orno VarChar(9),
  @t_vrsn Int,
  @t_pono Int,
  @t_item VarChar(47),
  @t_desc VarChar(100),
  @t_qnty Float,
  @t_quom VarChar(3),
  @t_wght Float,
  @t_slct Int,
  @t_stat Int,
  @t_pric Float,
  @t_amnt Float,
  @t_qoor Float,
  @t_acht Float,
  @t_docn VarChar(32),
  @t_revi VarChar(20),
  @t_Refcntd Int,
  @t_Refcntu Int,
  @t_pldt DateTime,
  @Return_t_orno VarChar(9) = null OUTPUT, 
  @Return_t_pono Int = null OUTPUT, 
  @Return_t_item VarChar(47) = null OUTPUT 
  AS
  INSERT [ttdisg002200]
  (
   [t_orno]
  ,[t_vrsn]
  ,[t_pono]
  ,[t_item]
  ,[t_desc]
  ,[t_qnty]
  ,[t_quom]
  ,[t_wght]
  ,[t_slct]
  ,[t_stat]
  ,[t_pric]
  ,[t_amnt]
  ,[t_qoor]
  ,[t_acht]
  ,[t_docn]
  ,[t_revi]
  ,[t_Refcntd]
  ,[t_Refcntu]
  ,[t_pldt]
  )
  VALUES
  (
   UPPER(@t_orno)
  ,@t_vrsn
  ,@t_pono
  ,UPPER(@t_item)
  ,@t_desc
  ,@t_qnty
  ,@t_quom
  ,@t_wght
  ,@t_slct
  ,@t_stat
  ,@t_pric
  ,@t_amnt
  ,@t_qoor
  ,@t_acht
  ,@t_docn
  ,@t_revi
  ,@t_Refcntd
  ,@t_Refcntu
  ,@t_pldt
  )
  SET @Return_t_orno = @t_orno
  SET @Return_t_pono = @t_pono
  SET @Return_t_item = @t_item
  GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spttdisg002Update]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spttdisg002Update]
GO
 
CREATE PROCEDURE [dbo].[spttdisg002Update]
  @Original_t_orno VarChar(9), 
  @Original_t_pono Int, 
  @Original_t_item VarChar(47), 
  @t_orno VarChar(9),
  @t_vrsn Int,
  @t_pono Int,
  @t_item VarChar(47),
  @t_desc VarChar(100),
  @t_qnty Float,
  @t_quom VarChar(3),
  @t_wght Float,
  @t_slct Int,
  @t_stat Int,
  @t_pric Float,
  @t_amnt Float,
  @t_qoor Float,
  @t_acht Float,
  @t_docn VarChar(32),
  @t_revi VarChar(20),
  @t_Refcntd Int,
  @t_Refcntu Int,
  @t_pldt DateTime,
  @RowCount int = null OUTPUT
  AS
  UPDATE [ttdisg002200] SET 
   [t_orno] = @t_orno
  ,[t_vrsn] = @t_vrsn
  ,[t_pono] = @t_pono
  ,[t_item] = @t_item
  ,[t_desc] = @t_desc
  ,[t_qnty] = @t_qnty
  ,[t_quom] = @t_quom
  ,[t_wght] = @t_wght
  ,[t_slct] = @t_slct
  ,[t_stat] = @t_stat
  ,[t_pric] = @t_pric
  ,[t_amnt] = @t_amnt
  ,[t_qoor] = @t_qoor
  ,[t_acht] = @t_acht
  ,[t_docn] = @t_docn
  ,[t_revi] = @t_revi
  ,[t_Refcntd] = @t_Refcntd
  ,[t_Refcntu] = @t_Refcntu
  ,[t_pldt] = @t_pldt
  WHERE
  [t_orno] = @Original_t_orno
  AND [t_pono] = @Original_t_pono
  AND [t_item] = @Original_t_item
  SET @RowCount = @@RowCount
  GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spttdisg002Delete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spttdisg002Delete]
GO
 
CREATE PROCEDURE [dbo].[spttdisg002Delete]
  @Original_t_orno VarChar(9),
  @Original_t_pono Int,
  @Original_t_item VarChar(47),
  @RowCount int = null OUTPUT
  AS
  DELETE [ttdisg002200]
  WHERE
  [ttdisg002200].[t_orno] = @Original_t_orno
  AND [ttdisg002200].[t_pono] = @Original_t_pono
  AND [ttdisg002200].[t_item] = @Original_t_item
  SET @RowCount = @@RowCount
  GO

SET QUOTED_IDENTIFIER OFF
GO
SET ANSI_NULLS ON
GO
