SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spvrLorryReceiptsDSelectListSearch]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spvrLorryReceiptsDSelectListSearch]
GO
 
CREATE PROCEDURE [dbo].[spvrLorryReceiptsDSelectListSearch]
  @LoginID NVarChar(8),
  @StartRowIndex int,
  @MaximumRows int,
  @KeyWord VarChar(250),
  @LRStatusID Int,
  @OrderBy NVarChar(50),
  @RecordCount Int = 0 OUTPUT
  AS
  BEGIN
    DECLARE @KeyWord1 VarChar(260)
    SET @KeyWord1 = '%' + LOWER(@KeyWord) + '%'
  CREATE TABLE #PageIndex (
  IndexID INT IDENTITY (1, 1) NOT NULL
 ,ProjectID NVarChar(6) NOT NULL
 ,MRNNo Int NOT NULL
  )
  INSERT INTO #PageIndex (ProjectID, MRNNo)
  SELECT [VR_LorryReceipts].[ProjectID], [VR_LorryReceipts].[MRNNo] FROM [VR_LorryReceipts]
  LEFT OUTER JOIN [aspnet_users] AS [aspnet_users1]
    ON [VR_LorryReceipts].[CreatedBy] = [aspnet_users1].[LoginID]
  INNER JOIN [IDM_Projects] AS [IDM_Projects2]
    ON [VR_LorryReceipts].[ProjectID] = [IDM_Projects2].[ProjectID]
  LEFT OUTER JOIN [VR_BusinessPartner] AS [VR_BusinessPartner3]
    ON [VR_LorryReceipts].[CustomerID] = [VR_BusinessPartner3].[BPID]
  INNER JOIN [VR_LorryReceiptStatus] AS [VR_LorryReceiptStatus4]
    ON [VR_LorryReceipts].[LRStatusID] = [VR_LorryReceiptStatus4].[LRStatusID]
  LEFT OUTER JOIN [VR_MaterialStates] AS [VR_MaterialStates5]
    ON [VR_LorryReceipts].[MaterialStateID] = [VR_MaterialStates5].[MaterialStateID]
  LEFT OUTER JOIN [VR_RequestExecution] AS [VR_RequestExecution6]
    ON [VR_LorryReceipts].[RequestExecutionNo] = [VR_RequestExecution6].[SRNNo]
  LEFT OUTER JOIN [VR_Transporters] AS [VR_Transporters7]
    ON [VR_LorryReceipts].[TransporterID] = [VR_Transporters7].[TransporterID]
  LEFT OUTER JOIN [VR_VehicleTypes] AS [VR_VehicleTypes8]
    ON [VR_LorryReceipts].[VehicleTypeID] = [VR_VehicleTypes8].[VehicleTypeID]
 WHERE  
      [VR_LorryReceipts].[LRStatusID] = (@LRStatusID)
   AND ( 
         LOWER(ISNULL([VR_LorryReceipts].[ProjectID],'')) LIKE @KeyWord1
     OR STR(ISNULL([VR_LorryReceipts].[RequestExecutionNo], 0)) LIKE @KeyWord1
     OR STR(ISNULL([VR_LorryReceipts].[MRNNo], 0)) LIKE @KeyWord1
     OR LOWER(ISNULL([VR_LorryReceipts].[TransporterID],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([VR_LorryReceipts].[TransporterName],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([VR_LorryReceipts].[CustomerID],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([VR_LorryReceipts].[VehicleRegistrationNo],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([VR_LorryReceipts].[WayBillFormNo],'')) LIKE @KeyWord1
     OR STR(ISNULL([VR_LorryReceipts].[AmountPaid], 0)) LIKE @KeyWord1
     OR LOWER(ISNULL([VR_LorryReceipts].[DetentionAtSite],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([VR_LorryReceipts].[ReasonForDetention],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([VR_LorryReceipts].[OverDimensionConsignment],'')) LIKE @KeyWord1
     OR STR(ISNULL([VR_LorryReceipts].[VehicleTypeID], 0)) LIKE @KeyWord1
     OR LOWER(ISNULL([VR_LorryReceipts].[VehicleType],'')) LIKE @KeyWord1
     OR STR(ISNULL([VR_LorryReceipts].[VehicleLengthInFt], 0)) LIKE @KeyWord1
     OR STR(ISNULL([VR_LorryReceipts].[VechicleWidthInFt], 0)) LIKE @KeyWord1
     OR STR(ISNULL([VR_LorryReceipts].[VehicleHeightInFt], 0)) LIKE @KeyWord1
     OR STR(ISNULL([VR_LorryReceipts].[MaterialStateID], 0)) LIKE @KeyWord1
     OR LOWER(ISNULL([VR_LorryReceipts].[RemarksForDamageOrShortage],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([VR_LorryReceipts].[OtherRemarks],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([VR_LorryReceipts].[DriverNameAndContactNo],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([VR_LorryReceipts].[CreatedBy],'')) LIKE @KeyWord1
     OR STR(ISNULL([VR_LorryReceipts].[LRStatusID], 0)) LIKE @KeyWord1
   ) 
  ORDER BY
     CASE @OrderBy WHEN 'ProjectID' THEN [VR_LorryReceipts].[ProjectID] END,
     CASE @OrderBy WHEN 'ProjectID DESC' THEN [VR_LorryReceipts].[ProjectID] END DESC,
     CASE @OrderBy WHEN 'RequestExecutionNo' THEN [VR_LorryReceipts].[RequestExecutionNo] END,
     CASE @OrderBy WHEN 'RequestExecutionNo DESC' THEN [VR_LorryReceipts].[RequestExecutionNo] END DESC,
     CASE @OrderBy WHEN 'MRNNo' THEN [VR_LorryReceipts].[MRNNo] END,
     CASE @OrderBy WHEN 'MRNNo DESC' THEN [VR_LorryReceipts].[MRNNo] END DESC,
     CASE @OrderBy WHEN 'MRNDate' THEN [VR_LorryReceipts].[MRNDate] END,
     CASE @OrderBy WHEN 'MRNDate DESC' THEN [VR_LorryReceipts].[MRNDate] END DESC,
     CASE @OrderBy WHEN 'TransporterID' THEN [VR_LorryReceipts].[TransporterID] END,
     CASE @OrderBy WHEN 'TransporterID DESC' THEN [VR_LorryReceipts].[TransporterID] END DESC,
     CASE @OrderBy WHEN 'TransporterName' THEN [VR_LorryReceipts].[TransporterName] END,
     CASE @OrderBy WHEN 'TransporterName DESC' THEN [VR_LorryReceipts].[TransporterName] END DESC,
     CASE @OrderBy WHEN 'CustomerID' THEN [VR_LorryReceipts].[CustomerID] END,
     CASE @OrderBy WHEN 'CustomerID DESC' THEN [VR_LorryReceipts].[CustomerID] END DESC,
     CASE @OrderBy WHEN 'VehicleRegistrationNo' THEN [VR_LorryReceipts].[VehicleRegistrationNo] END,
     CASE @OrderBy WHEN 'VehicleRegistrationNo DESC' THEN [VR_LorryReceipts].[VehicleRegistrationNo] END DESC,
     CASE @OrderBy WHEN 'WayBillFormNo' THEN [VR_LorryReceipts].[WayBillFormNo] END,
     CASE @OrderBy WHEN 'WayBillFormNo DESC' THEN [VR_LorryReceipts].[WayBillFormNo] END DESC,
     CASE @OrderBy WHEN 'PaymentMadeAtSite' THEN [VR_LorryReceipts].[PaymentMadeAtSite] END,
     CASE @OrderBy WHEN 'PaymentMadeAtSite DESC' THEN [VR_LorryReceipts].[PaymentMadeAtSite] END DESC,
     CASE @OrderBy WHEN 'AmountPaid' THEN [VR_LorryReceipts].[AmountPaid] END,
     CASE @OrderBy WHEN 'AmountPaid DESC' THEN [VR_LorryReceipts].[AmountPaid] END DESC,
     CASE @OrderBy WHEN 'VehicleInDate' THEN [VR_LorryReceipts].[VehicleInDate] END,
     CASE @OrderBy WHEN 'VehicleInDate DESC' THEN [VR_LorryReceipts].[VehicleInDate] END DESC,
     CASE @OrderBy WHEN 'VehicleOutDate' THEN [VR_LorryReceipts].[VehicleOutDate] END,
     CASE @OrderBy WHEN 'VehicleOutDate DESC' THEN [VR_LorryReceipts].[VehicleOutDate] END DESC,
     CASE @OrderBy WHEN 'DetentionAtSite' THEN [VR_LorryReceipts].[DetentionAtSite] END,
     CASE @OrderBy WHEN 'DetentionAtSite DESC' THEN [VR_LorryReceipts].[DetentionAtSite] END DESC,
     CASE @OrderBy WHEN 'ReasonForDetention' THEN [VR_LorryReceipts].[ReasonForDetention] END,
     CASE @OrderBy WHEN 'ReasonForDetention DESC' THEN [VR_LorryReceipts].[ReasonForDetention] END DESC,
     CASE @OrderBy WHEN 'OverDimensionConsignment' THEN [VR_LorryReceipts].[OverDimensionConsignment] END,
     CASE @OrderBy WHEN 'OverDimensionConsignment DESC' THEN [VR_LorryReceipts].[OverDimensionConsignment] END DESC,
     CASE @OrderBy WHEN 'VehicleTypeID' THEN [VR_LorryReceipts].[VehicleTypeID] END,
     CASE @OrderBy WHEN 'VehicleTypeID DESC' THEN [VR_LorryReceipts].[VehicleTypeID] END DESC,
     CASE @OrderBy WHEN 'VehicleType' THEN [VR_LorryReceipts].[VehicleType] END,
     CASE @OrderBy WHEN 'VehicleType DESC' THEN [VR_LorryReceipts].[VehicleType] END DESC,
     CASE @OrderBy WHEN 'VehicleLengthInFt' THEN [VR_LorryReceipts].[VehicleLengthInFt] END,
     CASE @OrderBy WHEN 'VehicleLengthInFt DESC' THEN [VR_LorryReceipts].[VehicleLengthInFt] END DESC,
     CASE @OrderBy WHEN 'VechicleWidthInFt' THEN [VR_LorryReceipts].[VechicleWidthInFt] END,
     CASE @OrderBy WHEN 'VechicleWidthInFt DESC' THEN [VR_LorryReceipts].[VechicleWidthInFt] END DESC,
     CASE @OrderBy WHEN 'VehicleHeightInFt' THEN [VR_LorryReceipts].[VehicleHeightInFt] END,
     CASE @OrderBy WHEN 'VehicleHeightInFt DESC' THEN [VR_LorryReceipts].[VehicleHeightInFt] END DESC,
     CASE @OrderBy WHEN 'MaterialStateID' THEN [VR_LorryReceipts].[MaterialStateID] END,
     CASE @OrderBy WHEN 'MaterialStateID DESC' THEN [VR_LorryReceipts].[MaterialStateID] END DESC,
     CASE @OrderBy WHEN 'RemarksForDamageOrShortage' THEN [VR_LorryReceipts].[RemarksForDamageOrShortage] END,
     CASE @OrderBy WHEN 'RemarksForDamageOrShortage DESC' THEN [VR_LorryReceipts].[RemarksForDamageOrShortage] END DESC,
     CASE @OrderBy WHEN 'OtherRemarks' THEN [VR_LorryReceipts].[OtherRemarks] END,
     CASE @OrderBy WHEN 'OtherRemarks DESC' THEN [VR_LorryReceipts].[OtherRemarks] END DESC,
     CASE @OrderBy WHEN 'DriverNameAndContactNo' THEN [VR_LorryReceipts].[DriverNameAndContactNo] END,
     CASE @OrderBy WHEN 'DriverNameAndContactNo DESC' THEN [VR_LorryReceipts].[DriverNameAndContactNo] END DESC,
     CASE @OrderBy WHEN 'CreatedBy' THEN [VR_LorryReceipts].[CreatedBy] END,
     CASE @OrderBy WHEN 'CreatedBy DESC' THEN [VR_LorryReceipts].[CreatedBy] END DESC,
     CASE @OrderBy WHEN 'CreatedOn' THEN [VR_LorryReceipts].[CreatedOn] END,
     CASE @OrderBy WHEN 'CreatedOn DESC' THEN [VR_LorryReceipts].[CreatedOn] END DESC,
     CASE @OrderBy WHEN 'LRStatusID' THEN [VR_LorryReceipts].[LRStatusID] END,
     CASE @OrderBy WHEN 'LRStatusID DESC' THEN [VR_LorryReceipts].[LRStatusID] END DESC,
     CASE @OrderBy WHEN 'aspnet_Users1_UserFullName' THEN [aspnet_Users1].[UserFullName] END,
     CASE @OrderBy WHEN 'aspnet_Users1_UserFullName DESC' THEN [aspnet_Users1].[UserFullName] END DESC,
     CASE @OrderBy WHEN 'IDM_Projects2_Description' THEN [IDM_Projects2].[Description] END,
     CASE @OrderBy WHEN 'IDM_Projects2_Description DESC' THEN [IDM_Projects2].[Description] END DESC,
     CASE @OrderBy WHEN 'VR_BusinessPartner3_BPName' THEN [VR_BusinessPartner3].[BPName] END,
     CASE @OrderBy WHEN 'VR_BusinessPartner3_BPName DESC' THEN [VR_BusinessPartner3].[BPName] END DESC,
     CASE @OrderBy WHEN 'VR_LorryReceiptStatus4_Description' THEN [VR_LorryReceiptStatus4].[Description] END,
     CASE @OrderBy WHEN 'VR_LorryReceiptStatus4_Description DESC' THEN [VR_LorryReceiptStatus4].[Description] END DESC,
     CASE @OrderBy WHEN 'VR_MaterialStates5_Description' THEN [VR_MaterialStates5].[Description] END,
     CASE @OrderBy WHEN 'VR_MaterialStates5_Description DESC' THEN [VR_MaterialStates5].[Description] END DESC,
     CASE @OrderBy WHEN 'VR_RequestExecution6_ExecutionDescription' THEN [VR_RequestExecution6].[ExecutionDescription] END,
     CASE @OrderBy WHEN 'VR_RequestExecution6_ExecutionDescription DESC' THEN [VR_RequestExecution6].[ExecutionDescription] END DESC,
     CASE @OrderBy WHEN 'VR_Transporters7_TransporterName' THEN [VR_Transporters7].[TransporterName] END,
     CASE @OrderBy WHEN 'VR_Transporters7_TransporterName DESC' THEN [VR_Transporters7].[TransporterName] END DESC,
     CASE @OrderBy WHEN 'VR_VehicleTypes8_cmba' THEN [VR_VehicleTypes8].[cmba] END,
     CASE @OrderBy WHEN 'VR_VehicleTypes8_cmba DESC' THEN [VR_VehicleTypes8].[cmba] END DESC 

    SET @RecordCount = @@RowCount

  SELECT
    [VR_LorryReceipts].* ,
    [aspnet_Users1].[UserFullName] AS aspnet_Users1_UserFullName,
    [IDM_Projects2].[Description] AS IDM_Projects2_Description,
    [VR_BusinessPartner3].[BPName] AS VR_BusinessPartner3_BPName,
    [VR_LorryReceiptStatus4].[Description] AS VR_LorryReceiptStatus4_Description,
    [VR_MaterialStates5].[Description] AS VR_MaterialStates5_Description,
    [VR_RequestExecution6].[ExecutionDescription] AS VR_RequestExecution6_ExecutionDescription,
    [VR_Transporters7].[TransporterName] AS VR_Transporters7_TransporterName,
    [VR_VehicleTypes8].[cmba] AS VR_VehicleTypes8_cmba 
  FROM [VR_LorryReceipts] 
      INNER JOIN #PageIndex
          ON [VR_LorryReceipts].[ProjectID] = #PageIndex.ProjectID
          AND [VR_LorryReceipts].[MRNNo] = #PageIndex.MRNNo
  LEFT OUTER JOIN [aspnet_users] AS [aspnet_users1]
    ON [VR_LorryReceipts].[CreatedBy] = [aspnet_users1].[LoginID]
  INNER JOIN [IDM_Projects] AS [IDM_Projects2]
    ON [VR_LorryReceipts].[ProjectID] = [IDM_Projects2].[ProjectID]
  LEFT OUTER JOIN [VR_BusinessPartner] AS [VR_BusinessPartner3]
    ON [VR_LorryReceipts].[CustomerID] = [VR_BusinessPartner3].[BPID]
  INNER JOIN [VR_LorryReceiptStatus] AS [VR_LorryReceiptStatus4]
    ON [VR_LorryReceipts].[LRStatusID] = [VR_LorryReceiptStatus4].[LRStatusID]
  LEFT OUTER JOIN [VR_MaterialStates] AS [VR_MaterialStates5]
    ON [VR_LorryReceipts].[MaterialStateID] = [VR_MaterialStates5].[MaterialStateID]
  LEFT OUTER JOIN [VR_RequestExecution] AS [VR_RequestExecution6]
    ON [VR_LorryReceipts].[RequestExecutionNo] = [VR_RequestExecution6].[SRNNo]
  LEFT OUTER JOIN [VR_Transporters] AS [VR_Transporters7]
    ON [VR_LorryReceipts].[TransporterID] = [VR_Transporters7].[TransporterID]
  LEFT OUTER JOIN [VR_VehicleTypes] AS [VR_VehicleTypes8]
    ON [VR_LorryReceipts].[VehicleTypeID] = [VR_VehicleTypes8].[VehicleTypeID]
  WHERE
        #PageIndex.IndexID > @StartRowIndex
        AND #PageIndex.IndexID < (@StartRowIndex + @MaximumRows + 1)
  ORDER BY
    #PageIndex.IndexID
  END
  GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spvrLorryReceiptsDSelectListFilteres]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spvrLorryReceiptsDSelectListFilteres]
GO
 
CREATE PROCEDURE [dbo].[spvrLorryReceiptsDSelectListFilteres]
  @Filter_ProjectID NVarChar(6),
  @Filter_TransporterID NVarChar(9),
  @Filter_CustomerID NVarChar(9),
  @Filter_VehicleTypeID Int,
  @LoginID NVarChar(8),
  @StartRowIndex int,
  @MaximumRows int,
  @LRStatusID Int,
  @OrderBy NVarChar(50),
  @RecordCount Int = 0 OUTPUT
  AS
  BEGIN
  DECLARE @LGSQL VarChar(8000)
  CREATE TABLE #PageIndex (
  IndexID INT IDENTITY (1, 1) NOT NULL
 ,ProjectID NVarChar(6) NOT NULL
 ,MRNNo Int NOT NULL
  )
  SET @LGSQL = 'INSERT INTO #PageIndex (' 
  SET @LGSQL = @LGSQL + 'ProjectID'
  SET @LGSQL = @LGSQL + ', MRNNo'
  SET @LGSQL = @LGSQL + ')'
  SET @LGSQL = @LGSQL + ' SELECT '
  SET @LGSQL = @LGSQL + '[VR_LorryReceipts].[ProjectID]'
  SET @LGSQL = @LGSQL + ', [VR_LorryReceipts].[MRNNo]'
  SET @LGSQL = @LGSQL + ' FROM [VR_LorryReceipts] '
  SET @LGSQL = @LGSQL + '  LEFT OUTER JOIN [aspnet_users] AS [aspnet_users1]'
  SET @LGSQL = @LGSQL + '    ON [VR_LorryReceipts].[CreatedBy] = [aspnet_users1].[LoginID]'
  SET @LGSQL = @LGSQL + '  INNER JOIN [IDM_Projects] AS [IDM_Projects2]'
  SET @LGSQL = @LGSQL + '    ON [VR_LorryReceipts].[ProjectID] = [IDM_Projects2].[ProjectID]'
  SET @LGSQL = @LGSQL + '  LEFT OUTER JOIN [VR_BusinessPartner] AS [VR_BusinessPartner3]'
  SET @LGSQL = @LGSQL + '    ON [VR_LorryReceipts].[CustomerID] = [VR_BusinessPartner3].[BPID]'
  SET @LGSQL = @LGSQL + '  INNER JOIN [VR_LorryReceiptStatus] AS [VR_LorryReceiptStatus4]'
  SET @LGSQL = @LGSQL + '    ON [VR_LorryReceipts].[LRStatusID] = [VR_LorryReceiptStatus4].[LRStatusID]'
  SET @LGSQL = @LGSQL + '  LEFT OUTER JOIN [VR_MaterialStates] AS [VR_MaterialStates5]'
  SET @LGSQL = @LGSQL + '    ON [VR_LorryReceipts].[MaterialStateID] = [VR_MaterialStates5].[MaterialStateID]'
  SET @LGSQL = @LGSQL + '  LEFT OUTER JOIN [VR_RequestExecution] AS [VR_RequestExecution6]'
  SET @LGSQL = @LGSQL + '    ON [VR_LorryReceipts].[RequestExecutionNo] = [VR_RequestExecution6].[SRNNo]'
  SET @LGSQL = @LGSQL + '  LEFT OUTER JOIN [VR_Transporters] AS [VR_Transporters7]'
  SET @LGSQL = @LGSQL + '    ON [VR_LorryReceipts].[TransporterID] = [VR_Transporters7].[TransporterID]'
  SET @LGSQL = @LGSQL + '  LEFT OUTER JOIN [VR_VehicleTypes] AS [VR_VehicleTypes8]'
  SET @LGSQL = @LGSQL + '    ON [VR_LorryReceipts].[VehicleTypeID] = [VR_VehicleTypes8].[VehicleTypeID]'
  SET @LGSQL = @LGSQL + '  WHERE 1 = 1 '
  SET @LGSQL = @LGSQL + ' AND [VR_LorryReceipts].[LRStatusID] = ''' + STR(@LRStatusID) + '''' 
  IF (@Filter_ProjectID > '') 
    SET @LGSQL = @LGSQL + ' AND [VR_LorryReceipts].[ProjectID] = ''' + @Filter_ProjectID + ''''
  IF (@Filter_TransporterID > '') 
    SET @LGSQL = @LGSQL + ' AND [VR_LorryReceipts].[TransporterID] = ''' + @Filter_TransporterID + ''''
  IF (@Filter_CustomerID > '') 
    SET @LGSQL = @LGSQL + ' AND [VR_LorryReceipts].[CustomerID] = ''' + @Filter_CustomerID + ''''
  IF (@Filter_VehicleTypeID > 0) 
    SET @LGSQL = @LGSQL + ' AND [VR_LorryReceipts].[VehicleTypeID] = ' + STR(@Filter_VehicleTypeID)
  SET @LGSQL = @LGSQL + '  ORDER BY '
  SET @LGSQL = @LGSQL + CASE @OrderBy
                        WHEN 'ProjectID' THEN '[VR_LorryReceipts].[ProjectID]'
                        WHEN 'ProjectID DESC' THEN '[VR_LorryReceipts].[ProjectID] DESC'
                        WHEN 'RequestExecutionNo' THEN '[VR_LorryReceipts].[RequestExecutionNo]'
                        WHEN 'RequestExecutionNo DESC' THEN '[VR_LorryReceipts].[RequestExecutionNo] DESC'
                        WHEN 'MRNNo' THEN '[VR_LorryReceipts].[MRNNo]'
                        WHEN 'MRNNo DESC' THEN '[VR_LorryReceipts].[MRNNo] DESC'
                        WHEN 'MRNDate' THEN '[VR_LorryReceipts].[MRNDate]'
                        WHEN 'MRNDate DESC' THEN '[VR_LorryReceipts].[MRNDate] DESC'
                        WHEN 'TransporterID' THEN '[VR_LorryReceipts].[TransporterID]'
                        WHEN 'TransporterID DESC' THEN '[VR_LorryReceipts].[TransporterID] DESC'
                        WHEN 'TransporterName' THEN '[VR_LorryReceipts].[TransporterName]'
                        WHEN 'TransporterName DESC' THEN '[VR_LorryReceipts].[TransporterName] DESC'
                        WHEN 'CustomerID' THEN '[VR_LorryReceipts].[CustomerID]'
                        WHEN 'CustomerID DESC' THEN '[VR_LorryReceipts].[CustomerID] DESC'
                        WHEN 'VehicleRegistrationNo' THEN '[VR_LorryReceipts].[VehicleRegistrationNo]'
                        WHEN 'VehicleRegistrationNo DESC' THEN '[VR_LorryReceipts].[VehicleRegistrationNo] DESC'
                        WHEN 'WayBillFormNo' THEN '[VR_LorryReceipts].[WayBillFormNo]'
                        WHEN 'WayBillFormNo DESC' THEN '[VR_LorryReceipts].[WayBillFormNo] DESC'
                        WHEN 'PaymentMadeAtSite' THEN '[VR_LorryReceipts].[PaymentMadeAtSite]'
                        WHEN 'PaymentMadeAtSite DESC' THEN '[VR_LorryReceipts].[PaymentMadeAtSite] DESC'
                        WHEN 'AmountPaid' THEN '[VR_LorryReceipts].[AmountPaid]'
                        WHEN 'AmountPaid DESC' THEN '[VR_LorryReceipts].[AmountPaid] DESC'
                        WHEN 'VehicleInDate' THEN '[VR_LorryReceipts].[VehicleInDate]'
                        WHEN 'VehicleInDate DESC' THEN '[VR_LorryReceipts].[VehicleInDate] DESC'
                        WHEN 'VehicleOutDate' THEN '[VR_LorryReceipts].[VehicleOutDate]'
                        WHEN 'VehicleOutDate DESC' THEN '[VR_LorryReceipts].[VehicleOutDate] DESC'
                        WHEN 'DetentionAtSite' THEN '[VR_LorryReceipts].[DetentionAtSite]'
                        WHEN 'DetentionAtSite DESC' THEN '[VR_LorryReceipts].[DetentionAtSite] DESC'
                        WHEN 'ReasonForDetention' THEN '[VR_LorryReceipts].[ReasonForDetention]'
                        WHEN 'ReasonForDetention DESC' THEN '[VR_LorryReceipts].[ReasonForDetention] DESC'
                        WHEN 'OverDimensionConsignment' THEN '[VR_LorryReceipts].[OverDimensionConsignment]'
                        WHEN 'OverDimensionConsignment DESC' THEN '[VR_LorryReceipts].[OverDimensionConsignment] DESC'
                        WHEN 'VehicleTypeID' THEN '[VR_LorryReceipts].[VehicleTypeID]'
                        WHEN 'VehicleTypeID DESC' THEN '[VR_LorryReceipts].[VehicleTypeID] DESC'
                        WHEN 'VehicleType' THEN '[VR_LorryReceipts].[VehicleType]'
                        WHEN 'VehicleType DESC' THEN '[VR_LorryReceipts].[VehicleType] DESC'
                        WHEN 'VehicleLengthInFt' THEN '[VR_LorryReceipts].[VehicleLengthInFt]'
                        WHEN 'VehicleLengthInFt DESC' THEN '[VR_LorryReceipts].[VehicleLengthInFt] DESC'
                        WHEN 'VechicleWidthInFt' THEN '[VR_LorryReceipts].[VechicleWidthInFt]'
                        WHEN 'VechicleWidthInFt DESC' THEN '[VR_LorryReceipts].[VechicleWidthInFt] DESC'
                        WHEN 'VehicleHeightInFt' THEN '[VR_LorryReceipts].[VehicleHeightInFt]'
                        WHEN 'VehicleHeightInFt DESC' THEN '[VR_LorryReceipts].[VehicleHeightInFt] DESC'
                        WHEN 'MaterialStateID' THEN '[VR_LorryReceipts].[MaterialStateID]'
                        WHEN 'MaterialStateID DESC' THEN '[VR_LorryReceipts].[MaterialStateID] DESC'
                        WHEN 'RemarksForDamageOrShortage' THEN '[VR_LorryReceipts].[RemarksForDamageOrShortage]'
                        WHEN 'RemarksForDamageOrShortage DESC' THEN '[VR_LorryReceipts].[RemarksForDamageOrShortage] DESC'
                        WHEN 'OtherRemarks' THEN '[VR_LorryReceipts].[OtherRemarks]'
                        WHEN 'OtherRemarks DESC' THEN '[VR_LorryReceipts].[OtherRemarks] DESC'
                        WHEN 'DriverNameAndContactNo' THEN '[VR_LorryReceipts].[DriverNameAndContactNo]'
                        WHEN 'DriverNameAndContactNo DESC' THEN '[VR_LorryReceipts].[DriverNameAndContactNo] DESC'
                        WHEN 'CreatedBy' THEN '[VR_LorryReceipts].[CreatedBy]'
                        WHEN 'CreatedBy DESC' THEN '[VR_LorryReceipts].[CreatedBy] DESC'
                        WHEN 'CreatedOn' THEN '[VR_LorryReceipts].[CreatedOn]'
                        WHEN 'CreatedOn DESC' THEN '[VR_LorryReceipts].[CreatedOn] DESC'
                        WHEN 'LRStatusID' THEN '[VR_LorryReceipts].[LRStatusID]'
                        WHEN 'LRStatusID DESC' THEN '[VR_LorryReceipts].[LRStatusID] DESC'
                        WHEN 'aspnet_Users1_UserFullName' THEN '[aspnet_Users1].[UserFullName]'
                        WHEN 'aspnet_Users1_UserFullName DESC' THEN '[aspnet_Users1].[UserFullName] DESC'
                        WHEN 'IDM_Projects2_Description' THEN '[IDM_Projects2].[Description]'
                        WHEN 'IDM_Projects2_Description DESC' THEN '[IDM_Projects2].[Description] DESC'
                        WHEN 'VR_BusinessPartner3_BPName' THEN '[VR_BusinessPartner3].[BPName]'
                        WHEN 'VR_BusinessPartner3_BPName DESC' THEN '[VR_BusinessPartner3].[BPName] DESC'
                        WHEN 'VR_LorryReceiptStatus4_Description' THEN '[VR_LorryReceiptStatus4].[Description]'
                        WHEN 'VR_LorryReceiptStatus4_Description DESC' THEN '[VR_LorryReceiptStatus4].[Description] DESC'
                        WHEN 'VR_MaterialStates5_Description' THEN '[VR_MaterialStates5].[Description]'
                        WHEN 'VR_MaterialStates5_Description DESC' THEN '[VR_MaterialStates5].[Description] DESC'
                        WHEN 'VR_RequestExecution6_ExecutionDescription' THEN '[VR_RequestExecution6].[ExecutionDescription]'
                        WHEN 'VR_RequestExecution6_ExecutionDescription DESC' THEN '[VR_RequestExecution6].[ExecutionDescription] DESC'
                        WHEN 'VR_Transporters7_TransporterName' THEN '[VR_Transporters7].[TransporterName]'
                        WHEN 'VR_Transporters7_TransporterName DESC' THEN '[VR_Transporters7].[TransporterName] DESC'
                        WHEN 'VR_VehicleTypes8_cmba' THEN '[VR_VehicleTypes8].[cmba]'
                        WHEN 'VR_VehicleTypes8_cmba DESC' THEN '[VR_VehicleTypes8].[cmba] DESC'
                        ELSE '[VR_LorryReceipts].[ProjectID],[VR_LorryReceipts].[MRNNo]'
                    END
  EXEC (@LGSQL)

  SET @RecordCount = @@RowCount

  SELECT
    [VR_LorryReceipts].* ,
    [aspnet_Users1].[UserFullName] AS aspnet_Users1_UserFullName,
    [IDM_Projects2].[Description] AS IDM_Projects2_Description,
    [VR_BusinessPartner3].[BPName] AS VR_BusinessPartner3_BPName,
    [VR_LorryReceiptStatus4].[Description] AS VR_LorryReceiptStatus4_Description,
    [VR_MaterialStates5].[Description] AS VR_MaterialStates5_Description,
    [VR_RequestExecution6].[ExecutionDescription] AS VR_RequestExecution6_ExecutionDescription,
    [VR_Transporters7].[TransporterName] AS VR_Transporters7_TransporterName,
    [VR_VehicleTypes8].[cmba] AS VR_VehicleTypes8_cmba 
  FROM [VR_LorryReceipts] 
      INNER JOIN #PageIndex
          ON [VR_LorryReceipts].[ProjectID] = #PageIndex.ProjectID
          AND [VR_LorryReceipts].[MRNNo] = #PageIndex.MRNNo
  LEFT OUTER JOIN [aspnet_users] AS [aspnet_users1]
    ON [VR_LorryReceipts].[CreatedBy] = [aspnet_users1].[LoginID]
  INNER JOIN [IDM_Projects] AS [IDM_Projects2]
    ON [VR_LorryReceipts].[ProjectID] = [IDM_Projects2].[ProjectID]
  LEFT OUTER JOIN [VR_BusinessPartner] AS [VR_BusinessPartner3]
    ON [VR_LorryReceipts].[CustomerID] = [VR_BusinessPartner3].[BPID]
  INNER JOIN [VR_LorryReceiptStatus] AS [VR_LorryReceiptStatus4]
    ON [VR_LorryReceipts].[LRStatusID] = [VR_LorryReceiptStatus4].[LRStatusID]
  LEFT OUTER JOIN [VR_MaterialStates] AS [VR_MaterialStates5]
    ON [VR_LorryReceipts].[MaterialStateID] = [VR_MaterialStates5].[MaterialStateID]
  LEFT OUTER JOIN [VR_RequestExecution] AS [VR_RequestExecution6]
    ON [VR_LorryReceipts].[RequestExecutionNo] = [VR_RequestExecution6].[SRNNo]
  LEFT OUTER JOIN [VR_Transporters] AS [VR_Transporters7]
    ON [VR_LorryReceipts].[TransporterID] = [VR_Transporters7].[TransporterID]
  LEFT OUTER JOIN [VR_VehicleTypes] AS [VR_VehicleTypes8]
    ON [VR_LorryReceipts].[VehicleTypeID] = [VR_VehicleTypes8].[VehicleTypeID]
  WHERE
        #PageIndex.IndexID > @StartRowIndex
        AND #PageIndex.IndexID < (@StartRowIndex + @MaximumRows + 1)
  ORDER BY
    #PageIndex.IndexID
  END
  GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spvrLorryReceiptDetailsDSelectListSearch]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spvrLorryReceiptDetailsDSelectListSearch]
GO
 
CREATE PROCEDURE [dbo].[spvrLorryReceiptDetailsDSelectListSearch]
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
 ,MRNNo Int NOT NULL
 ,SerialNo Int NOT NULL
  )
  INSERT INTO #PageIndex (ProjectID, MRNNo, SerialNo)
  SELECT [VR_LorryReceiptDetails].[ProjectID], [VR_LorryReceiptDetails].[MRNNo], [VR_LorryReceiptDetails].[SerialNo] FROM [VR_LorryReceiptDetails]
  INNER JOIN [IDM_Projects] AS [IDM_Projects1]
    ON [VR_LorryReceiptDetails].[ProjectID] = [IDM_Projects1].[ProjectID]
  INNER JOIN [VR_BusinessPartner] AS [VR_BusinessPartner2]
    ON [VR_LorryReceiptDetails].[SupplierID] = [VR_BusinessPartner2].[BPID]
  INNER JOIN [VR_LorryReceipts] AS [VR_LorryReceipts3]
    ON [VR_LorryReceiptDetails].[ProjectID] = [VR_LorryReceipts3].[ProjectID]
    AND [VR_LorryReceiptDetails].[MRNNo] = [VR_LorryReceipts3].[MRNNo]
 WHERE  
   ( 
         LOWER(ISNULL([VR_LorryReceiptDetails].[ProjectID],'')) LIKE @KeyWord1
     OR STR(ISNULL([VR_LorryReceiptDetails].[MRNNo], 0)) LIKE @KeyWord1
     OR STR(ISNULL([VR_LorryReceiptDetails].[SerialNo], 0)) LIKE @KeyWord1
     OR LOWER(ISNULL([VR_LorryReceiptDetails].[GRorLRNo],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([VR_LorryReceiptDetails].[SupplierID],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([VR_LorryReceiptDetails].[SupplierInvoiceNo],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([VR_LorryReceiptDetails].[SupplierName],'')) LIKE @KeyWord1
     OR STR(ISNULL([VR_LorryReceiptDetails].[WeightAsPerInvoiceInKG], 0)) LIKE @KeyWord1
     OR STR(ISNULL([VR_LorryReceiptDetails].[WeightReceived], 0)) LIKE @KeyWord1
     OR STR(ISNULL([VR_LorryReceiptDetails].[NoOfPackagesAsPerInvoice], 0)) LIKE @KeyWord1
     OR STR(ISNULL([VR_LorryReceiptDetails].[NoOfPackagesReceived], 0)) LIKE @KeyWord1
     OR LOWER(ISNULL([VR_LorryReceiptDetails].[CenvatInvoiceReceived],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([VR_LorryReceiptDetails].[Remarks],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([VR_LorryReceiptDetails].[MaterialForm],'')) LIKE @KeyWord1
   ) 
  ORDER BY
     CASE @OrderBy WHEN 'ProjectID' THEN [VR_LorryReceiptDetails].[ProjectID] END,
     CASE @OrderBy WHEN 'ProjectID DESC' THEN [VR_LorryReceiptDetails].[ProjectID] END DESC,
     CASE @OrderBy WHEN 'MRNNo' THEN [VR_LorryReceiptDetails].[MRNNo] END,
     CASE @OrderBy WHEN 'MRNNo DESC' THEN [VR_LorryReceiptDetails].[MRNNo] END DESC,
     CASE @OrderBy WHEN 'SerialNo' THEN [VR_LorryReceiptDetails].[SerialNo] END,
     CASE @OrderBy WHEN 'SerialNo DESC' THEN [VR_LorryReceiptDetails].[SerialNo] END DESC,
     CASE @OrderBy WHEN 'GRorLRNo' THEN [VR_LorryReceiptDetails].[GRorLRNo] END,
     CASE @OrderBy WHEN 'GRorLRNo DESC' THEN [VR_LorryReceiptDetails].[GRorLRNo] END DESC,
     CASE @OrderBy WHEN 'GRorLRDate' THEN [VR_LorryReceiptDetails].[GRorLRDate] END,
     CASE @OrderBy WHEN 'GRorLRDate DESC' THEN [VR_LorryReceiptDetails].[GRorLRDate] END DESC,
     CASE @OrderBy WHEN 'SupplierID' THEN [VR_LorryReceiptDetails].[SupplierID] END,
     CASE @OrderBy WHEN 'SupplierID DESC' THEN [VR_LorryReceiptDetails].[SupplierID] END DESC,
     CASE @OrderBy WHEN 'SupplierName' THEN [VR_LorryReceiptDetails].[SupplierName] END,
     CASE @OrderBy WHEN 'SupplierName DESC' THEN [VR_LorryReceiptDetails].[SupplierName] END DESC,
     CASE @OrderBy WHEN 'SupplierInvoiceNo' THEN [VR_LorryReceiptDetails].[SupplierInvoiceNo] END,
     CASE @OrderBy WHEN 'SupplierInvoiceNo DESC' THEN [VR_LorryReceiptDetails].[SupplierInvoiceNo] END DESC,
     CASE @OrderBy WHEN 'SupplierInvoiceDate' THEN [VR_LorryReceiptDetails].[SupplierInvoiceDate] END,
     CASE @OrderBy WHEN 'SupplierInvoiceDate DESC' THEN [VR_LorryReceiptDetails].[SupplierInvoiceDate] END DESC,
     CASE @OrderBy WHEN 'WeightAsPerInvoiceInKG' THEN [VR_LorryReceiptDetails].[WeightAsPerInvoiceInKG] END,
     CASE @OrderBy WHEN 'WeightAsPerInvoiceInKG DESC' THEN [VR_LorryReceiptDetails].[WeightAsPerInvoiceInKG] END DESC,
     CASE @OrderBy WHEN 'WeightReceived' THEN [VR_LorryReceiptDetails].[WeightReceived] END,
     CASE @OrderBy WHEN 'WeightReceived DESC' THEN [VR_LorryReceiptDetails].[WeightReceived] END DESC,
     CASE @OrderBy WHEN 'MaterialForm' THEN [VR_LorryReceiptDetails].[MaterialForm] END,
     CASE @OrderBy WHEN 'MaterialForm DESC' THEN [VR_LorryReceiptDetails].[MaterialForm] END DESC,
     CASE @OrderBy WHEN 'NoOfPackagesAsPerInvoice' THEN [VR_LorryReceiptDetails].[NoOfPackagesAsPerInvoice] END,
     CASE @OrderBy WHEN 'NoOfPackagesAsPerInvoice DESC' THEN [VR_LorryReceiptDetails].[NoOfPackagesAsPerInvoice] END DESC,
     CASE @OrderBy WHEN 'NoOfPackagesReceived' THEN [VR_LorryReceiptDetails].[NoOfPackagesReceived] END,
     CASE @OrderBy WHEN 'NoOfPackagesReceived DESC' THEN [VR_LorryReceiptDetails].[NoOfPackagesReceived] END DESC,
     CASE @OrderBy WHEN 'CenvatInvoiceReceived' THEN [VR_LorryReceiptDetails].[CenvatInvoiceReceived] END,
     CASE @OrderBy WHEN 'CenvatInvoiceReceived DESC' THEN [VR_LorryReceiptDetails].[CenvatInvoiceReceived] END DESC,
     CASE @OrderBy WHEN 'Remarks' THEN [VR_LorryReceiptDetails].[Remarks] END,
     CASE @OrderBy WHEN 'Remarks DESC' THEN [VR_LorryReceiptDetails].[Remarks] END DESC,
     CASE @OrderBy WHEN 'IDM_Projects1_Description' THEN [IDM_Projects1].[Description] END,
     CASE @OrderBy WHEN 'IDM_Projects1_Description DESC' THEN [IDM_Projects1].[Description] END DESC,
     CASE @OrderBy WHEN 'VR_BusinessPartner2_BPName' THEN [VR_BusinessPartner2].[BPName] END,
     CASE @OrderBy WHEN 'VR_BusinessPartner2_BPName DESC' THEN [VR_BusinessPartner2].[BPName] END DESC,
     CASE @OrderBy WHEN 'VR_LorryReceipts3_WayBillFormNo' THEN [VR_LorryReceipts3].[WayBillFormNo] END,
     CASE @OrderBy WHEN 'VR_LorryReceipts3_WayBillFormNo DESC' THEN [VR_LorryReceipts3].[WayBillFormNo] END DESC 

    SET @RecordCount = @@RowCount

  SELECT
    [VR_LorryReceiptDetails].* ,
    [IDM_Projects1].[Description] AS IDM_Projects1_Description,
    [VR_BusinessPartner2].[BPName] AS VR_BusinessPartner2_BPName,
    [VR_LorryReceipts3].[WayBillFormNo] AS VR_LorryReceipts3_WayBillFormNo 
  FROM [VR_LorryReceiptDetails] 
      INNER JOIN #PageIndex
          ON [VR_LorryReceiptDetails].[ProjectID] = #PageIndex.ProjectID
          AND [VR_LorryReceiptDetails].[MRNNo] = #PageIndex.MRNNo
          AND [VR_LorryReceiptDetails].[SerialNo] = #PageIndex.SerialNo
  INNER JOIN [IDM_Projects] AS [IDM_Projects1]
    ON [VR_LorryReceiptDetails].[ProjectID] = [IDM_Projects1].[ProjectID]
  INNER JOIN [VR_BusinessPartner] AS [VR_BusinessPartner2]
    ON [VR_LorryReceiptDetails].[SupplierID] = [VR_BusinessPartner2].[BPID]
  INNER JOIN [VR_LorryReceipts] AS [VR_LorryReceipts3]
    ON [VR_LorryReceiptDetails].[ProjectID] = [VR_LorryReceipts3].[ProjectID]
    AND [VR_LorryReceiptDetails].[MRNNo] = [VR_LorryReceipts3].[MRNNo]
  WHERE
        #PageIndex.IndexID > @StartRowIndex
        AND #PageIndex.IndexID < (@StartRowIndex + @MaximumRows + 1)
  ORDER BY
    #PageIndex.IndexID
  END
  GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spvrLorryReceiptDetailsDSelectListFilteres]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spvrLorryReceiptDetailsDSelectListFilteres]
GO
 
CREATE PROCEDURE [dbo].[spvrLorryReceiptDetailsDSelectListFilteres]
  @Filter_ProjectID NVarChar(6),
  @Filter_MRNNo Int,
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
 ,ProjectID NVarChar(6) NOT NULL
 ,MRNNo Int NOT NULL
 ,SerialNo Int NOT NULL
  )
  SET @LGSQL = 'INSERT INTO #PageIndex (' 
  SET @LGSQL = @LGSQL + 'ProjectID'
  SET @LGSQL = @LGSQL + ', MRNNo'
  SET @LGSQL = @LGSQL + ', SerialNo'
  SET @LGSQL = @LGSQL + ')'
  SET @LGSQL = @LGSQL + ' SELECT '
  SET @LGSQL = @LGSQL + '[VR_LorryReceiptDetails].[ProjectID]'
  SET @LGSQL = @LGSQL + ', [VR_LorryReceiptDetails].[MRNNo]'
  SET @LGSQL = @LGSQL + ', [VR_LorryReceiptDetails].[SerialNo]'
  SET @LGSQL = @LGSQL + ' FROM [VR_LorryReceiptDetails] '
  SET @LGSQL = @LGSQL + '  INNER JOIN [IDM_Projects] AS [IDM_Projects1]'
  SET @LGSQL = @LGSQL + '    ON [VR_LorryReceiptDetails].[ProjectID] = [IDM_Projects1].[ProjectID]'
  SET @LGSQL = @LGSQL + '  INNER JOIN [VR_BusinessPartner] AS [VR_BusinessPartner2]'
  SET @LGSQL = @LGSQL + '    ON [VR_LorryReceiptDetails].[SupplierID] = [VR_BusinessPartner2].[BPID]'
  SET @LGSQL = @LGSQL + '  INNER JOIN [VR_LorryReceipts] AS [VR_LorryReceipts3]'
  SET @LGSQL = @LGSQL + '    ON [VR_LorryReceiptDetails].[ProjectID] = [VR_LorryReceipts3].[ProjectID]'
  SET @LGSQL = @LGSQL + '    AND [VR_LorryReceiptDetails].[MRNNo] = [VR_LorryReceipts3].[MRNNo]'
  SET @LGSQL = @LGSQL + '  WHERE 1 = 1 '
  IF (@Filter_ProjectID > '') 
    SET @LGSQL = @LGSQL + ' AND [VR_LorryReceiptDetails].[ProjectID] = ''' + @Filter_ProjectID + ''''
  IF (@Filter_MRNNo > 0) 
    SET @LGSQL = @LGSQL + ' AND [VR_LorryReceiptDetails].[MRNNo] = ' + STR(@Filter_MRNNo)
  SET @LGSQL = @LGSQL + '  ORDER BY '
  SET @LGSQL = @LGSQL + CASE @OrderBy
                        WHEN 'ProjectID' THEN '[VR_LorryReceiptDetails].[ProjectID]'
                        WHEN 'ProjectID DESC' THEN '[VR_LorryReceiptDetails].[ProjectID] DESC'
                        WHEN 'MRNNo' THEN '[VR_LorryReceiptDetails].[MRNNo]'
                        WHEN 'MRNNo DESC' THEN '[VR_LorryReceiptDetails].[MRNNo] DESC'
                        WHEN 'SerialNo' THEN '[VR_LorryReceiptDetails].[SerialNo]'
                        WHEN 'SerialNo DESC' THEN '[VR_LorryReceiptDetails].[SerialNo] DESC'
                        WHEN 'GRorLRNo' THEN '[VR_LorryReceiptDetails].[GRorLRNo]'
                        WHEN 'GRorLRNo DESC' THEN '[VR_LorryReceiptDetails].[GRorLRNo] DESC'
                        WHEN 'GRorLRDate' THEN '[VR_LorryReceiptDetails].[GRorLRDate]'
                        WHEN 'GRorLRDate DESC' THEN '[VR_LorryReceiptDetails].[GRorLRDate] DESC'
                        WHEN 'SupplierID' THEN '[VR_LorryReceiptDetails].[SupplierID]'
                        WHEN 'SupplierID DESC' THEN '[VR_LorryReceiptDetails].[SupplierID] DESC'
                        WHEN 'SupplierName' THEN '[VR_LorryReceiptDetails].[SupplierName]'
                        WHEN 'SupplierName DESC' THEN '[VR_LorryReceiptDetails].[SupplierName] DESC'
                        WHEN 'SupplierInvoiceNo' THEN '[VR_LorryReceiptDetails].[SupplierInvoiceNo]'
                        WHEN 'SupplierInvoiceNo DESC' THEN '[VR_LorryReceiptDetails].[SupplierInvoiceNo] DESC'
                        WHEN 'SupplierInvoiceDate' THEN '[VR_LorryReceiptDetails].[SupplierInvoiceDate]'
                        WHEN 'SupplierInvoiceDate DESC' THEN '[VR_LorryReceiptDetails].[SupplierInvoiceDate] DESC'
                        WHEN 'WeightAsPerInvoiceInKG' THEN '[VR_LorryReceiptDetails].[WeightAsPerInvoiceInKG]'
                        WHEN 'WeightAsPerInvoiceInKG DESC' THEN '[VR_LorryReceiptDetails].[WeightAsPerInvoiceInKG] DESC'
                        WHEN 'WeightReceived' THEN '[VR_LorryReceiptDetails].[WeightReceived]'
                        WHEN 'WeightReceived DESC' THEN '[VR_LorryReceiptDetails].[WeightReceived] DESC'
                        WHEN 'MaterialForm' THEN '[VR_LorryReceiptDetails].[MaterialForm]'
                        WHEN 'MaterialForm DESC' THEN '[VR_LorryReceiptDetails].[MaterialForm] DESC'
                        WHEN 'NoOfPackagesAsPerInvoice' THEN '[VR_LorryReceiptDetails].[NoOfPackagesAsPerInvoice]'
                        WHEN 'NoOfPackagesAsPerInvoice DESC' THEN '[VR_LorryReceiptDetails].[NoOfPackagesAsPerInvoice] DESC'
                        WHEN 'NoOfPackagesReceived' THEN '[VR_LorryReceiptDetails].[NoOfPackagesReceived]'
                        WHEN 'NoOfPackagesReceived DESC' THEN '[VR_LorryReceiptDetails].[NoOfPackagesReceived] DESC'
                        WHEN 'CenvatInvoiceReceived' THEN '[VR_LorryReceiptDetails].[CenvatInvoiceReceived]'
                        WHEN 'CenvatInvoiceReceived DESC' THEN '[VR_LorryReceiptDetails].[CenvatInvoiceReceived] DESC'
                        WHEN 'Remarks' THEN '[VR_LorryReceiptDetails].[Remarks]'
                        WHEN 'Remarks DESC' THEN '[VR_LorryReceiptDetails].[Remarks] DESC'
                        WHEN 'IDM_Projects1_Description' THEN '[IDM_Projects1].[Description]'
                        WHEN 'IDM_Projects1_Description DESC' THEN '[IDM_Projects1].[Description] DESC'
                        WHEN 'VR_BusinessPartner2_BPName' THEN '[VR_BusinessPartner2].[BPName]'
                        WHEN 'VR_BusinessPartner2_BPName DESC' THEN '[VR_BusinessPartner2].[BPName] DESC'
                        WHEN 'VR_LorryReceipts3_WayBillFormNo' THEN '[VR_LorryReceipts3].[WayBillFormNo]'
                        WHEN 'VR_LorryReceipts3_WayBillFormNo DESC' THEN '[VR_LorryReceipts3].[WayBillFormNo] DESC'
                        ELSE '[VR_LorryReceiptDetails].[ProjectID],[VR_LorryReceiptDetails].[MRNNo],[VR_LorryReceiptDetails].[SerialNo]'
                    END
  EXEC (@LGSQL)

  SET @RecordCount = @@RowCount

  SELECT
    [VR_LorryReceiptDetails].* ,
    [IDM_Projects1].[Description] AS IDM_Projects1_Description,
    [VR_BusinessPartner2].[BPName] AS VR_BusinessPartner2_BPName,
    [VR_LorryReceipts3].[WayBillFormNo] AS VR_LorryReceipts3_WayBillFormNo 
  FROM [VR_LorryReceiptDetails] 
      INNER JOIN #PageIndex
          ON [VR_LorryReceiptDetails].[ProjectID] = #PageIndex.ProjectID
          AND [VR_LorryReceiptDetails].[MRNNo] = #PageIndex.MRNNo
          AND [VR_LorryReceiptDetails].[SerialNo] = #PageIndex.SerialNo
  INNER JOIN [IDM_Projects] AS [IDM_Projects1]
    ON [VR_LorryReceiptDetails].[ProjectID] = [IDM_Projects1].[ProjectID]
  INNER JOIN [VR_BusinessPartner] AS [VR_BusinessPartner2]
    ON [VR_LorryReceiptDetails].[SupplierID] = [VR_BusinessPartner2].[BPID]
  INNER JOIN [VR_LorryReceipts] AS [VR_LorryReceipts3]
    ON [VR_LorryReceiptDetails].[ProjectID] = [VR_LorryReceipts3].[ProjectID]
    AND [VR_LorryReceiptDetails].[MRNNo] = [VR_LorryReceipts3].[MRNNo]
  WHERE
        #PageIndex.IndexID > @StartRowIndex
        AND #PageIndex.IndexID < (@StartRowIndex + @MaximumRows + 1)
  ORDER BY
    #PageIndex.IndexID
  END
  GO

SET QUOTED_IDENTIFIER OFF
GO
SET ANSI_NULLS ON
GO
