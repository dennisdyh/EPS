
/*==============================================================*/
/* Table: ActionModules                                         */
/*==============================================================*/
create table "ActionModules" (
   "ActionModuleId"       SERIAL not null,
   "ActionId"             INT4                 null,
   "ModuleId"             INT4                 null,
   "Status"               BOOL                 null,
   constraint "PK_ActionModules_ActionModuleId" primary key ("ActionModuleId")
);

/*==============================================================*/
/* Table: Actions                                               */
/*==============================================================*/
create table "Actions" (
   "ActionId"             SERIAL not null,
   "ActionCode"           VARCHAR(50)          null,
   "DisplayName"          VARCHAR(50)          null,
   "SeqNo"                INT4                 null,
   "Description"          VARCHAR(500)         null,
   "CreatedBy"            VARCHAR(50)          null,
   "CreatedTime"          TIMESTAMP            null,
   "ChangedBy"            VARCHAR(50)          null,
   "ChangedTime"          TIMESTAMP            null,
   constraint "PK_Actions_ActionId" primary key ("ActionId"),
   constraint "UNQ_Actions_ActionCode" unique ("ActionCode")
);

/*==============================================================*/
/* Table: Basics                                                */
/*==============================================================*/
create table "Basics" (
   "Id"                   SERIAL not null,
   "Key"                  VARCHAR(50)          null,
   "Value"                VARCHAR(400)         null,
   constraint "PK_Basics_Id" primary key ("Id"),
   constraint "UNQ_Basics_Key" unique ("Key")
);

/*==============================================================*/
/* Table: Modules                                               */
/*==============================================================*/
create table "Modules" (
   "ModuleId"             SERIAL not null,
   "ParentId"             INT4                 null,
   "ModuleCode"           VARCHAR(50)          null,
   "DisplayName"          VARCHAR(50)          null,
   "DisplayAsMenu"        BOOL                 null,
   "WebsiteFrontMenu"     BOOL                 null,
   "Article"              BOOL                 null,
   "ClassName"            VARCHAR(20)          null,
   "Url"                  VARCHAR(100)         null,
   "FrontURL"             VARCHAR(100)         null,
   "SeqNo"                INT4                 null,
   "Description"          VARCHAR(500)         null,
   "CreatedBy"            VARCHAR(50)          null,
   "CreatedTime"          TIMESTAMP            null,
   "ChangedBy"            VARCHAR(50)          null,
   "ChangedTime"          TIMESTAMP            null,
   constraint "PK_Modules_ModuleId" primary key ("ModuleId"),
   constraint "UNQ_Modules_ModuleCode" unique ("ModuleCode")
);

/*==============================================================*/
/* Table: News                                                  */
/*==============================================================*/
create table "News" (
   "NewsId"               SERIAL not null,
   "ParentId"             INT4                 null,
   "ModuleId"             INT4                 null,
   "Title"                VARCHAR(200)         null,
   "Author"               VARCHAR(50)          null,
   "Source"               VARCHAR(100)         null,
   "Brief"                VARCHAR(300)         null,
   "Content"              TEXT                 null,
   "Count"                INT4                 null,
   "CreatedBy"            VARCHAR(50)          null,
   "CreatedTime"          TIMESTAMP            null,
   "ChangedBy"            VARCHAR(50)          null,
   "ChangedTime"          TIMESTAMP            null,
   constraint "PK_News_NewsId" primary key ("NewsId")
);

/*==============================================================*/
/* Index: IDX_NewsId_ModuleId                                   */
/*==============================================================*/
create unique index "IDX_NewsId_ModuleId" on "News" (
"NewsId",
"ModuleId"
);

/*==============================================================*/
/* Index: IDX_ModuleId                                          */
/*==============================================================*/
create  index "IDX_ModuleId" on "News" (
"ModuleId"
);

/*==============================================================*/
/* Index: IDX_Title                                             */
/*==============================================================*/
create  index "IDX_Title" on "News" (
"Title"
);

/*==============================================================*/
/* Table: Photos                                                */
/*==============================================================*/
create table "Photos" (
   "PhotoId"              SERIAL not null,
   "NewsId"               INT4                 null,
   "Thumbnail"            VARCHAR(200)         null,
   "Original"             VARCHAR(200)         null,
   "PublishHome"          BOOL                 null,
   "Description"          VARCHAR(400)         null,
   constraint "PK_Photos_PhotoId" primary key ("PhotoId")
);

