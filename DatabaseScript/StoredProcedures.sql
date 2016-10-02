--------------------------------------------------------------------------------------------
-- Name		: ExecuteAutomation Reporting System backend script
-- Author	: Karthik KK
-- Version	: Initial release
--------------------------------------------------------------------------------------------

CREATE PROC [dbo].[sp_CreateTestCycleID]
@AUT varchar(40),
@ExecutedBy  varchar(50),
@RequestedBy varchar(50),
@BuildNo     varchar(50),
@ApplicationVersion varchar(20),
@MachineName varchar(20),
@TestType varchar(20)
AS
BEGIN
	INSERT into tblTestCycle (AUTName,ExecutedBy,RequestedBy,BuildNo,ApplicationVersion,
	DateOfExecution,MachineName,TestType) values (@AUT,@ExecutedBy,@RequestedBy,@BuildNo,@ApplicationVersion,
	GETDATE(),@MachineName,@TestType)
END

Go

CREATE PROC [dbo].[sp_GetFilterData]
@TestCycleID int = 0,
@ExecutedBy varchar(20) = null,
@FromDate Date = null,
@ToDate Date = null
as
Begin
	If @ExecutedBy != null
		select * from tblTestCycle where ExecutedBy = @ExecutedBy
	ELSE IF @TestCycleID != -1
		Select * from tblTestCycle where TestCycleID = @TestCycleID
	ELSE IF @FromDate != null
		select * from tblTestCycle	Where CAST(DateOfExecution as Date) between @FromDate and @ToDate
End

Go

CREATE PROC [dbo].[sp_GetLastTestCycleID]
@ID int output
as
BEGIN
Select @ID = IDENT_CURRENT('tblTestCycle')
PRINT @ID
END

Go

CREATE PROC [dbo].[sp_InsertResult]
@FeatureName varChar(100),
@ScenarioName varchar(800),
@StepName varchar(1000),
@Exception varchar(5000) = null,
@Result varchar(200)=null
as
Begin
	Declare @ID int
	Select @ID = IDENT_CURRENT('tblTestCycle')
	Insert into tblDetailReport (ParentCycleID,FeatureName,ScenarioName,StepName,Exception,Result)
	Values(@ID,@FeatureName,@ScenarioName,@StepName,@Exception,@Result)
	-- For Future request only
	--If (@Result = 'FAILED')
	--BEGIN
	--	Select @ID = IDENT_CURRENT('tblDetailReport')
	--	--Insert into tblFailureReport (FailureReportID,FailureDetails) Values (@ID,@FailureReason)
	--END
End

Go
CREATE PROC [dbo].[sp_TCDetailsCount]
@ParentCycleID int
as
	Begin
		Select COUNT(ParentCycleID) as [Total Steps] from tblDetailReport where ParentCycleID = @ParentCycleID
		Select count(distinct StepName) as StepsCount from tblDetailReport where ParentCycleID = 163 
		Select COUNT(Result) as [Total Passed] from tblDetailReport where Result = 'PASSED'
		Select COUNT(Result) as [Total Failed] from tblDetailReport where Result = 'FAILED'
	End
GO