USE [Mes]
insert into UserUserGroups
 values('usercode1','usergroupcode1'); 
insert into UserUserGroups
 values('usercode2','usergroupcode1');

update Mdls set parentcode='mdlcode1';
update Mdls set parentcode='0' where mdlcode='mdlcode1';
update Mdls set form='FormLogin' where mdlcode='mdlcode2';
update Mdls set form='FrmGoodNG' where mdlcode='mdlcode3';
update Mdls set form='FrmTsInputEdit' where mdlcode='mdlcode4';

 insert into MdlUserGroups values('mdlcode1','usergroupcode1');   
 insert into MdlUserGroups values('mdlcode2','usergroupcode1');   
 insert into MdlUserGroups values('mdlcode3','usergroupcode1');   
 insert into MdlUserGroups values('mdlcode4','usergroupcode1');
 insert into MdlUserGroups values('mdlcode5','usergroupcode1');   
 insert into MdlUserGroups values('mdlcode6','usergroupcode1');   
 insert into MdlUserGroups values('mdlcode7','usergroupcode1');   
 insert into MdlUserGroups values('mdlcode8','usergroupcode1');
 insert into MdlUserGroups values('mdlcode9','usergroupcode1'); 


  insert into UserGroupRes values('usergroupcode1','rescode1');
  insert into UserGroupRes values('usergroupcode1','rescode2');
  insert into UserGroupRes values('usergroupcode1','rescode3');
  insert into UserGroupRes values('usergroupcode1','rescode4');
  insert into UserGroupRes values('usergroupcode1','rescode5');
  insert into UserGroupRes values('usergroupcode1','rescode6');
  insert into UserGroupRes values('usergroupcode1','rescode7');
  insert into UserGroupRes values('usergroupcode1','rescode8');
  insert into UserGroupRes values('usergroupcode1','rescode9');
  insert into UserGroupRes values('usergroupcode1','rescode10');

  
  update Moes set Route_ROUTECODE='routecode1',MOSTATUS=1,ISCONINPUT=1,MOPLANQTY=10 ;
  update Moes set MOSTATUS=0 Where mocode='mocode2';
  update Moes set Route_ROUTECODE=null where MoCode='mocode3';
   

  insert into OpRoutes(Route_ROUTECODE,Op_OPCODE) values('routecode1','opcode1');
  insert into OpRoutes(Route_ROUTECODE,Op_OPCODE) values('routecode1','opcode2');
  insert into OpRoutes(Route_ROUTECODE,Op_OPCODE) values('routecode1','opcode3');
  insert into OpRoutes(Route_ROUTECODE,Op_OPCODE) values('routecode1','opcode4');
  insert into OpRoutes(Route_ROUTECODE,Op_OPCODE) values('routecode1','opcode5');
  insert into OpRoutes(Route_ROUTECODE,Op_OPCODE) values('routecode2','opcode1');
  insert into OpRoutes(Route_ROUTECODE,Op_OPCODE) values('routecode2','opcode2');
  insert into OpRoutes(Route_ROUTECODE,Op_OPCODE) values('routecode2','opcode3');
  insert into OpRoutes(Route_ROUTECODE,Op_OPCODE) values('routecode2','opcode4');
  insert into OpRoutes(Route_ROUTECODE,Op_OPCODE) values('routecode2','opcode5');

  update res set Op_OPCODE='opcode1' where RESCODE='rescode1';
  update res set Op_OPCODE='opcode2' where RESCODE='rescode2';
  update res set Op_OPCODE='opcode3' where RESCODE='rescode3';
  update res set Op_OPCODE='opcode4' where RESCODE='rescode4';
  update res set Op_OPCODE='opcode5' where RESCODE='rescode5';
  update res set Op_OPCODE='opcode6' where RESCODE='rescode6';
  update res set Op_OPCODE='opcode7' where RESCODE='rescode7';
  update res set Op_OPCODE='opcode8' where RESCODE='rescode8';
  update res set Op_OPCODE='opcode9' where RESCODE='rescode9';
  update res set Op_OPCODE='opcode10' where RESCODE='rescode10';

    
