update A SET A.questionusecode=B.code from questiongroupuse A INNER JOIN questionuse B ON A.questionusecode=B.codeview 
GO
update questiongroup set questionusecodelist=REPLACE(questionusecodelist,'PT','1707130010')
GO
update questiongroup set questionusecodelist=REPLACE(questionusecodelist,'SU','1707130011')
GO
update questiongroup set questionusecodelist=REPLACE(questionusecodelist,'OP','1707140002')
GO
update questiongroup set questionusecodelist=REPLACE(questionusecodelist,'RL','1707140001')
