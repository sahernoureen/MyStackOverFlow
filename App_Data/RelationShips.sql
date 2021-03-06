USE [MyStackOverFlow]
GO
/****** Object:  StoredProcedure [dbo].[MostAnswered]    Script Date: 2020-05-09 3:07:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[MostAnswered] 
	-- Add the parameters for the stored procedure here
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	select q.Id, q.Tilte ,q.Description,q.Qdate,q.QVoteCount,ApplicationUsers.Id, count(An.Id) TotalAns
	from Questions q Join
	Answers An
	on q.Id =An.QuestionId
	join ApplicationUsers on q.UserId= ApplicationUsers.Id
	group by q.Id,q.Tilte ,q.Description,q.Qdate,q.QVoteCount,ApplicationUsers.Id
	order by count(An.Id) Desc  


END
