﻿using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace Maticsoft.Web
{
    public partial class MasterPage : MasterPage
    {
        public string _tabtitle = "";
        public string TabTitle
        {
            get
            {
                return _tabtitle;
            }
            set
            {
                _tabtitle = value;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}
