using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GetPwnBySateId
{
    public static class SqlConst
    {
        /// <summary>
        /// category
        /// </summary>
        public const string DB_NAME_ALBBWEB = "albb_web";

        /// <summary>
        /// "insert into session_log (sid,task,entryDate,clientIp,phone) values (@sid,@task,@entryDate,@clientIp,@phone) ;"
        /// </summary>
        public const string INSERT_SESSION_LOG = "insert into session_log (sid,task,entryDate,clientIp,userAgent,phone) values (@sid,@task,@entryDate,@clientIp,@userAgent,@phone) ;";

        /// <summary>
        /// "insert into session_log (sid,task,phone,tmName,tmType,clientIp,entryDate) values (@sid,@task,@phone,@tmName,@tmType,@clientIp,@entryDate) ;"
        /// </summary>
        public const string INSERT_USER_1 = "insert into session_log (sid,task,phone,tmName,tmType,clientIp,entryDate) values (@sid,@task,@phone,@tmName,@tmType,@clientIp,@entryDate) ;";

        /// <summary>
        /// "insert into task (sid,createDate) values (@sid,@createDate) ;"
        /// </summary>
        public const string INSERT_TASK = "insert into return_visit_task (sid,createDate) values (@sid,@createDate) ;";

        /// <summary>
        /// "INSERT INTO verifycodes (phone,code,createDate,isPass) values (@phone,@code,@createDate,@isPass);"
        /// </summary>
        public const string INSERT_VERIFY_CODES = "INSERT INTO verifycodes (phone,code,createDate,isPass,ip) values (@phone,@code,@createDate,@isPass,@ip);";

        /// <summary>
        /// "insert into user (phone,psw,createDate) values (@phone,@psw,@createDate) ;"
        /// </summary>
        public const string INSERT_USER_REG = "insert into user (phone,psw,isOrg,createDate,source) values (@phone,@psw,@isOrg,@createDate,@source) ;";

        /// <summary>
        /// insert into tm_files (fileId,name,ext,size,content,createDate) values (@fileId,@name,@ext,@size,@content,@createDate)
        /// </summary>
        public static string INSERT_FILE = "insert into tm_files (fileId,content,createDate) values (@fileId,@content,@createDate);";

        /// <summary>
        /// select count(id) from user where phone = @phone and psw = @psw;
        /// </summary>
        public const string QUERY_USER_LOGIN = "select count(id) from user where phone = @phone and psw = @psw;";
        /// <summary>
        ///  select count(id) from user where phone = @phone;
        /// </summary>
        public const string QUERY_USER_REG = "select count(id) from user where phone = @phone;";

        /// <summary>
        /// select count(id) from verifycodes where phone = @phone and code = @code and isPass = @isPass;"
        /// </summary>
        public const string QUERY_VERIFY_CODE_REG = "select count(id) from verifycodes where phone = @phone and code = @code and isPass = @isPass;";

        /// <summary>
        /// select count(id) from verifycodes where phone = @phone and code = @code and isPass = 0;
        /// </summary>
        public static string QUERY_USER_LOGIN_CODE = "select count(id) from verifycodes where phone = @phone and code = @code and isPass = 0;";

        /// <summary>
        /// select sid, phone,`task`,tmName,tmType,entryDate,createDate,isDo,doDate,belongBizName from taskview  where phone != '' and `task` = '商标查询' and isDo = false and bizName = @bizName order by phone ";
        /// </summary>
        public const string QUERY_TASKVIEW = "select sid, session_log.phone,`task`,tmName,tmType,entryDate,entrydate as createDate,isDo,doDate,belongBizName from session_log  join user on session_log.phone = user.phone where user.isOrg = 0 and session_log.phone != '' and `task` = '商标查询' and isDo = false and session_log.bizName = @bizName and not isnull(tmname) ";

        /// <summary>
        /// select distinct tmName,tmType,sid, session_log.phone,entrydate as createDate from session_log  join user on session_log.phone = user.phone where user.isOrg = 0 and user.isInvalid = 0 and isDo = 0 and not isnull(tmName) and task = '商标查询' and session_log.bizName = @bizName group by tmName,tmType
        /// </summary>
        public const string QUERY_TASKVIEW1 = "select distinct tmName,tmType,sid, session_log.phone,entrydate as createDate from session_log  join user on session_log.phone = user.phone where user.isOrg = 0 and user.isInvalid = 0 and isDo = 0 and not isnull(tmName) and task = '商标查询' and session_log.bizName = @bizName group by tmName,tmType";

        /// <summary>
        /// select distinct sid from taskview where ISNull(bizName) and phone != '' and  `task` = '商标查询' group by sid;
        /// </summary>
        public const string QUERY_TASKVIEW_2 = "select distinct sid from taskview where ISNull(bizName) and phone != '' and  `task` = '商标查询' group by sid;";

        /// <summary>
        /// "select * from tm_reg_applicant_detail_orgnize where applicantId = @applicantId"
        /// </summary>
        public static string QUERY_REG_ORGNIZE_APPLICANT = "select * from tm_reg_applicant_detail_orgnize where applicantId = @applicantId";

        /// <summary>
        /// select bizName,bizGroup from taskview where phone = @phone and !isnull(belongBizName);
        /// </summary>
        public const string QUERY_TASKVIEW_3 = "select bizName,bizGroup from taskview where phone = @phone and !isnull(belongBizName);";

        /// <summary>
        /// select tmName,tmType from session_log where sid = @sid and not isnull(tmName)"
        /// </summary>
        public static string QUERY_SID = "select tmName,tmType from session_log where sid = @sid and not isnull(tmName)";

        /// <summary>
        /// update verifycodes set isPass= true where phone = @phone and code = @code ;
        /// </summary>
        public const string UPDATE_VERIFY_CODES_REG = "update verifycodes set isPass= true where phone = @phone and code = @code ;";

        /// <summary>
        /// update  return_visit_task set isDo = true, doDate=@doDate  where sid = @sid  
        /// </summary>
        public const string UPDATE_TASK = "update  session_log set isDo = true, doDate=@doDate  where sid = @sid ";

        /// <summary>
        /// update  session_log set isDo = true, doDate=@doDate  where bizName = @bizName
        /// </summary>
        public const string UPDATE_TASK1 = "update  session_log set isDo = true, doDate=@doDate  where bizName = @bizName";

        /// <summary>
        /// update  session_log set isDo = true, doDate=@doDate  where sid = @sid
        /// </summary>
        public const string UPDATE_TASK2 = "update  session_log set isDo = true, doDate=@doDate  where sid = @sid";

        /// <summary>
        ///  update return_visit_task  set bizName = @bizName where sid = @sid;
        /// </summary>
        public const string UPDATE_TASK_2 = "update return_visit_task  set bizName = @bizName where sid = @sid;";

        /// <summary>
        /// update return_visit_task  set bizName = @bizName,belongBizName = @bizName,bizGroup = @bizGroup  where sid = @sid;
        /// </summary>
        public const string UPDATE_TASK_3 = "update return_visit_task  set bizName = @bizName,belongBizName = @bizName,bizGroup = @bizGroup  where sid = @sid;";

        /// <summary>
        /// update return_visit_task  set bizName = @bizName,belongBizName = @belongBizName,bizGroup = @bizGroup  where sid = @sid;
        /// </summary>
        public const string UPDATE_TASK_4 = "update session_log  set bizName = @bizName,belongBizName = @belongBizName  where phone = @phone and isnull(bizName);";

        /// <summary>
        /// update verifycodes set isPass= true where phone = @phone and code = @code ;
        /// </summary>
        public const string UPDATE_VERIFY_CODES_FP = "update verifycodes set isPass= true where phone = @phone and code = @code ;";

        /// <summary>
        /// update user set psw = @psw  where phone=@phone;
        /// </summary>
        public const string UPDATE_USER = "update user set psw = @psw where phone=@phone;";

        /// <summary>
        /// update return_visit_task  set bizName = '' where sid = @sid;"
        /// </summary>
        public const string UPDATE_TASK_1 = "update return_visit_task  set bizName = '' where sid = @sid;";

        /// <summary>
        /// update user set isOrg = 1 where phone=@phone;
        /// </summary>
        public static string UPDATE_MARK_ORG = "update user set isOrg = 1 where phone=@phone;";

        /// <summary>
        /// update session_log set phone = @phone where sid=@sid and not isnull(tmName);
        /// </summary>
        public static string UPDATE_SID = "update session_log set phone = @phone where sid=@sid and not isnull(tmName);";

        /// <summary>
        /// "select * from tm_reg_applicant_view where userID = @userID"
        /// </summary>
        public static string QUERY_REG_APPLICANT;

        /// <summary>
		/// "select * from tm_reg_applicant_view where userID = @userID limit @pageIndex,@pageSize";
        /// </summary>
        public static string QUERY_REG_APPLICANT_BY_USER_LIMIT = "select * from tm_reg_applicant_view where userID = @userID limit @pageIndex,@pageSize";

		/// <summary>
		/// select * from tm_reg_applicant_view where userID = @userID
		/// </summary>
		public static string QUERY_REG_APPLICANT_BY_USER = "select * from tm_reg_applicant_view where userID = @userID;";

        /// <summary>
        /// select count(*) from tm_reg_applicant_view where userID=@userID
        /// </summary>
        public static string Query_REG_APPLICANT_COUNT = "select count(*) from tm_reg_applicant_view where userID=@userID";

        /// <summary>
        /// "select * from tm_reg_applicant_detail_person where applicantId = @applicantId"
        /// </summary>
        public static string QUERY_REG_PERSON_APPLICANT = "select * from tm_reg_applicant_detail_person where applicantId = @applicantId";

        /// <summary>
        /// "select * from tm_reg_applicant_detail_biz where applicantId = @applicantId"
        /// </summary>
        public static string QUERY_REG_BIZ_APPLICANT = "select * from tm_reg_applicant_detail_biz where applicantId = @applicantId";

        /// <summary>
        /// "select * from tm_files where fileId = @fileId";
        /// </summary>
        public static string QUERY_FILE = "select * from tm_files where fileId = @fileId";

        /// <summary>
        /// "select * from tm_trade_category where tradeType = @tradeType";
        /// </summary>
        public static string QUERY_TM_TRADE_CATEGORY = "select * from tm_trade_category where tradeType = @tradeType";

        /// <summary>
        /// "update tm_reg_applicant_detail_person set name = @name, proveFileName = @proveFileName, idCardNum = @idCardNum, region = @region, address = @address,contact = @contact, phone = @phone, fax = @fax, zip = @zip, proveFile = @proveFile, idCardFile = @idCardFile, createDate =@createDate,statue =@statue where applicantId = @applicantId";
        /// </summary>
		public static string UPDATE_PERSON_APPLICANT = "update tm_reg_applicant_detail_person set province=@province, city=@city,county=@county, name = @name, proveFileName = @proveFileName, idCardNum = @idCardNum,  address = @address,contact = @contact, phone = @phone, fax = @fax, zip = @zip, proveFile = @proveFile, idCardFile = @idCardFile, createDate =@createDate,statue =@statue, receiveAddress=@receiveAddress, receiver=@receiver, receiverPhone=@receiverPhone where applicantId = @applicantId";

        /// <summary>
        ///   "update tm_reg_applicant_detail_orgnize set name = @name,region = @region, address = @address,contact = @contact, phone = @phone, fax = @fax, zip = @zip, proveFile = @proveFile, idCardFile = @idCardFile,statue =@statue where applicantId = @applicantId";
        /// </summary>
		public static string UPDATE_ORGNIZE_APPLICANT = "update tm_reg_applicant_detail_orgnize set province=@province, city=@city,county=@county,  name = @name, address = @address,contact = @contact, phone = @phone, fax = @fax, zip = @zip, proveFile = @proveFile,createDate =@createDate,statue =@statue,legalPersonName=@legalPersonName,isManagers=@isManagers,managersName=@managersName,receiveAddress=@receiveAddress,receiver=@receiver,receiverPhone=@receiverPhone where applicantId = @applicantId";

        /// <summary>
        ///   "update tm_reg_applicant_detail_biz set name = @name,region = @region, address = @address,contact = @contact, phone = @phone, fax = @fax, zip = @zip, proveFile = @proveFile, idCardFile = @idCardFile,statue =@statue where applicantId = @applicantId";
        /// </summary>
		public static string UPDATE_BIZ_APPLICANT = "update tm_reg_applicant_detail_biz set province=@province, city=@city,county=@county,  name = @name, address = @address,contact = @contact, phone = @phone, fax = @fax, zip = @zip, proveFile = @proveFile, idCardFile = @idCardFile,createDate=@createDate,statue =@statue,receiveAddress=@receiveAddress, receiver=@receiver, receiverPhone=@receiverPhone where applicantId = @applicantId";

        /// <summary>
        /// "insert into tm_reg_applicant_detail_person (userId,applicantId) values (@userId,@applicantId)";
        /// </summary>
        public static string INSERT_REG_PERSON_APPLICANT = "insert into tm_reg_applicant_detail_person (userId,applicantId,name) values (@userId,@applicantId,@name)";

        /// <summary>
        /// "insert into tm_reg_applicant_detail_biz (userId,applicantId) values (@userId,@applicantId)";
        /// </summary>
        public static string INSERT_REG_BIZ_APPLICANT = "insert into tm_reg_applicant_detail_biz (userId,applicantId,name) values (@userId,@applicantId,@name)";

        /// <summary>
        /// "insert into tm_reg_applicant_detail_orgnize (userId,applicantId) values (@userId,@applicantId)";
        /// </summary>
        public static string INSERT_REG_ORGNIZE_APPLICANT = "insert into tm_reg_applicant_detail_orgnize (userId,applicantId,name) values (@userId,@applicantId,@name)";

        /// <summary>
        /// "select bizName from user where phone = @phone";
        /// </summary>
        public static string QUERY_USER_FOR_PHONE = "select bizName from user where phone = @phone";

        /// <summary>
        /// select count(id) from verifycodes where phone = @phone and date(createDate) = @date
        /// </summary>
        public static string QUERY_PHONE_NUM = "select count(id) from verifycodes where phone = @phone and date(createDate) = @date ";

        /// <summary>
        /// select count(id) from verifycodes where phone = @phone and isPass = true 
        /// </summary>
        public static string QUERY_PHONE_ALREADEY = "select count(id) from verifycodes where phone = @phone and isPass = true ";
		/// <summary>
		/// update tm_reg_applicant_detail_person set statue = '等待审核' where applicantId = @applicantId
		/// </summary>
		public static string APPROVAL_PERSON = "update tm_reg_applicant_detail_person set statue = '等待审核' where applicantId = @applicantId";
        /// <summary>
        /// update tm_reg_applicant_detail_biz set statue = '等待审核' where applicantId = @applicantId
        /// </summary>
        public static string APPROVAL_BIZ = "update tm_reg_applicant_detail_biz set statue = '等待审核' where applicantId = @applicantId";
		/// <summary>
		/// select tm_reg_tm_info.* ,tm_reg_applicant_view.name as ApplicantName  from tm_reg_tm_info join tm_reg_applicant_view on tm_reg_tm_info.applicantId =  tm_reg_applicant_view.applicantID where applicantID = @applicantID
		/// </summary>
		public static string QUERY_TM_LIST_BY_AID = "select tm_reg_tm_info.* ,tm_reg_applicant_view.name as ApplicantName,tm_reg_applicant_view.statue as ApplicantStatue,tm_reg_applicant_view.category as ApplicantCategory from tm_reg_tm_info join tm_reg_applicant_view on tm_reg_tm_info.applicantId =  tm_reg_applicant_view.applicantID where tm_reg_tm_info.applicantID = @applicantID";
		/// <summary>
		/// select tm_reg_tm_info.* ,tm_reg_applicant_view.name as ApplicantName  from tm_reg_tm_info join tm_reg_applicant_view on tm_reg_tm_info.applicantId =  tm_reg_applicant_view.applicantID where statue = @statue and regStatue=@regStatue
		/// </summary>
		public static string QUERY_TM_LIST_BY_STATUE = "select tm_reg_tm_info.* ,tm_reg_applicant_view.name as ApplicantName ,user.bizName as BizName,user.phone as phone,tm_reg_employee.alias as alias from tm_reg_tm_info join tm_reg_applicant_view on tm_reg_tm_info.applicantId =  tm_reg_applicant_view.applicantID join user on tm_reg_tm_info.userID = user.phone join tm_reg_employee on tm_reg_employee.workID=user.bizName where {0}";
		/// <summary>
		/// select tm_reg_tm_info.* ,tm_reg_applicant_view.name as ApplicantName  from tm_reg_tm_info join tm_reg_applicant_view on tm_reg_tm_info.applicantId =  tm_reg_applicant_view.applicantID where userID = @uid
		/// </summary>
		public static string QUERY_TM_LIST_BY_UID = "select tm_reg_tm_info.* ,tm_reg_applicant_view.name as ApplicantName,tm_reg_applicant_view.statue as ApplicantStatue,tm_reg_applicant_view.category as ApplicantCategory from tm_reg_tm_info join tm_reg_applicant_view on tm_reg_tm_info.applicantId =  tm_reg_applicant_view.applicantID where tm_reg_tm_info.userID = @uid and tm_reg_tm_info.name <> ''";
		/// <summary>
		/// select * from tm_reg_applicant_view where applicantID = @applicantID
		/// </summary>
		public static string QUERY_APPLICANT_BY_ID = "select * from tm_reg_applicant_view where applicantID = @applicantID";
		/// <summary>
		/// insert into tm_reg_tm_info (userID,applicantID,tmID) values (@userID,@applicantID,@tmID)
		/// </summary>
		public static string INSERT_TM_INFO = "insert into tm_reg_tm_info (userID,applicantID,tmID) values (@userID,@applicantID,@tmID)";

		/// <summary>
        /// 根据商标ID号修改商标的审核报件状态
        /// </summary>
        public static string APPREVAL_TM_INFO_REGSTATUE = "update tm_reg_tm_info set regStatue = @statue,stateChangeDate = @stateChangeDate where tmID = @tmID";

        /// <summary>
        /// select tm_reg_tm_info.* ,tm_reg_applicant_view.name as ApplicantName  from tm_reg_tm_info join tm_reg_applicant_view on tm_reg_tm_info.applicantId =  tm_reg_applicant_view.applicantID where tmId = @tmId 
        /// </summary>
        public static string QUERY_TM_INFO = "select tm_reg_tm_info.* ,tm_reg_applicant_view.name as ApplicantName  from tm_reg_tm_info join tm_reg_applicant_view on tm_reg_tm_info.applicantId =  tm_reg_applicant_view.applicantID where tmId = @tmId ";
        /// <summary>
        /// update tm_reg_applicant_detail_biz set statue = '等待审核' where applicantId = @applicantId
        /// </summary>
        public static string APPROVAL_ORGNIZE = "update tm_reg_applicant_detail_orgnize set statue = '等待审核' where applicantId = @applicantId";
		/// <summary>
		/// select * from tm_reg_pay where orderId = @orderId
		/// </summary>
		public static string QUERY_PAYMENT_INFO = "select * from tm_reg_pay where orderId = @orderId";
		/// <summary>
		/// select applicantID, name from tm_reg_tm_info where tmID = @tmId
		/// </summary>
		public static string QUERY_PROXY_BY_TMID = "select applicantID, name from tm_reg_tm_info where tmID = @tmId";

		/// <summary>
		/// select name, address,contact,phone,zip from tm_reg_applicant_view where applicantID = @applicantId
		/// </summary>
		public static string QUERY_PROXY_BY_AID = "select name,province,city, county,address,contact,phone,zip from tm_reg_applicant_view where applicantID = @applicantId";

        /// <summary>
        /// select distinct(province) from tm_regionalism order by province
        /// </summary>
        public static string QUERY_PROVINCE_LIST = "select distinct(province) from tm_regionalism order  by province";

        /// <summary>
        ///select distinct(city) from tm_regionalism where province=@province order by city
        /// </summary>
        public static string QUERY_CITY_LIST = "select distinct(city) from tm_regionalism where province=@province order by city";

        /// <summary>
        /// select country from tm_regionalism where city=@city order by country
        /// </summary>
        public static string QUERY_COUNTRY_LIST = "select county from tm_regionalism where city=@city order by county";

        /// <summary>
        /// select name,short,content,comment from alibb_tm.tm_category where id=@id
        /// </summary>
        public static string QUERY_CATEGORY = "select * from alibb_tm.tm_category where id=@id";

        /// <summary>
		/// select * from alibb_tm.tm_group where categoryId=@id
        /// </summary>
		public static string QUERY_GROUP = "select * from alibb_tm.tm_group where categoryId=@id";

        /// <summary>
        /// select a.name,a.content,b.name,b.content_zh,b.content_en,b.comment from alibb_tm.tm_group a inner join alibb_tm.tm_item b on a.id=b.groupId
        /// </summary>
        public static string QUERY_TRADE_CATEGORY = "select a.name,a.content,b.name,b.content_zh,b.content_en,b.comment from alibb_tm.tm_group a inner join alibb_tm.tm_item b on a.id=b.groupId";

        /// <summary>
        /// select tradeType,category from tm_trade_category
        /// </summary>
        public static string QUERY_CATEGORYS = "select tradeType,category from tm_trade_category";
		/// <summary>
		/// select * from tm_group where categoryId = @cid
		/// </summary>
		public static string QUERY_GROUPS = "select * from tm_group where categoryId = @cid";
		/// <summary>
		/// select tm_item.*, tm_group.content as GroupName from tm_item join tm_group on tm_group.id= tm_item.GroupId where GroupId = @gid
		/// </summary>
		public static string QUERY_ITEMS = "select tm_item.*, tm_group.content as GroupName from tm_item join tm_group on tm_group.id= tm_item.GroupId where GroupId = @gid and tm_item.name <> '非规范'";
		/// <summary>
		/// select items from tm_reg_item where tmId = '{1}' and tmCategoryId='{0}'
		/// </summary>
		public static string QUERY_ITEMS_BY_TM = "select items from tm_reg_item where tmId = '{1}' and tmCategoryId='{0}'";
		/// <summary>
		/// select tm_item.*, tm_group.content as GroupName from tm_item join tm_group on tm_group.id= tm_item.GroupId where id in @ids
		/// </summary>
		public static string QUERY_ITEMS_BY_ID = "select tm_item.*, tm_group.content as GroupName from tm_item join tm_group on tm_group.id= tm_item.GroupId where tm_item.id in @ids and tm_item.name <> '非规范'";
		/// <summary>
		/// select * from tm_group where categoryId = @cid
		/// </summary>
		public static string QUERY_CATEGORY_CID = "select * from tm_category where id = @cid";
		/// <summary>
		/// "select * from alibb_tm.tm_group where id=@id";
		/// </summary>
		public static string QUERY_GROUP_BY_ID = "select * from alibb_tm.tm_group where id=@id";
		/// <summary>
		/// select * from alibb_tm.tm_item where GroupId=@gid
		/// </summary>
		public static string QUERY_ITEMS_BY_GROUP = "select * from alibb_tm.tm_item where GroupId=@gid";
		
        /// <summary>
        /// 查询所有员工信息
        /// </summary>
        public static string QUERY_EMPLOYEES = "select * from alibb_tm.tm_reg_employee";

        /// <summary>
        /// 修改员工信息
        /// </summary>
        public static string UPDATE_EMPLOYEE = "update tm_reg_employee set name = @name, alias = @alias, englishName = @englishName, sex = @sex, position = @position, departmentName = @departmentName, departmentID = @departmentID, workID = @workID, tel_Num = @tel_Num, qq_Num = @qq_Num, weChat_Num = @weChat_Num, idCard_Num = @idCard_Num, address = @address, photo = @photo, role = @role, pwd = @pwd, phone_Num = @phone_Num, extension_Num = @extension_Num where id = @id";

        /// <summary>
        /// 新增员工信息
        /// </summary>
        public static string INSERT_EMPLOYEE = "insert into tm_reg_employee (name,alias,englishName,sex,position,departmentName,departmentID,workID,tel_Num,qq_Num,weChat_Num,idCard_Num,address,photo,role,pwd,phone_Num,extension_Num) values (@name,@alias,@englishName,@sex,@position,@departmentName,@departmentID,@workID,@tel_Num,@qq_Num,@weChat_Num,@idCard_Num,@address,@photo,@role,@pwd,@phone_Num,@extension_Num);";


        /// <summary>
        /// 删除员工信息
        /// </summary>
        public static string DELETE_EMPLOYEE = "delete from tm_reg_employee where id = @id";

        /// <summary>
        /// 查询所有系统参数信息
        /// </summary>
        public static string QUERY_SYS_PAR = "select * from tm_sys_par";

        /// <summary>
        /// 更新系统参数信息
        /// </summary>
        public static string UPDATE_SYS_PAR = "update tm_sys_par set value=@value where name=@name";

        public static string QUERY_BIZ_NAME_BY_ID = "select name from tm_reg_employee where workID = @id";
 

    }
}