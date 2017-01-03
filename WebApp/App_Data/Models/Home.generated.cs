//------------------------------------------------------------------------------
// <auto-generated>
//   This code was generated by a tool.
//
//    Umbraco.ModelsBuilder v3.0.5.96
//
//   Changes to this file will be lost if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Web;
using Umbraco.Core.Models;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web;
using Umbraco.ModelsBuilder;
using Umbraco.ModelsBuilder.Umbraco;

namespace Umbraco.Web.PublishedContentModels
{
	/// <summary>Home</summary>
	[PublishedContentModel("home")]
	public partial class Home : PublishedContentModel, IBaseContent, ISEO
	{
#pragma warning disable 0109 // new is redundant
		public new const string ModelTypeAlias = "home";
		public new const PublishedItemType ModelItemType = PublishedItemType.Content;
#pragma warning restore 0109

		public Home(IPublishedContent content)
			: base(content)
		{ }

#pragma warning disable 0109 // new is redundant
		public new static PublishedContentType GetModelContentType()
		{
			return PublishedContentType.Get(ModelItemType, ModelTypeAlias);
		}
#pragma warning restore 0109

		public static PublishedPropertyType GetModelPropertyType<TValue>(Expression<Func<Home, TValue>> selector)
		{
			return PublishedContentModelUtility.GetModelPropertyType(GetModelContentType(), selector);
		}

		///<summary>
		/// Grid
		///</summary>
		[ImplementPropertyType("grid")]
		public Newtonsoft.Json.Linq.JToken Grid
		{
			get { return this.GetPropertyValue<Newtonsoft.Json.Linq.JToken>("grid"); }
		}

		///<summary>
		/// Nc
		///</summary>
		[ImplementPropertyType("nc")]
		public IEnumerable<IPublishedContent> Nc
		{
			get { return this.GetPropertyValue<IEnumerable<IPublishedContent>>("nc"); }
		}

		///<summary>
		/// Page Title
		///</summary>
		[ImplementPropertyType("pageTitle")]
		public string PageTitle
		{
			get { return BaseContent.GetPageTitle(this); }
		}

		///<summary>
		/// Text
		///</summary>
		[ImplementPropertyType("text")]
		public IHtmlString Text
		{
			get { return BaseContent.GetText(this); }
		}

		///<summary>
		/// Description
		///</summary>
		[ImplementPropertyType("description")]
		public string Description
		{
			get { return SEO.GetDescription(this); }
		}

		///<summary>
		/// Keywords
		///</summary>
		[ImplementPropertyType("keywords")]
		public string Keywords
		{
			get { return SEO.GetKeywords(this); }
		}

		///<summary>
		/// Title
		///</summary>
		[ImplementPropertyType("title")]
		public string Title
		{
			get { return SEO.GetTitle(this); }
		}
	}
}
