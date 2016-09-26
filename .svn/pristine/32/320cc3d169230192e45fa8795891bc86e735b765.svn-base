using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace tcpjw3.oa.Code
{
    public class EnumDictiory
    {
    }

    public enum MessageState
    {
        未读 = 1,

        已读 = 2,

        删除 = 4
    }

    /// <summary>
    /// 系统消息和页面推送类型
    /// 100开头表示持票企业收到的消息类型
    /// 200开头表示贴现机构（贴现机构）收到的消息类型
    /// </summary>
    public enum MessageType
    {
        /// <summary>
        /// 该状态针对持票企业
        /// 1. 通知持票企业审核通过，并告知几点开始竞价
        /// 2. 通知持票企业审核不通过
        /// </summary>
        审核通知 = 10001,

        /// <summary>
        /// 该状态针对持票企业
        /// 通知持票企业汇票获得了首次竞价
        /// </summary>
        报价提醒 = 10002,

        /// <summary>
        /// 该状态针对持票企业
        /// 通知持票企业贴现机构已经确认了要约

        确认要约提醒 = 10003,

        /// <summary>
        /// 该状态针对持票企业
        /// 通知持票企业贴现机构已经成功打款并让其查看银行
        /// </summary>
        打款成功提醒 = 10004,

        /// <summary>
        /// 该状态针对持票企业
        /// 提醒持票企业贴现机构已经完成资金解冻操作，交易完成
        /// </summary>
        交易完成提醒 = 10005,

        /// <summary>
        /// 该状态针对贴现机构（贴现机构）
        /// 提醒贴现机构（贴现机构），收到了新的票源推送
        /// </summary>
        票源推送 = 20001,

        /// <summary>
        /// 该状态针对贴现机构（贴现机构）
        /// 提醒贴现机构（持票企业），成功竞价获得要约（该项只针对电票）
        /// </summary>
        竞价成功提醒 = 20002,

        /// <summary>
        /// 该状态针对贴现机构（贴现机构）
        /// 提醒贴现机构（持票企业）之前竞价的汇票没拍着
        /// </summary>
        竞价失败提示 = 20003,

        /// <summary>
        /// 该状态针对贴现机构（贴现机构）
        /// 提醒贴现机构（贴现机构）去签收票，并且解冻资金
        /// </summary>
        背书成功 = 20004
    }


    /// <summary>
    /// 查验状态
    /// </summary>
    public enum ValidState
    {
        /// <summary>
        /// 默认值，票据未查验
        /// </summary>
        未查验 = 1,
        /// <summary>
        /// 经过后台审核，票据已查验
        /// </summary>
        已查验 = 2,
        /// <summary>
        /// 经过后台审核，票据查验不通过
        /// </summary>
        查验不通过 = 4
    }



    public enum TicketType
    {
        银行承兑汇票纸质票 = 1,
        银行承兑汇票电子票 = 2,
        商业承兑汇票纸质票 = 4,
        商业承兑汇票电子票 = 8
    }

    public enum TicketCategory
    {
        大额承兑汇票 = 1,
        小额承兑汇票 = 2
    }

    /// <summary>
    /// 汇票交易状态
    /// </summary>
    public enum TradeState
    {

        /// <summary>
        /// 审核成功之后，汇票所处竞价中状态
        /// </summary>
        竞价中 = 1,

        /// <summary>
        /// 持票企业发起要约， 正在等待贴现机构确认要约
        /// </summary>
        确认要约 = 2,

        /// <summary>
        /// 贴现机构确认要约， 正在向持票企业打款
        /// </summary>
        支付冻结 = 4,

        /// <summary>
        /// 贴现机构打款结束，资金被冻结， 正在等待持票企业背书
        /// </summary>
        持票企业背书 = 8,

        /// <summary>
        /// 持票企业背书完成，正在等待贴现机构签约解冻
        /// </summary>
        签收解冻 = 16,

        /// <summary>
        /// 流程成功，交易已经完成
        /// </summary>
        交易完成 = 32,

        /// <summary>
        /// 流程失败，管理员关闭交易或者用户自主关闭交易
        /// </summary>
        中止交易 = 64,
        /// <summary>
        /// 
        /// </summary>
        预约竞价 = 128,

        /// <summary>
        /// 持票企业发起要约
        /// </summary>
        发起要约 = 256,

        /// <summary>
        /// 所有汇票交易状态
        /// </summary>
        所有状态 = 预约竞价 | 竞价中 | 发起要约 | 确认要约 | 支付冻结 | 持票企业背书 | 签收解冻 | 交易完成 | 中止交易

    }


    /// <summary> 
    /// 审核状态
    /// </summary>
    public enum AuditState
    {
        待审核 = 1,

        审核通过 = 2,

        审核不通过 = 4

    }
}