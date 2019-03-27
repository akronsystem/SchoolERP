namespace SchoolAPI
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using SchoolAPI.Models;

    public partial class SchoolERPContext : DbContext
    {
        public SchoolERPContext()
            : base("name=SchoolERPContext")
        {
        }
        public virtual DbSet<TblBoard> TblBoards { get; set; }
        public virtual DbSet<TblBoardDetail> TblBoardDetails { get; set; }
        public virtual DbSet<Tbl_Widget_Master> Tbl_Widget_Master { get; set; }
        public virtual DbSet<ViewWidgetList> ViewWidgetLists { get; set; }

        public virtual DbSet<TblLanguage> TblLanguages { get; set; }
        public virtual DbSet<ViewTemplateMaster> ViewTemplateMasters { get; set; }
        public virtual DbSet<ViewTemplateType> ViewTemplateTypes { get; set; }
        public virtual DbSet<TblModuleMaster> TblModuleMasters { get; set; }
        public virtual DbSet<TblRoleMaster> TblRoleMasters { get; set; }
        public virtual DbSet<TblSchool> TblSchools { get; set; }
        public virtual DbSet<TblTemplateModule> TblTemplateModules { get; set; }
        public virtual DbSet<TblTemplatesMaster> TblTemplatesMasters { get; set; }
        public virtual DbSet<TblTemplateTypeMaster> TblTemplateTypeMasters { get; set; }
        public virtual DbSet<TblUserLogin> TblUserLogins { get; set; }
        public virtual DbSet<TblUserModule> TblUserModules { get; set; }
        public virtual DbSet<TblUserRole> TblUserRoles { get; set; } 
        public virtual DbSet<View_Sub_Menu> View_Sub_Menu { get; set; }
        public virtual DbSet<TblMenu> TblMenus { get; set; }
        public virtual DbSet<Vw_MenuSubMenu> Vw_MenuSubMenu { get; set; } 
        public virtual DbSet<ViewModuleMaster> ViewModuleMasters { get; set; }

        public virtual DbSet<View_Template> View_Template { get; set; }
        public virtual DbSet<ViewBindMenuListUpdate> ViewBindMenuListUpdates { get; set; }
        public virtual DbSet<View_MenuList> View_MenuList { get; set; }
        public virtual DbSet<ViewDisplayTemplateMaster> ViewDisplayTemplateMasters { get; set; }
        public virtual DbSet<ViewSchoolList> ViewSchoolLists { get; set; }
        public virtual DbSet<View_SchoolDetails> View_SchoolDetails { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
