using SchoolAPI.Models;
using SchoolAPI.Param;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolAPI.BusinessLayer

{
    public class MenuBussiness
    {
        SchoolERPContext db = new SchoolERPContext();
        SchoolAdminContext data = new SchoolAdminContext();

        public object GetSiteMenu()
        {
            var menu = data.Tbl_ModuleMaster.Where(r=>r.Status==1).ToList();
           // var menu = db.View_MenuList.Where(r => r.Status == 1).ToList();
            return menu;
        }




        public object GetMenu()
        {
            List<ResultForMenu> lt = new List<ResultForMenu>();
           
            long id = 0;
            var Modules = db.TblModuleMasters.Where(r => r.ParentModuleId == 0).ToList();
            if (Modules.Count != 0)
            {

                foreach (var s in Modules)
                {
                    List<ResultForSubMenu> lt2 = new List<ResultForSubMenu>();
                

                    ResultForMenu ddl = new ResultForMenu();

                    ddl.id = s.ModuleId;
                    ddl.text = s.ModuleName;

                    var menu = db.View_Sub_Menu.Where(r => r.ParentModuleId == s.ModuleId).ToList();
                   
                        if(menu.Count!=0)
                        {
                        foreach (var Sub in menu)
                        {
                           

                            ddl.state = "{ 'selected': true }";

                            ResultForSubMenu ddl2 = new ResultForSubMenu();
                            ddl2.id = Sub.ModuleId;
                            ddl2.text = Sub.ModuleName;

                            lt2.Add(ddl2);

                            List<ResultForSubMenu> lt3 = new List<ResultForSubMenu>();
                            var Submenu = db.View_Sub_Menu.Where(r => r.ParentModuleId == Sub.ModuleId).ToList();
                            {
                                if (Submenu.Count != 0)
                                {
                                    foreach (var SubSubMenu in Submenu)
                                    {
                                        ResultForSubMenu ddl3 = new ResultForSubMenu();
                                        ddl2.state = "{ 'selected': true }";
                                        ddl3.id = SubSubMenu.ModuleId;
                                        ddl3.text = SubSubMenu.ModuleName;

                                        lt3.Add(ddl3);

                                        List<ResultForSubMenu> lt4 = new List<ResultForSubMenu>();
                                        var Submenusub = db.View_Sub_Menu.Where(r => r.ParentModuleId == SubSubMenu.ModuleId).ToList();
                                        if (Submenusub.Count != 0)
                                        {
                                            foreach (var sub2 in Submenusub)
                                            {
                                                ResultForSubMenu ddl4 = new ResultForSubMenu();
                                                ddl3.state = "{ 'selected': true }";
                                                ddl4.id = sub2.ModuleId;
                                                ddl4.text = sub2.ModuleName;

                                                lt4.Add(ddl4);
                                            }
                                            ddl3.children = lt4;
                                        }


                                                ddl2.children = lt3;
                                    }
                                }
                            }
                            ddl.children = lt2;
                        }
                         
                      }
                    

                    lt.Add(ddl);

                }
                   
            }

            return lt;
        }
        public object GetRole()
        {
            var result = db.TblRoleMasters.Where(r=>r.Status==1).ToList();
            return result;
        }

       

        public object Getdata()
        {
            var Modules = db.TblModuleMasters.OrderBy(r => r.ModuleId).ThenBy(r => r.ParentModuleId).ToList();
            List<ResultForMenu> lt = new List<ResultForMenu>();
            foreach (var s in Modules)
            {
                ResultForMenu ddl = new ResultForMenu();
                ddl.id = s.ParentModuleId;
                ddl.text = s.ModuleName;
             
                lt.Add(ddl);
            }
            
            return lt;
        }
        public object SaveMenu(MenuSubMenuParam ObjMenu)
        {
            TblRoleMaster objrole = new TblRoleMaster();
            objrole.Role = ObjMenu.Role;
            objrole.Status = 1;
            objrole.CreatedBy = 1;
            objrole.CreatedDate = DateTime.Now;
            db.TblRoleMasters.Add(objrole);
            db.SaveChanges();

            TblMenu objSubmenu = new TblMenu();
            objSubmenu.RoleId = objrole.RoleId;
            string[] sbno = ObjMenu.selectedid.Split(',');
          
            for (int i = 0; i < sbno.Length; i++)
            {

                if (sbno[i] != "0")

                {
                    objSubmenu.ModuleId = int.Parse(sbno[i]);
                    objSubmenu.CreatedBy = 1;
                    objSubmenu.CreatedDate = DateTime.Now;
                    objSubmenu.Status = 1;
                    db.TblMenus.Add(objSubmenu);
                    db.SaveChanges();
                }
            }
            TblUserRole objuserrole = new TblUserRole();
            objuserrole.RoleId = objrole.RoleId;
            objuserrole.AllowInsert = ObjMenu.AllowInsert;
            objuserrole.AllowEdit = ObjMenu.AllowEdit;
            objuserrole.AllowDelete = ObjMenu.AllowDelete;
            objuserrole.AllowView = ObjMenu.AllowView;
            objuserrole.CreatedBy = 1;
            objuserrole.CreatedDate = DateTime.Now;
            objuserrole.Status = 1;
            db.TblUserRoles.Add(objuserrole);
            db.SaveChanges();









            return "";
        }
        public object GetSingleSubMenu(MenuSubMenuParam ObjMenu)
        {
            string ids="0";
            var DataUpdate = db.Vw_MenuSubMenu.Where(r => r.RoleId == ObjMenu.RoleId).ToList();
            for (int i = 0; i < DataUpdate.Count; i++)
            {
                ids = ids +","+ DataUpdate[i].ModuleId;

            }
          
            return ids;
            
        }

        public object GetDuplicateMenu(MenuSubMenuParam ObjMenu)
        {
            bool value;
            TblRoleMaster objrole = db.TblRoleMasters.Where(r => r.Role == ObjMenu.Role).FirstOrDefault();
            if(objrole!=null)
            {
                value = true;
            }
            else
            {
                value = false;
            }
        

            return value;

        }
        public  object UpdateMenuSubMenu(MenuSubMenuParam ObjMenu)
        {
            TblRoleMaster objrole = db.TblRoleMasters.SingleOrDefault(r => r.RoleId == ObjMenu.RoleId);


            objrole.Role = ObjMenu.Role;
            objrole.Status = 1;
         
            objrole.ModifiedBy = 1;
            objrole.ModifiedDate = DateTime.Now;

            db.SaveChanges();

            TblMenu objSubmenu = new TblMenu();

            objSubmenu.RoleId = ObjMenu.RoleId;
            string[] sbno = ObjMenu.selectedid.Split(',');


            for (int i = 0; i < sbno.Length; i++)
            {

                if (sbno[i] != "0")

                {
                    objSubmenu.ModuleId = int.Parse(sbno[i]);
                    objSubmenu.CreatedBy = 1;
                    objSubmenu.CreatedDate = DateTime.Now;
                    objSubmenu.Status = 1;
                   

                    db.TblMenus.Add(objSubmenu);
                    db.SaveChanges();
                }
            }


            string[] sbuncheck = ObjMenu.Unselectedid.Split(',');
            for (int i = 0; i < sbuncheck.Length; i++)
            {

                if (sbuncheck[i] != "0")
                {
                    int MenuId = int.Parse(sbuncheck[i]);
                    TblMenu objmenu = db.TblMenus.SingleOrDefault(r => r.RoleId == ObjMenu.RoleId && r.ModuleId== MenuId);
                    objmenu.Status = 0;
                    db.SaveChanges();
                }
            }

            return "";
        }
        public class ResultForMenu
        {
            public string text
            {
                get;
                set;

            }
            public Int64 id
            {
                get;
                set;

            }
            public object state
            {
                get; set; }

            public object children { get; set; }


        }

        public class ResultForSubMenu
        {

             public string text
            {
                get;
                set;

            }
            public Int64 id
            {
                get;
                set;

            }
            public object state
            {
                get; set;
            }

            public object children { get; set; }
        }

    }
}