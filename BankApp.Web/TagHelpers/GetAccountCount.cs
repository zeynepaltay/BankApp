﻿using BankApp.Web.Data.Context;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Diagnostics;
using System.Linq;

namespace BankApp.Web.TagHelpers
{
	[HtmlTargetElement("getAccountCount")]
	public class GetAccountCount:TagHelper
	{
        public int ApplicationUserId { get; set; }
        private readonly BankContext _context;
        public GetAccountCount(BankContext context)
        {
			_context = context;
        }
     
		public override void Process(TagHelperContext contex, TagHelperOutput output )
		{
			var accountCount = _context.Accounts.Count(x=>x.ApplicationUserId==ApplicationUserId);
			var html =$"<span class='badge bg-danger'> {accountCount}</span>";
			output.Content.SetHtmlContent(html);
		}
	}
}
