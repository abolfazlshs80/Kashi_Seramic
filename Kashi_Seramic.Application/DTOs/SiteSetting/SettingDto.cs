using Pr_Signal_ir.Application.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kashi_Seramic.Application.DTOs.SiteSetting
{
    public class SiteSettingDto : BaseDto
    {
        public string DeveloperLinkName { get; set; }
        public string? AboutText { get; set; }
        public bool IsTopProductManinPage { get; set; }
        public bool IsLastProductManinPage { get; set; }
        public bool IsKashiManinPage { get; set; }
        public bool IsSlider { get; set; }
        public bool IsBlog { get; set; }
        public string MapCode { get; set; }
        public string Title { get; set; }
        public string Desc { get; set; }
        public string FotterDesc { get; set; }
        public string TitleDesc { get; set; }
        public string DeveloperName { get; set; }
        public string OwnerName { get; set; }
        public string AddressCompany { get; set; }
        public string TelegramChannle { get; set; }
        public string TelegramNumber { get; set; }
        public string WhatappNumber { get; set; }
        public string InstagramUserName { get; set; }
        public string Gmail { get; set; }
        public string GmailPassword { get; set; }
        public string SitePath { get; set; }
        public string? LogoPath { get; set; }
        public string? Phone1 { get; set; }
        public string? Phone2 { get; set; }
    }
}