/*==============================================================*/
/* Table: RoleRights                                            */
/*==============================================================*/
create table "RoleRights" (
   "RightId"              SERIAL not null,
   "RoleId"               INT4                 null,
   "ActionModuleId"       INT4                 null,
   "Status"               BOOL                 null,
   constraint "PK_RoleRights_RightId" primary key ("RightId")
);

/*==============================================================*/
/* Table: Roles                                                 */
/*==============================================================*/
create table "Roles" (
   "RoleId"               SERIAL not null,
   "RoleCode"             VARCHAR(50)          not null,
   "DisplayName"          VARCHAR(50)          null,
   "SeqNo"                INT4                 null,
   "Description"          VARCHAR(500)         null,
   "CreatedBy"            VARCHAR(50)          null,
   "CreatedTime"          TIMESTAMP            null,
   "ChangedBy"            VARCHAR(50)          null,
   "ChangedTime"          TIMESTAMP            null,
   constraint "PK_Roles_RoleId" primary key ("RoleId"),
   constraint "UNQ_Roles_RoleCode" unique ("RoleCode")
);

/*==============================================================*/
/* Index: IDX_RoleId_RoleCode                                   */
/*==============================================================*/
create unique index "IDX_RoleId_RoleCode" on "Roles" (
"RoleId",
"RoleCode"
);

/*==============================================================*/
/* Table: UserRoles                                             */
/*==============================================================*/
create table "UserRoles" (
   "UserRoleId"          SERIAL not null,
   "UserId"              INT4                 null,
   "RoleId"              INT4                 null,
   "Status"               BOOL                 null,
   constraint "PK_UserRoles_UserRoleId" primary key ("UserRoleId")
);

/*==============================================================*/
/* Table: Users                                                 */
/*==============================================================*/
create table "Users" (
   "UserId"               SERIAL not null,
   "UserName"             VARCHAR(50)          null,
   "Password"             VARCHAR(50)          null,
   "Email"                VARCHAR(100)         null,
   "FirstName"            VARCHAR(50)          null,
   "LastName"             VARCHAR(50)          null,
   "Language"             VARCHAR(50)          null,
   "CreatedBy"            VARCHAR(50)          null,
   "CreatedTime"          TIMESTAMP            null,
   "ChangedBy"            VARCHAR(50)          null,
   "ChangedTime"          TIMESTAMP            null,
   constraint "PK_Users_UserId" primary key ("UserId"),
   constraint "UNQ_Users_UserName" unique ("UserName"),
   constraint "UNQ_Users_Email" unique ("Email")
);

/*==============================================================*/
/* Index: IDX_UserID_UserName_Email                             */
/*==============================================================*/
create unique index "IDX_UserID_UserName_Email" on "Users" (
"UserId",
"UserName",
"Email"
);

alter table "ActionModules"
   add constraint "FK_ActionModuels_RF_Actions" foreign key ("ActionId")
      references "Actions" ("ActionId")
      on delete cascade on update restrict;

alter table "ActionModules"
   add constraint "FK_ActionModules_RF_Modules" foreign key ("ModuleId")
      references "Modules" ("ModuleId")
      on delete cascade on update restrict;

alter table "News"
   add constraint "FK_News_RF_Modules" foreign key ("ModuleId")
      references "Modules" ("ModuleId");

alter table "Photos"
   add constraint "FK_Photos_RF_News" foreign key ("NewsId")
      references "News" ("NewsId")
      on delete cascade;

alter table "RoleRights"
   add constraint "FK_RoleRights_RF_ActionModules" foreign key ("ActionModuleId")
      references "ActionModules" ("ActionModuleId")
      on delete cascade on update restrict;

alter table "RoleRights"
   add constraint "FK_RoleRights_RF_Roles" foreign key ("RoleId")
      references "Roles" ("RoleId")
      on delete cascade on update restrict;

alter table "UserRoles"
   add constraint "FK_UserRoles_RF_Roles" foreign key ("RoleId")
      references "Roles" ("RoleId")
      on delete cascade on update restrict;

alter table "UserRoles"
   add constraint "FK_UserRoles_RF_Users" foreign key ("UserId")
      references "Users" ("UserId")
      on delete cascade on update restrict;

