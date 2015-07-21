using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WA.Standard.IF.Data.v2.Common.Vehicle
{
    [Serializable]
    public class Campaign
    {
        private string _campaignid = string.Empty; public string CampaignID { get { return this._campaignid; } set { this._campaignid = value; } }
        private string _campaigndescription = string.Empty; public string CampaignDescription { get { return this._campaigndescription; } set { this._campaigndescription = value; } }
        private string _campaignperformed = string.Empty; public string CampaignPerformed { get { return this._campaignperformed; } set { this._campaignperformed = value; } }
    }
}