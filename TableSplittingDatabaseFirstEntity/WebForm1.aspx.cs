﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;


namespace TableSplittingDatabaseFirstEntity
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (CheckBox1.Checked)
            {
                GridView1.DataSource = GetEmployeeDataIncludingContactDetails();
            }
            else 
            {
                GridView1.DataSource = GetEmployeeData();
            }
            GridView1.DataBind();
        }
        private DataTable GetEmployeeDataIncludingContactDetails()
        {
            EmployeeDBContext employeeDBContext = new EmployeeDBContext();
            List<Employee> employees = employeeDBContext.Employees.Include("EmployeeContactDetail").ToList();
            DataTable dt = new DataTable();
            DataColumn[] datacolumns = { new DataColumn("ID"), new DataColumn("FirstName") , new DataColumn("LastName"),
                new DataColumn("Gender"),new DataColumn("Email"),new DataColumn("Mobile"),new DataColumn("LandLine")};

            dt.Columns.AddRange(datacolumns);

            foreach (Employee employee in employees)
            {
                DataRow dr = dt.NewRow();
                dr["ID"] = employee.ID;
                dr["FirstName"] = employee.FirstName;
                dr["LastName"] = employee.LastName;
                dr["Gender"] = employee.Gender;
                dr["Email"] = employee.EmployeeContactDetail.Email;
                dr["Mobile"] = employee.EmployeeContactDetail.Mobile;
                dr["LandLine"] = employee.EmployeeContactDetail.LandLine;

                dt.Rows.Add(dr);

            }
            return dt;
        }
        private DataTable GetEmployeeData()
        {
            EmployeeDBContext employeeDBContext = new EmployeeDBContext();
            List<Employee> employees = employeeDBContext.Employees.ToList();
            DataTable dt = new DataTable();
            DataColumn[] datacolumns = { new DataColumn("ID"), new DataColumn("FirstName") , new DataColumn("LastName"),
                new DataColumn("Gender")};

            dt.Columns.AddRange(datacolumns);

            foreach (Employee employee in employees)
            {
                DataRow dr = dt.NewRow();
                dr["ID"] = employee.ID;
                dr["FirstName"] = employee.FirstName;
                dr["LastName"] = employee.LastName;
                dr["Gender"] = employee.Gender;

                dt.Rows.Add(dr);

            }
            return dt;
        }
    }
}