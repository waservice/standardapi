using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WA.Standard.IF.Data.v2.HMCIS.Price
{
    [Serializable]
    public class Price
    {
        private string _partscampaigndiscountamount; public string PartsCampaignDiscountAmount { get { return this._partscampaigndiscountamount; } set { this._partscampaigndiscountamount = value; } }
        private string _laborcampaigndiscountamount; public string LaborCampaignDiscountAmount { get { return this._laborcampaigndiscountamount; } set { this._laborcampaigndiscountamount = value; } }
        private string _totalcampaigndiscountamount; public string TotalCampaignDiscountAmount { get { return this._totalcampaigndiscountamount; } set { this._totalcampaigndiscountamount = value; } }
        private string _totalamount; public string TotalAmount { get { return this._totalamount; } set { this._totalamount = value; } }
        private string _vatamount; public string VATAmount { get { return this._vatamount; } set { this._vatamount = value; } }
        private List<OPCode> _opcodes; public List<OPCode> OPCodes { get { return this._opcodes; } set { this._opcodes = value; } }

    }
}
