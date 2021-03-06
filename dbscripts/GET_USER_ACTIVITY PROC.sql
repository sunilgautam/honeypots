USE [HONEY_POTS]
GO
/****** Object:  StoredProcedure [dbo].[GET_USER_ACTIVITY]    Script Date: 10/13/2012 15:14:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[GET_USER_ACTIVITY]
(
	@PARA VARCHAR(10) = '',
	@RESOURCE_TYPE VARCHAR(10) = ''
)
AS
BEGIN
	DECLARE @DT SMALLDATETIME = GETDATE()
	IF @PARA = 'H'
	SELECT DBO.GET_USER_HITS(@PARA, @RESOURCE_TYPE, @DT) HITS, @DT HIT_TIME
	UNION ALL
	SELECT DBO.GET_USER_HITS(@PARA, @RESOURCE_TYPE, @DT - '00:01:00.000') HITS, (@DT - '00:01:00.000') HIT_TIME
	UNION ALL
	SELECT DBO.GET_USER_HITS(@PARA, @RESOURCE_TYPE, @DT - '00:02:00.000') HITS, (@DT - '00:02:00.000') HIT_TIME
	UNION ALL
	SELECT DBO.GET_USER_HITS(@PARA, @RESOURCE_TYPE, @DT - '00:03:00.000') HITS, (@DT - '00:03:00.000') HIT_TIME
	UNION ALL
	SELECT DBO.GET_USER_HITS(@PARA, @RESOURCE_TYPE, @DT - '00:04:00.000') HITS, (@DT - '00:04:00.000') HIT_TIME
	UNION ALL
	SELECT DBO.GET_USER_HITS(@PARA, @RESOURCE_TYPE, @DT - '00:05:00.000') HITS, (@DT - '00:05:00.000') HIT_TIME
	UNION ALL
	SELECT DBO.GET_USER_HITS(@PARA, @RESOURCE_TYPE, @DT - '00:06:00.000') HITS, (@DT - '00:06:00.000') HIT_TIME
	UNION ALL
	SELECT DBO.GET_USER_HITS(@PARA, @RESOURCE_TYPE, @DT - '00:07:00.000') HITS, (@DT - '00:07:00.000') HIT_TIME
	UNION ALL
	SELECT DBO.GET_USER_HITS(@PARA, @RESOURCE_TYPE, @DT - '00:08:00.000') HITS, (@DT - '00:08:00.000') HIT_TIME
	UNION ALL
	SELECT DBO.GET_USER_HITS(@PARA, @RESOURCE_TYPE, @DT - '00:09:00.000') HITS, (@DT - '00:09:00.000') HIT_TIME
	UNION ALL
	SELECT DBO.GET_USER_HITS(@PARA, @RESOURCE_TYPE, @DT - '00:10:00.000') HITS, (@DT - '00:10:00.000') HIT_TIME
	UNION ALL
	SELECT DBO.GET_USER_HITS(@PARA, @RESOURCE_TYPE, @DT - '00:11:00.000') HITS, (@DT - '00:11:00.000') HIT_TIME
	UNION ALL
	SELECT DBO.GET_USER_HITS(@PARA, @RESOURCE_TYPE, @DT - '00:12:00.000') HITS, (@DT - '00:12:00.000') HIT_TIME
	UNION ALL
	SELECT DBO.GET_USER_HITS(@PARA, @RESOURCE_TYPE, @DT - '00:13:00.000') HITS, (@DT - '00:13:00.000') HIT_TIME
	UNION ALL
	SELECT DBO.GET_USER_HITS(@PARA, @RESOURCE_TYPE, @DT - '00:14:00.000') HITS, (@DT - '00:14:00.000') HIT_TIME
	UNION ALL
	SELECT DBO.GET_USER_HITS(@PARA, @RESOURCE_TYPE, @DT - '00:15:00.000') HITS, (@DT - '00:15:00.000') HIT_TIME
	UNION ALL
	SELECT DBO.GET_USER_HITS(@PARA, @RESOURCE_TYPE, @DT - '00:16:00.000') HITS, (@DT - '00:16:00.000') HIT_TIME
	UNION ALL
	SELECT DBO.GET_USER_HITS(@PARA, @RESOURCE_TYPE, @DT - '00:17:00.000') HITS, (@DT - '00:17:00.000') HIT_TIME
	UNION ALL
	SELECT DBO.GET_USER_HITS(@PARA, @RESOURCE_TYPE, @DT - '00:18:00.000') HITS, (@DT - '00:18:00.000') HIT_TIME
	UNION ALL
	SELECT DBO.GET_USER_HITS(@PARA, @RESOURCE_TYPE, @DT - '00:19:00.000') HITS, (@DT - '00:19:00.000') HIT_TIME
	UNION ALL
	SELECT DBO.GET_USER_HITS(@PARA, @RESOURCE_TYPE, @DT - '00:20:00.000') HITS, (@DT - '00:20:00.000') HIT_TIME
	UNION ALL
	SELECT DBO.GET_USER_HITS(@PARA, @RESOURCE_TYPE, @DT - '00:21:00.000') HITS, (@DT - '00:21:00.000') HIT_TIME
	UNION ALL
	SELECT DBO.GET_USER_HITS(@PARA, @RESOURCE_TYPE, @DT - '00:22:00.000') HITS, (@DT - '00:22:00.000') HIT_TIME
	UNION ALL
	SELECT DBO.GET_USER_HITS(@PARA, @RESOURCE_TYPE, @DT - '00:23:00.000') HITS, (@DT - '00:23:00.000') HIT_TIME
	UNION ALL
	SELECT DBO.GET_USER_HITS(@PARA, @RESOURCE_TYPE, @DT - '00:24:00.000') HITS, (@DT - '00:24:00.000') HIT_TIME
	UNION ALL
	SELECT DBO.GET_USER_HITS(@PARA, @RESOURCE_TYPE, @DT - '00:25:00.000') HITS, (@DT - '00:25:00.000') HIT_TIME
	UNION ALL
	SELECT DBO.GET_USER_HITS(@PARA, @RESOURCE_TYPE, @DT - '00:26:00.000') HITS, (@DT - '00:26:00.000') HIT_TIME
	UNION ALL
	SELECT DBO.GET_USER_HITS(@PARA, @RESOURCE_TYPE, @DT - '00:27:00.000') HITS, (@DT - '00:27:00.000') HIT_TIME
	UNION ALL
	SELECT DBO.GET_USER_HITS(@PARA, @RESOURCE_TYPE, @DT - '00:28:00.000') HITS, (@DT - '00:28:00.000') HIT_TIME
	UNION ALL
	SELECT DBO.GET_USER_HITS(@PARA, @RESOURCE_TYPE, @DT - '00:29:00.000') HITS, (@DT - '00:29:00.000') HIT_TIME
	UNION ALL
	SELECT DBO.GET_USER_HITS(@PARA, @RESOURCE_TYPE, @DT - '00:30:00.000') HITS, (@DT - '00:30:00.000') HIT_TIME
	UNION ALL
	SELECT DBO.GET_USER_HITS(@PARA, @RESOURCE_TYPE, @DT - '00:31:00.000') HITS, (@DT - '00:31:00.000') HIT_TIME
	UNION ALL
	SELECT DBO.GET_USER_HITS(@PARA, @RESOURCE_TYPE, @DT - '00:32:00.000') HITS, (@DT - '00:32:00.000') HIT_TIME
	UNION ALL
	SELECT DBO.GET_USER_HITS(@PARA, @RESOURCE_TYPE, @DT - '00:33:00.000') HITS, (@DT - '00:33:00.000') HIT_TIME
	UNION ALL
	SELECT DBO.GET_USER_HITS(@PARA, @RESOURCE_TYPE, @DT - '00:34:00.000') HITS, (@DT - '00:34:00.000') HIT_TIME
	UNION ALL
	SELECT DBO.GET_USER_HITS(@PARA, @RESOURCE_TYPE, @DT - '00:35:00.000') HITS, (@DT - '00:35:00.000') HIT_TIME
	UNION ALL
	SELECT DBO.GET_USER_HITS(@PARA, @RESOURCE_TYPE, @DT - '00:36:00.000') HITS, (@DT - '00:36:00.000') HIT_TIME
	UNION ALL
	SELECT DBO.GET_USER_HITS(@PARA, @RESOURCE_TYPE, @DT - '00:37:00.000') HITS, (@DT - '00:37:00.000') HIT_TIME
	UNION ALL
	SELECT DBO.GET_USER_HITS(@PARA, @RESOURCE_TYPE, @DT - '00:38:00.000') HITS, (@DT - '00:38:00.000') HIT_TIME
	UNION ALL
	SELECT DBO.GET_USER_HITS(@PARA, @RESOURCE_TYPE, @DT - '00:39:00.000') HITS, (@DT - '00:39:00.000') HIT_TIME
	UNION ALL
	SELECT DBO.GET_USER_HITS(@PARA, @RESOURCE_TYPE, @DT - '00:40:00.000') HITS, (@DT - '00:40:00.000') HIT_TIME
	UNION ALL
	SELECT DBO.GET_USER_HITS(@PARA, @RESOURCE_TYPE, @DT - '00:41:00.000') HITS, (@DT - '00:41:00.000') HIT_TIME
	UNION ALL
	SELECT DBO.GET_USER_HITS(@PARA, @RESOURCE_TYPE, @DT - '00:42:00.000') HITS, (@DT - '00:42:00.000') HIT_TIME
	UNION ALL
	SELECT DBO.GET_USER_HITS(@PARA, @RESOURCE_TYPE, @DT - '00:43:00.000') HITS, (@DT - '00:43:00.000') HIT_TIME
	UNION ALL
	SELECT DBO.GET_USER_HITS(@PARA, @RESOURCE_TYPE, @DT - '00:44:00.000') HITS, (@DT - '00:44:00.000') HIT_TIME
	UNION ALL
	SELECT DBO.GET_USER_HITS(@PARA, @RESOURCE_TYPE, @DT - '00:45:00.000') HITS, (@DT - '00:45:00.000') HIT_TIME
	UNION ALL
	SELECT DBO.GET_USER_HITS(@PARA, @RESOURCE_TYPE, @DT - '00:46:00.000') HITS, (@DT - '00:46:00.000') HIT_TIME
	UNION ALL
	SELECT DBO.GET_USER_HITS(@PARA, @RESOURCE_TYPE, @DT - '00:47:00.000') HITS, (@DT - '00:47:00.000') HIT_TIME
	UNION ALL
	SELECT DBO.GET_USER_HITS(@PARA, @RESOURCE_TYPE, @DT - '00:48:00.000') HITS, (@DT - '00:48:00.000') HIT_TIME
	UNION ALL
	SELECT DBO.GET_USER_HITS(@PARA, @RESOURCE_TYPE, @DT - '00:49:00.000') HITS, (@DT - '00:49:00.000') HIT_TIME
	UNION ALL
	SELECT DBO.GET_USER_HITS(@PARA, @RESOURCE_TYPE, @DT - '00:50:00.000') HITS, (@DT - '00:50:00.000') HIT_TIME
	UNION ALL
	SELECT DBO.GET_USER_HITS(@PARA, @RESOURCE_TYPE, @DT - '00:51:00.000') HITS, (@DT - '00:51:00.000') HIT_TIME
	UNION ALL
	SELECT DBO.GET_USER_HITS(@PARA, @RESOURCE_TYPE, @DT - '00:52:00.000') HITS, (@DT - '00:52:00.000') HIT_TIME
	UNION ALL
	SELECT DBO.GET_USER_HITS(@PARA, @RESOURCE_TYPE, @DT - '00:53:00.000') HITS, (@DT - '00:53:00.000') HIT_TIME
	UNION ALL
	SELECT DBO.GET_USER_HITS(@PARA, @RESOURCE_TYPE, @DT - '00:54:00.000') HITS, (@DT - '00:54:00.000') HIT_TIME
	UNION ALL
	SELECT DBO.GET_USER_HITS(@PARA, @RESOURCE_TYPE, @DT - '00:55:00.000') HITS, (@DT - '00:55:00.000') HIT_TIME
	UNION ALL
	SELECT DBO.GET_USER_HITS(@PARA, @RESOURCE_TYPE, @DT - '00:56:00.000') HITS, (@DT - '00:56:00.000') HIT_TIME
	UNION ALL
	SELECT DBO.GET_USER_HITS(@PARA, @RESOURCE_TYPE, @DT - '00:57:00.000') HITS, (@DT - '00:57:00.000') HIT_TIME
	UNION ALL
	SELECT DBO.GET_USER_HITS(@PARA, @RESOURCE_TYPE, @DT - '00:58:00.000') HITS, (@DT - '00:58:00.000') HIT_TIME
	UNION ALL
	SELECT DBO.GET_USER_HITS(@PARA, @RESOURCE_TYPE, @DT - '00:59:00.000') HITS, (@DT - '00:59:00.000') HIT_TIME
	UNION ALL
	SELECT DBO.GET_USER_HITS(@PARA, @RESOURCE_TYPE, @DT - '01:00:00.000') HITS, (@DT - '01:00:00.000') HIT_TIME
END