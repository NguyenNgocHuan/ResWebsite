﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ResWebsite.DAL.Entity1
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="QuanLyNhaHang")]
	public partial class ScriptFunctionsDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    #endregion
		
		public ScriptFunctionsDataContext() : 
				base(global::ResWebsite.DAL.Properties.Settings.Default.QuanLyNhaHangConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public ScriptFunctionsDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public ScriptFunctionsDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public ScriptFunctionsDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public ScriptFunctionsDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.auto_maBinhLuan", IsComposable=true)]
		public string auto_maBinhLuan()
		{
			return ((string)(this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod()))).ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.auto_maVatTu", IsComposable=true)]
		public string auto_maVatTu()
		{
			return ((string)(this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod()))).ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.auto_maChamCong", IsComposable=true)]
		public string auto_maChamCong()
		{
			return ((string)(this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod()))).ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.auto_maDiaDiem", IsComposable=true)]
		public string auto_maDiaDiem()
		{
			return ((string)(this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod()))).ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.auto_maDichVu", IsComposable=true)]
		public string auto_maDichVu()
		{
			return ((string)(this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod()))).ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.auto_maHoaDonGoiMon", IsComposable=true)]
		public string auto_maHoaDonGoiMon()
		{
			return ((string)(this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod()))).ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.auto_maHoaDonNhapKho", IsComposable=true)]
		public string auto_maHoaDonNhapKho()
		{
			return ((string)(this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod()))).ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.auto_maHoaDonXuatKho", IsComposable=true)]
		public string auto_maHoaDonXuatKho()
		{
			return ((string)(this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod()))).ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.auto_maHopDongDatTiec", IsComposable=true)]
		public string auto_maHopDongDatTiec()
		{
			return ((string)(this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod()))).ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.auto_maKhachHang", IsComposable=true)]
		public string auto_maKhachHang()
		{
			return ((string)(this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod()))).ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.auto_maLuong", IsComposable=true)]
		public string auto_maLuong()
		{
			return ((string)(this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod()))).ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.auto_maMonAnThucUong", IsComposable=true)]
		public string auto_maMonAnThucUong()
		{
			return ((string)(this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod()))).ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.auto_maNghiepVu", IsComposable=true)]
		public string auto_maNghiepVu()
		{
			return ((string)(this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod()))).ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.auto_maNhaCungCap", IsComposable=true)]
		public string auto_maNhaCungCap()
		{
			return ((string)(this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod()))).ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.auto_maNhanVien", IsComposable=true)]
		public string auto_maNhanVien()
		{
			return ((string)(this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod()))).ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.auto_maQH", IsComposable=true)]
		public string auto_maQH()
		{
			return ((string)(this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod()))).ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.auto_maThucDon", IsComposable=true)]
		public string auto_maThucDon()
		{
			return ((string)(this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod()))).ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.auto_maCaLamViec", IsComposable=true)]
		public string auto_maCaLamViec()
		{
			return ((string)(this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod()))).ReturnValue));
		}
	}
}
#pragma warning restore 1591
