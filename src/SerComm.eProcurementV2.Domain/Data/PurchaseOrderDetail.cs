using System;

using Volo.Abp.Domain.Entities;

namespace SerComm.eProcurementV2.Data
{
    /// <summary>
    /// 採購單明細檔
    /// </summary>
    public class PurchaseOrderDetail : Entity<int>
    {
        public string mt_list { get; set; }
        public string el_no { get; set; }
        public string vender_no { get; set; }
        public string vender_name { get; set; }
        public string ch_sort_no { get; set; }
        public string ch_sort_name { get; set; }
        public DateTime? reply_date { get; set; }
        public string remark { get; set; }
        public string factory_no { get; set; }
        public string epr_status { get; set; }
        public string arn_type { get; set; }
        public string asn_no { get; set; }
        public decimal? asn_qty { get; set; }
        public string asn_code { get; set; }
        public DateTime? code_time { get; set; }
        public string code_user { get; set; }
        public string erp_code { get; set; }
        public string code_mark { get; set; }
        public string po_no { get; set; }
        public string arn_app_no { get; set; }
        public string asn_cancel { get; set; }
        public string corp_no { get; set; }
        public string ch_acqty { get; set; }
        public decimal? ch_caqty { get; set; }
        public string asn_sure { get; set; }
        public decimal? el_min { get; set; }
        public decimal? el_eoq { get; set; }
        public decimal? asn_acqty { get; set; }
        public string el_abc { get; set; }
        public DateTime? oper_time { get; set; }
        public string version_no { get; set; }
        public decimal? org_asn_qty { get; set; }
        public DateTime? org_reply_date { get; set; }
        public string split_uid { get; set; }
        public string invoice_no { get; set; }
        public string plant { get; set; }   
        public string commit_qty { get; set; }
        public string shipping_qty { get; set; } 
        public string etd { get; set; }
        public string ep_number { get; set; }
        public string delivery_date { get; set; }
        public string shipper { get; set; }
        public string ship_to { get; set; }
        public string bill_to { get; set; }
        public string port_loading { get; set; }
        public string port_delivery { get; set; }
        public string bill_no { get; set; }
        public string ship_term { get; set; }
    }
}
