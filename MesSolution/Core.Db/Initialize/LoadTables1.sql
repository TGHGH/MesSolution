﻿USE [MesTest]
insert into UserUserGroups
 values('usercode1','usergroupcode1'); 
insert into UserUserGroups
 values('usercode2','usergroupcode1');

update Mdls set parentcode='mdlcode1';
update Mdls set parentcode='0' where mdlcode='mdlcode1';
update Mdls set form='FormLogin' where mdlcode='mdlcode2';
update Mdls set form='FrmGoodNG' where mdlcode='mdlcode3';

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

  
  update Moes set Route_ROUTECODE='routecode1',MOSTATUS='mostatus_open',ISCONINPUT=1,MOPLANQTY=10;

  insert into RouteOps values('routecode1','opcode1');
  insert into RouteOps values('routecode1','opcode2');
  insert into RouteOps values('routecode1','opcode3');
  insert into RouteOps values('routecode1','opcode4');
  insert into RouteOps values('routecode1','opcode5');
  insert into RouteOps values('routecode2','opcode1');
  insert into RouteOps values('routecode2','opcode2');
  insert into RouteOps values('routecode2','opcode3');
  insert into RouteOps values('routecode2','opcode4');
  insert into RouteOps values('routecode2','opcode5');

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
  update Route2Op set routeCode='routecode1',seq=Route2OpID where Route2OpID<6;

update Route2Op set routeCode='routecode2',seq=Route2OpID where Route2OpID>=6;