update Items set Model_MODELCODE='modelcode1';
update Items set CHKITEMOP=NULL where ITEMCODE='itemcode4';
insert into RouteItems values('routecode1','itemcode1');
insert into RouteItems values('routecode2','itemcode1');
update Route2Op set routeCode='routecode1',seq=Route2OpID where Route2OpID<6;

update Route2Op set routeCode='routecode2',seq=Route2OpID where Route2OpID>=6;
update ErrorCodes set ecg_ecgcode='ecgcode1' ;
update ErrorCodeSeasons set ecsg_ecsgcode='ecsgcode1' ;
update ErrorCodes set ecode='AUTONG' where ecode='ecode10';
update TsErrorCodes set ts_TSID=1 where TsErrorCodeID<3;
update TsErrorCauses set tsErrorCode_TsErrorCodeID=1 where TsErrorCauseID<3;
update TsErrorCauses set tsErrorCode_TsErrorCodeID=2 where TsErrorCauseID>8
update Ts set tsstatus=1;
update TsErrorCodes set errorCode_ecode='ecode1' where TsErrorCodeID=1;
update TsErrorCodes set errorCode_ecode='ecode2' where TsErrorCodeID=2;;


insert into SolutionModels values('solcode1','modelcode1');
insert into SolutionModels values('solcode2','modelcode1');
insert into SolutionModels values('solcode3','modelcode1');
insert into SolutionModels values('solcode4','modelcode1');
insert into SolutionModels values('solcode5','modelcode1');
insert into SolutionModels values('solcode6','modelcode1');
insert into SolutionModels values('solcode7','modelcode1');
insert into SolutionModels values('solcode8','modelcode1');
insert into SolutionModels values('solcode9','modelcode1');
insert into SolutionModels values('solcode10','modelcode1');

insert into ErrorComModels values(1,'modelcode1');
insert into ErrorComModels values(2,'modelcode1');
insert into ErrorComModels values(3,'modelcode1');
insert into ErrorComModels values(4,'modelcode1');
insert into ErrorComModels values(5,'modelcode1');
insert into ErrorComModels values(6,'modelcode1');
insert into ErrorComModels values(7,'modelcode1');
insert into ErrorComModels values(8,'modelcode1');
insert into ErrorComModels values(9,'modelcode1');
insert into ErrorComModels values(10,'modelcode1');

insert into ModelErrorCodeSeasonGroups values('modelcode1','ecsgcode1');
insert into ModelErrorCodeSeasonGroups values('modelcode1','ecsgcode2');
insert into ModelErrorCodeSeasonGroups values('modelcode1','ecsgcode3');
insert into ModelErrorCodeSeasonGroups values('modelcode1','ecsgcode4');
insert into ModelErrorCodeSeasonGroups values('modelcode1','ecsgcode5');
insert into ModelErrorCodeSeasonGroups values('modelcode1','ecsgcode6');
insert into ModelErrorCodeSeasonGroups values('modelcode1','ecsgcode7');
insert into ModelErrorCodeSeasonGroups values('modelcode1','ecsgcode8');
insert into ModelErrorCodeSeasonGroups values('modelcode1','ecsgcode9');
insert into ModelErrorCodeSeasonGroups values('modelcode1','ecsgcode10');

insert into ErrorCodeGroupModels values('ecgcode1','modelcode1');
insert into ErrorCodeGroupModels values('ecgcode2','modelcode1');
insert into ErrorCodeGroupModels values('ecgcode3','modelcode1');
insert into ErrorCodeGroupModels values('ecgcode4','modelcode1');
insert into ErrorCodeGroupModels values('ecgcode5','modelcode1');
insert into ErrorCodeGroupModels values('ecgcode6','modelcode1');
insert into ErrorCodeGroupModels values('ecgcode7','modelcode1');
insert into ErrorCodeGroupModels values('ecgcode8','modelcode1');
insert into ErrorCodeGroupModels values('ecgcode9','modelcode1');
insert into ErrorCodeGroupModels values('ecgcode10','modelcode1');

update TsErrorCauses set errorCom_ErrorComID=TsErrorCauseID;  
update TsErrorCauses set duty_dutycode='dutycode1',solution_solcode='solcode1',errorCodeSeason_ecscode='ecscode1' 