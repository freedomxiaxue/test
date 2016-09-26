namespace tcpjw3.oa.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class tcpjwEntities : DbContext
    {
        public tcpjwEntities()
            : base("name=tcpjwEntities")
        {
        }

        public virtual DbSet<AgentUser> AgentUser { get; set; }
        public virtual DbSet<BAT_CapitalDealInfo> BAT_CapitalDealInfo { get; set; }
        public virtual DbSet<BAT_Captcha> BAT_Captcha { get; set; }
        public virtual DbSet<BAT_CiticForceTransfer> BAT_CiticForceTransfer { get; set; }
        public virtual DbSet<BAT_CITICOrderTransaction> BAT_CITICOrderTransaction { get; set; }
        public virtual DbSet<BAT_CiticPlatformOfGold> BAT_CiticPlatformOfGold { get; set; }
        public virtual DbSet<BAT_EnterpriseOperator> BAT_EnterpriseOperator { get; set; }
        public virtual DbSet<BAT_GoldAccount> BAT_GoldAccount { get; set; }
        public virtual DbSet<BAT_ParValueInfo> BAT_ParValueInfo { get; set; }
        public virtual DbSet<BAT_TradingData> BAT_TradingData { get; set; }
        public virtual DbSet<BAT_TradingRecords> BAT_TradingRecords { get; set; }
        public virtual DbSet<BAT_TradingRequest> BAT_TradingRequest { get; set; }
        public virtual DbSet<BAT_VirtualAccount> BAT_VirtualAccount { get; set; }
        public virtual DbSet<ClientUser> ClientUser { get; set; }
        public virtual DbSet<DiscountBidding> DiscountBidding { get; set; }
        public virtual DbSet<DiscountSheme> DiscountSheme { get; set; }
        public virtual DbSet<Enroll> Enroll { get; set; }
        public virtual DbSet<HolidayLibrary> HolidayLibrary { get; set; }
        public virtual DbSet<Link> Link { get; set; }
        public virtual DbSet<LinkClass> LinkClass { get; set; }
        public virtual DbSet<MachineRecords> MachineRecords { get; set; }
        public virtual DbSet<Message> Message { get; set; }
        public virtual DbSet<NewsList> NewsList { get; set; }
        public virtual DbSet<QuoteStatistic> QuoteStatistic { get; set; }
        public virtual DbSet<SysStatic> SysStatic { get; set; }
        public virtual DbSet<TicketDiscount> TicketDiscount { get; set; }
        public virtual DbSet<TicketHistory> TicketHistory { get; set; }
        public virtual DbSet<TicketImage> TicketImage { get; set; }
        public virtual DbSet<TicketPush> TicketPush { get; set; }
        public virtual DbSet<UserCenter> UserCenter { get; set; }
        public virtual DbSet<UserMap> UserMap { get; set; }
        public virtual DbSet<UserRegistCode> UserRegistCode { get; set; }
        public virtual DbSet<MessagePush> MessagePush { get; set; }
        public virtual DbSet<viewDiscountBidding> viewDiscountBidding { get; set; }
        public virtual DbSet<viewEleTicketDiscount> viewEleTicketDiscount { get; set; }
        public virtual DbSet<viewETicketBiddingPush> viewETicketBiddingPush { get; set; }
        public virtual DbSet<viewMessageGroupped> viewMessageGroupped { get; set; }
        public virtual DbSet<viewMessagePush> viewMessagePush { get; set; }
        public virtual DbSet<viewMyBiddingAgent> viewMyBiddingAgent { get; set; }
        public virtual DbSet<viewMyBiddingReqeust> viewMyBiddingReqeust { get; set; }
        public virtual DbSet<viewOneETicket> viewOneETicket { get; set; }
        public virtual DbSet<viewReturnRsgUserinfo> viewReturnRsgUserinfo { get; set; }
        public virtual DbSet<viewTicketBiddingPush> viewTicketBiddingPush { get; set; }
        public virtual DbSet<viewTicketDiscountAuditOA> viewTicketDiscountAuditOA { get; set; }
        public virtual DbSet<viewTicketDiscountBidding> viewTicketDiscountBidding { get; set; }
        public virtual DbSet<viewTicketDiscountPush> viewTicketDiscountPush { get; set; }
        public virtual DbSet<viewTicketPool> viewTicketPool { get; set; }
        public virtual DbSet<viewUserDetail> viewUserDetail { get; set; }
        public virtual DbSet<viewUserDiscountBidding> viewUserDiscountBidding { get; set; }
        public virtual DbSet<viewUserDiscountQuote> viewUserDiscountQuote { get; set; }
        public virtual DbSet<viewUserListOA> viewUserListOA { get; set; }
        public virtual DbSet<ViewUserMap> ViewUserMap { get; set; }
        public virtual DbSet<viewUserRecords> viewUserRecords { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AgentUser>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<AgentUser>()
                .Property(e => e.Zip)
                .IsUnicode(false);

            modelBuilder.Entity<AgentUser>()
                .Property(e => e.ProvinceID)
                .IsUnicode(false);

            modelBuilder.Entity<AgentUser>()
                .Property(e => e.CityID)
                .IsUnicode(false);

            modelBuilder.Entity<AgentUser>()
                .Property(e => e.AreaID)
                .IsUnicode(false);

            modelBuilder.Entity<AgentUser>()
                .Property(e => e.Telephone)
                .IsUnicode(false);

            modelBuilder.Entity<AgentUser>()
                .Property(e => e.Fax)
                .IsUnicode(false);

            modelBuilder.Entity<AgentUser>()
                .Property(e => e.Phone)
                .IsUnicode(false);

            modelBuilder.Entity<AgentUser>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<AgentUser>()
                .Property(e => e.LastLoginIP)
                .IsUnicode(false);

            modelBuilder.Entity<BAT_Captcha>()
                .Property(e => e.CZZT)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<BAT_CiticForceTransfer>()
                .Property(e => e.Ft_clientid)
                .IsUnicode(false);

            modelBuilder.Entity<BAT_CiticForceTransfer>()
                .Property(e => e.Ft_accountno)
                .IsUnicode(false);

            modelBuilder.Entity<BAT_CiticForceTransfer>()
                .Property(e => e.Ft_payaccno)
                .IsUnicode(false);

            modelBuilder.Entity<BAT_CiticForceTransfer>()
                .Property(e => e.Ft_trantype)
                .IsUnicode(false);

            modelBuilder.Entity<BAT_CiticForceTransfer>()
                .Property(e => e.Ft_recvaccno)
                .IsUnicode(false);

            modelBuilder.Entity<BAT_CiticForceTransfer>()
                .Property(e => e.Ft_recvaccnm)
                .IsUnicode(false);

            modelBuilder.Entity<BAT_CiticForceTransfer>()
                .Property(e => e.Ft_tranamt)
                .HasPrecision(15, 2);

            modelBuilder.Entity<BAT_CiticForceTransfer>()
                .Property(e => e.Ft_freezeno)
                .IsUnicode(false);

            modelBuilder.Entity<BAT_CiticForceTransfer>()
                .Property(e => e.Ft_memo)
                .IsUnicode(false);

            modelBuilder.Entity<BAT_CiticForceTransfer>()
                .Property(e => e.Ft_tranflag)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<BAT_CITICOrderTransaction>()
                .Property(e => e.Version)
                .IsUnicode(false);

            modelBuilder.Entity<BAT_CITICOrderTransaction>()
                .Property(e => e.Bizcode)
                .IsUnicode(false);

            modelBuilder.Entity<BAT_CITICOrderTransaction>()
                .Property(e => e.Mctno)
                .IsUnicode(false);

            modelBuilder.Entity<BAT_CITICOrderTransaction>()
                .Property(e => e.Mctjnlno)
                .IsUnicode(false);

            modelBuilder.Entity<BAT_CITICOrderTransaction>()
                .Property(e => e.Lamagno)
                .IsUnicode(false);

            modelBuilder.Entity<BAT_CITICOrderTransaction>()
                .Property(e => e.Orderno)
                .IsUnicode(false);

            modelBuilder.Entity<BAT_CITICOrderTransaction>()
                .Property(e => e.Bsnno)
                .IsUnicode(false);

            modelBuilder.Entity<BAT_CITICOrderTransaction>()
                .Property(e => e.Payeraccno)
                .IsUnicode(false);

            modelBuilder.Entity<BAT_CITICOrderTransaction>()
                .Property(e => e.Payeeaccno)
                .IsUnicode(false);

            modelBuilder.Entity<BAT_CITICOrderTransaction>()
                .Property(e => e.Orderamt)
                .HasPrecision(15, 2);

            modelBuilder.Entity<BAT_CITICOrderTransaction>()
                .Property(e => e.Tranamt)
                .HasPrecision(15, 2);

            modelBuilder.Entity<BAT_CITICOrderTransaction>()
                .Property(e => e.Loanamt)
                .HasPrecision(15, 2);

            modelBuilder.Entity<BAT_CITICOrderTransaction>()
                .Property(e => e.Crycode)
                .IsUnicode(false);

            modelBuilder.Entity<BAT_CITICOrderTransaction>()
                .Property(e => e.Resume)
                .IsUnicode(false);

            modelBuilder.Entity<BAT_CITICOrderTransaction>()
                .Property(e => e.Purpose)
                .IsUnicode(false);

            modelBuilder.Entity<BAT_CITICOrderTransaction>()
                .Property(e => e.Ordertime)
                .IsUnicode(false);

            modelBuilder.Entity<BAT_CITICOrderTransaction>()
                .Property(e => e.Stfreezeno)
                .IsUnicode(false);

            modelBuilder.Entity<BAT_CITICOrderTransaction>()
                .Property(e => e.Ctrtno)
                .IsUnicode(false);

            modelBuilder.Entity<BAT_CITICOrderTransaction>()
                .Property(e => e.Dlvorderno)
                .IsUnicode(false);

            modelBuilder.Entity<BAT_CITICOrderTransaction>()
                .Property(e => e.Dlvodrtime)
                .IsUnicode(false);

            modelBuilder.Entity<BAT_CITICOrderTransaction>()
                .Property(e => e.Dlvctrtno)
                .IsUnicode(false);

            modelBuilder.Entity<BAT_CITICOrderTransaction>()
                .Property(e => e.Dlvername)
                .IsUnicode(false);

            modelBuilder.Entity<BAT_CITICOrderTransaction>()
                .Property(e => e.Dlvfee)
                .HasPrecision(15, 2);

            modelBuilder.Entity<BAT_CITICOrderTransaction>()
                .Property(e => e.Stockno)
                .IsUnicode(false);

            modelBuilder.Entity<BAT_CITICOrderTransaction>()
                .Property(e => e.Startdate)
                .IsUnicode(false);

            modelBuilder.Entity<BAT_CITICOrderTransaction>()
                .Property(e => e.Enddate)
                .IsUnicode(false);

            modelBuilder.Entity<BAT_CITICOrderTransaction>()
                .Property(e => e.Totalamt)
                .HasPrecision(15, 2);

            modelBuilder.Entity<BAT_CITICOrderTransaction>()
                .Property(e => e.Warehousecode)
                .IsUnicode(false);

            modelBuilder.Entity<BAT_CITICOrderTransaction>()
                .Property(e => e.Warehousenm)
                .IsUnicode(false);

            modelBuilder.Entity<BAT_CITICOrderTransaction>()
                .Property(e => e.Productcode)
                .IsUnicode(false);

            modelBuilder.Entity<BAT_CITICOrderTransaction>()
                .Property(e => e.Productnm)
                .IsUnicode(false);

            modelBuilder.Entity<BAT_CITICOrderTransaction>()
                .Property(e => e.Unit)
                .IsUnicode(false);

            modelBuilder.Entity<BAT_CITICOrderTransaction>()
                .Property(e => e.Dealunitprt)
                .HasPrecision(15, 2);

            modelBuilder.Entity<BAT_CITICOrderTransaction>()
                .Property(e => e.Whpos)
                .IsUnicode(false);

            modelBuilder.Entity<BAT_CITICOrderTransaction>()
                .Property(e => e.R_stt)
                .IsUnicode(false);

            modelBuilder.Entity<BAT_CITICOrderTransaction>()
                .Property(e => e.R_rstcode)
                .IsUnicode(false);

            modelBuilder.Entity<BAT_CITICOrderTransaction>()
                .Property(e => e.Freezeno)
                .IsUnicode(false);

            modelBuilder.Entity<BAT_CiticPlatformOfGold>()
                .Property(e => e.Pf_clientid)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<BAT_CiticPlatformOfGold>()
                .Property(e => e.Pf_accountno)
                .IsUnicode(false);

            modelBuilder.Entity<BAT_CiticPlatformOfGold>()
                .Property(e => e.Pf_recvaccno)
                .IsUnicode(false);

            modelBuilder.Entity<BAT_CiticPlatformOfGold>()
                .Property(e => e.Pf_recvaccnm)
                .IsUnicode(false);

            modelBuilder.Entity<BAT_CiticPlatformOfGold>()
                .Property(e => e.Pf_tranamt)
                .HasPrecision(15, 2);

            modelBuilder.Entity<BAT_CiticPlatformOfGold>()
                .Property(e => e.Pf_samebank)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<BAT_CiticPlatformOfGold>()
                .Property(e => e.Pf_recvtgfi)
                .IsUnicode(false);

            modelBuilder.Entity<BAT_CiticPlatformOfGold>()
                .Property(e => e.Pf_recvbanknm)
                .IsUnicode(false);

            modelBuilder.Entity<BAT_CiticPlatformOfGold>()
                .Property(e => e.Pf_memo)
                .IsUnicode(false);

            modelBuilder.Entity<BAT_CiticPlatformOfGold>()
                .Property(e => e.Pf_preflg)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<BAT_CiticPlatformOfGold>()
                .Property(e => e.Pf_predate)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<BAT_CiticPlatformOfGold>()
                .Property(e => e.Pf_pretime)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<BAT_EnterpriseOperator>()
                .Property(e => e.SFQY)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<BAT_ParValueInfo>()
                .Property(e => e.PMJE)
                .HasPrecision(20, 8);

            modelBuilder.Entity<BAT_ParValueInfo>()
                .Property(e => e.CJYLL)
                .HasPrecision(20, 8);

            modelBuilder.Entity<BAT_ParValueInfo>()
                .Property(e => e.CJMSWJG)
                .HasPrecision(20, 8);

            modelBuilder.Entity<BAT_ParValueInfo>()
                .Property(e => e.CJJG)
                .HasPrecision(20, 8);

            modelBuilder.Entity<BAT_TradingData>()
                .Property(e => e.CountM)
                .HasPrecision(20, 8);

            modelBuilder.Entity<BAT_TradingData>()
                .Property(e => e.YesDayCountM)
                .HasPrecision(20, 8);

            modelBuilder.Entity<BAT_TradingRecords>()
                .Property(e => e.ZXZT)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<BAT_TradingRequest>()
                .Property(e => e.JYSHZT)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<BAT_TradingRequest>()
                .Property(e => e.JYZT)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<BAT_TradingRequest>()
                .Property(e => e.BSBH)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<BAT_VirtualAccount>()
                .Property(e => e.JS)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<BAT_VirtualAccount>()
                .Property(e => e.SHJD)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ClientUser>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<ClientUser>()
                .Property(e => e.FullName)
                .IsUnicode(false);

            modelBuilder.Entity<ClientUser>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<ClientUser>()
                .Property(e => e.Avatar)
                .IsUnicode(false);

            modelBuilder.Entity<ClientUser>()
                .Property(e => e.ProvinceID)
                .IsUnicode(false);

            modelBuilder.Entity<ClientUser>()
                .Property(e => e.CityID)
                .IsUnicode(false);

            modelBuilder.Entity<ClientUser>()
                .Property(e => e.DistrictID)
                .IsUnicode(false);

            modelBuilder.Entity<ClientUser>()
                .Property(e => e.Telephone)
                .IsUnicode(false);

            modelBuilder.Entity<ClientUser>()
                .Property(e => e.QQOfPIC)
                .IsUnicode(false);

            modelBuilder.Entity<ClientUser>()
                .Property(e => e.Zip)
                .IsUnicode(false);

            modelBuilder.Entity<ClientUser>()
                .Property(e => e.Fax)
                .IsUnicode(false);

            modelBuilder.Entity<DiscountBidding>()
                .Property(e => e.BidPrice)
                .HasPrecision(20, 10);

            modelBuilder.Entity<DiscountBidding>()
                .Property(e => e.BidRate)
                .HasPrecision(20, 10);

            modelBuilder.Entity<DiscountBidding>()
                .Property(e => e.TotalPrice)
                .HasPrecision(20, 10);

            modelBuilder.Entity<DiscountSheme>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<DiscountSheme>()
                .Property(e => e.D_Phone)
                .IsUnicode(false);

            modelBuilder.Entity<DiscountSheme>()
                .Property(e => e.D_Bill)
                .HasPrecision(20, 10);

            modelBuilder.Entity<DiscountSheme>()
                .Property(e => e.ProvinceValue)
                .IsUnicode(false);

            modelBuilder.Entity<DiscountSheme>()
                .Property(e => e.CityValue)
                .IsUnicode(false);

            modelBuilder.Entity<Enroll>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Enroll>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Enroll>()
                .Property(e => e.Company)
                .IsUnicode(false);

            modelBuilder.Entity<Enroll>()
                .Property(e => e.Department)
                .IsUnicode(false);

            modelBuilder.Entity<Enroll>()
                .Property(e => e.Phone)
                .IsUnicode(false);

            modelBuilder.Entity<HolidayLibrary>()
                .Property(e => e.HolidayName)
                .IsUnicode(false);

            modelBuilder.Entity<Link>()
                .Property(e => e.LinkName)
                .IsUnicode(false);

            modelBuilder.Entity<Link>()
                .Property(e => e.LinkUrl)
                .IsUnicode(false);

            modelBuilder.Entity<Link>()
                .Property(e => e.LinkImg)
                .IsUnicode(false);

            modelBuilder.Entity<Link>()
                .Property(e => e.ProvinceID)
                .IsUnicode(false);

            modelBuilder.Entity<Link>()
                .Property(e => e.CityID)
                .IsUnicode(false);

            modelBuilder.Entity<Link>()
                .Property(e => e.AddUserName)
                .IsUnicode(false);

            modelBuilder.Entity<Message>()
                .Property(e => e.MsgTitle)
                .IsUnicode(false);

            modelBuilder.Entity<Message>()
                .Property(e => e.MsgContent)
                .IsUnicode(false);

            modelBuilder.Entity<NewsList>()
                .Property(e => e.Nclassid)
                .IsUnicode(false);

            modelBuilder.Entity<NewsList>()
                .Property(e => e.Classname)
                .IsUnicode(false);

            modelBuilder.Entity<NewsList>()
                .Property(e => e.Title)
                .IsUnicode(false);

            modelBuilder.Entity<NewsList>()
                .Property(e => e.Seo_title)
                .IsUnicode(false);

            modelBuilder.Entity<NewsList>()
                .Property(e => e.Seo_keywords)
                .IsUnicode(false);

            modelBuilder.Entity<NewsList>()
                .Property(e => e.Seo_desciption)
                .IsUnicode(false);

            modelBuilder.Entity<NewsList>()
                .Property(e => e.Fromnew)
                .IsUnicode(false);

            modelBuilder.Entity<NewsList>()
                .Property(e => e.Content)
                .IsUnicode(false);

            modelBuilder.Entity<NewsList>()
                .Property(e => e.Editor)
                .IsUnicode(false);

            modelBuilder.Entity<NewsList>()
                .Property(e => e.Publisher)
                .IsUnicode(false);

            modelBuilder.Entity<NewsList>()
                .Property(e => e.Auditor)
                .IsUnicode(false);

            modelBuilder.Entity<NewsList>()
                .Property(e => e.Spare1)
                .IsUnicode(false);

            modelBuilder.Entity<NewsList>()
                .Property(e => e.Spare2)
                .IsUnicode(false);

            modelBuilder.Entity<NewsList>()
                .Property(e => e.Spare3)
                .IsUnicode(false);

            modelBuilder.Entity<NewsList>()
                .Property(e => e.Spare4)
                .IsUnicode(false);

            modelBuilder.Entity<NewsList>()
                .Property(e => e.Spare5)
                .IsUnicode(false);

            modelBuilder.Entity<SysStatic>()
                .Property(e => e.Text)
                .IsUnicode(false);

            modelBuilder.Entity<SysStatic>()
                .Property(e => e.Value)
                .IsUnicode(false);

            modelBuilder.Entity<SysStatic>()
                .Property(e => e.Note)
                .IsUnicode(false);

            modelBuilder.Entity<TicketDiscount>()
                .Property(e => e.TicketPrice)
                .HasPrecision(20, 10);

            modelBuilder.Entity<TicketDiscount>()
                .Property(e => e.TicketFaceImg)
                .IsUnicode(false);

            modelBuilder.Entity<TicketDiscount>()
                .Property(e => e.TicketBackImg)
                .IsUnicode(false);

            modelBuilder.Entity<TicketDiscount>()
                .Property(e => e.ProvinceID)
                .IsUnicode(false);

            modelBuilder.Entity<TicketDiscount>()
                .Property(e => e.CityID)
                .IsUnicode(false);

            modelBuilder.Entity<TicketDiscount>()
                .Property(e => e.UserNote)
                .IsUnicode(false);

            modelBuilder.Entity<TicketDiscount>()
                .Property(e => e.BidPrice)
                .HasPrecision(20, 10);

            modelBuilder.Entity<TicketDiscount>()
                .Property(e => e.ToAccount)
                .IsUnicode(false);

            modelBuilder.Entity<TicketImage>()
                .Property(e => e.OriginImg)
                .IsUnicode(false);

            modelBuilder.Entity<TicketImage>()
                .Property(e => e.Image)
                .IsUnicode(false);

            modelBuilder.Entity<TicketImage>()
                .Property(e => e.ThumbImg)
                .IsUnicode(false);

            modelBuilder.Entity<TicketPush>()
                .Property(e => e.TicketPrice)
                .HasPrecision(18, 0);

            modelBuilder.Entity<TicketPush>()
                .Property(e => e.ProvinceID)
                .IsUnicode(false);

            modelBuilder.Entity<TicketPush>()
                .Property(e => e.CityID)
                .IsUnicode(false);

            modelBuilder.Entity<UserCenter>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<UserCenter>()
                .Property(e => e.Phone)
                .IsUnicode(false);

            modelBuilder.Entity<UserCenter>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<UserCenter>()
                .Property(e => e.RegisterIP)
                .IsUnicode(false);

            modelBuilder.Entity<UserCenter>()
                .Property(e => e.LastLoginIP)
                .IsUnicode(false);

            modelBuilder.Entity<UserRegistCode>()
                .Property(e => e.PhoneNumber)
                .IsUnicode(false);

            modelBuilder.Entity<UserRegistCode>()
                .Property(e => e.Code)
                .IsUnicode(false);

            modelBuilder.Entity<viewDiscountBidding>()
                .Property(e => e.BidPrice)
                .HasPrecision(20, 10);

            modelBuilder.Entity<viewDiscountBidding>()
                .Property(e => e.BidRate)
                .HasPrecision(20, 10);

            modelBuilder.Entity<viewDiscountBidding>()
                .Property(e => e.Phone)
                .IsUnicode(false);

            modelBuilder.Entity<viewDiscountBidding>()
                .Property(e => e.ProvinceID)
                .IsUnicode(false);

            modelBuilder.Entity<viewDiscountBidding>()
                .Property(e => e.CityID)
                .IsUnicode(false);

            modelBuilder.Entity<viewDiscountBidding>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<viewEleTicketDiscount>()
                .Property(e => e.TicketPrice)
                .HasPrecision(20, 10);

            modelBuilder.Entity<viewEleTicketDiscount>()
                .Property(e => e.ProvinceID)
                .IsUnicode(false);

            modelBuilder.Entity<viewEleTicketDiscount>()
                .Property(e => e.CityID)
                .IsUnicode(false);

            modelBuilder.Entity<viewEleTicketDiscount>()
                .Property(e => e.BidPrice)
                .HasPrecision(20, 10);

            modelBuilder.Entity<viewETicketBiddingPush>()
                .Property(e => e.TicketPrice)
                .HasPrecision(20, 10);

            modelBuilder.Entity<viewETicketBiddingPush>()
                .Property(e => e.ProvinceID)
                .IsUnicode(false);

            modelBuilder.Entity<viewETicketBiddingPush>()
                .Property(e => e.CityID)
                .IsUnicode(false);

            modelBuilder.Entity<viewETicketBiddingPush>()
                .Property(e => e.TicketFaceImg)
                .IsUnicode(false);

            modelBuilder.Entity<viewETicketBiddingPush>()
                .Property(e => e.TicketBackImg)
                .IsUnicode(false);

            modelBuilder.Entity<viewETicketBiddingPush>()
                .Property(e => e.MaxRate)
                .HasPrecision(20, 10);

            modelBuilder.Entity<viewETicketBiddingPush>()
                .Property(e => e.MaxPrice)
                .HasPrecision(20, 10);

            modelBuilder.Entity<viewMessageGroupped>()
                .Property(e => e.TicketPrice)
                .HasPrecision(20, 10);

            modelBuilder.Entity<viewMessageGroupped>()
                .Property(e => e.MsgTitle)
                .IsUnicode(false);

            modelBuilder.Entity<viewMessageGroupped>()
                .Property(e => e.MsgContent)
                .IsUnicode(false);

            modelBuilder.Entity<viewMyBiddingAgent>()
                .Property(e => e.Price)
                .HasPrecision(20, 10);

            modelBuilder.Entity<viewMyBiddingAgent>()
                .Property(e => e.BidUserPhone)
                .IsUnicode(false);

            modelBuilder.Entity<viewMyBiddingReqeust>()
                .Property(e => e.TicketPrice)
                .HasPrecision(20, 10);

            modelBuilder.Entity<viewMyBiddingReqeust>()
                .Property(e => e.ProvinceID)
                .IsUnicode(false);

            modelBuilder.Entity<viewMyBiddingReqeust>()
                .Property(e => e.CityID)
                .IsUnicode(false);

            modelBuilder.Entity<viewMyBiddingReqeust>()
                .Property(e => e.BidPrice)
                .HasPrecision(20, 10);

            modelBuilder.Entity<viewMyBiddingReqeust>()
                .Property(e => e.BidRate)
                .HasPrecision(20, 10);

            modelBuilder.Entity<viewOneETicket>()
                .Property(e => e.TicketPrice)
                .HasPrecision(20, 10);

            modelBuilder.Entity<viewOneETicket>()
                .Property(e => e.ProvinceID)
                .IsUnicode(false);

            modelBuilder.Entity<viewOneETicket>()
                .Property(e => e.CityID)
                .IsUnicode(false);

            modelBuilder.Entity<viewOneETicket>()
                .Property(e => e.TicketFaceImg)
                .IsUnicode(false);

            modelBuilder.Entity<viewOneETicket>()
                .Property(e => e.TicketBackImg)
                .IsUnicode(false);

            modelBuilder.Entity<viewOneETicket>()
                .Property(e => e.BidPrice)
                .HasPrecision(20, 10);

            modelBuilder.Entity<viewOneETicket>()
                .Property(e => e.BidRate)
                .HasPrecision(20, 10);

            modelBuilder.Entity<viewOneETicket>()
                .Property(e => e.mswPrice)
                .HasPrecision(20, 10);

            modelBuilder.Entity<viewReturnRsgUserinfo>()
                .Property(e => e.Phone)
                .IsUnicode(false);

            modelBuilder.Entity<viewReturnRsgUserinfo>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<viewReturnRsgUserinfo>()
                .Property(e => e.SName)
                .IsUnicode(false);

            modelBuilder.Entity<viewReturnRsgUserinfo>()
                .Property(e => e.FName)
                .IsUnicode(false);

            modelBuilder.Entity<viewReturnRsgUserinfo>()
                .Property(e => e.Avatar)
                .IsUnicode(false);

            modelBuilder.Entity<viewReturnRsgUserinfo>()
                .Property(e => e.CityID)
                .IsUnicode(false);

            modelBuilder.Entity<viewReturnRsgUserinfo>()
                .Property(e => e.Zip)
                .IsUnicode(false);

            modelBuilder.Entity<viewReturnRsgUserinfo>()
                .Property(e => e.ProvinceID)
                .IsUnicode(false);

            modelBuilder.Entity<viewTicketBiddingPush>()
                .Property(e => e.TicketPrice)
                .HasPrecision(20, 10);

            modelBuilder.Entity<viewTicketBiddingPush>()
                .Property(e => e.ProvinceID)
                .IsUnicode(false);

            modelBuilder.Entity<viewTicketBiddingPush>()
                .Property(e => e.CityID)
                .IsUnicode(false);

            modelBuilder.Entity<viewTicketBiddingPush>()
                .Property(e => e.TicketFaceImg)
                .IsUnicode(false);

            modelBuilder.Entity<viewTicketBiddingPush>()
                .Property(e => e.TicketBackImg)
                .IsUnicode(false);

            modelBuilder.Entity<viewTicketBiddingPush>()
                .Property(e => e.MaxRate)
                .HasPrecision(20, 10);

            modelBuilder.Entity<viewTicketBiddingPush>()
                .Property(e => e.MaxPrice)
                .HasPrecision(20, 10);

            modelBuilder.Entity<viewTicketDiscountAuditOA>()
                .Property(e => e.TicketPrice)
                .HasPrecision(20, 10);

            modelBuilder.Entity<viewTicketDiscountAuditOA>()
                .Property(e => e.TicketFaceImg)
                .IsUnicode(false);

            modelBuilder.Entity<viewTicketDiscountAuditOA>()
                .Property(e => e.TicketBackImg)
                .IsUnicode(false);

            modelBuilder.Entity<viewTicketDiscountAuditOA>()
                .Property(e => e.ProvinceID)
                .IsUnicode(false);

            modelBuilder.Entity<viewTicketDiscountAuditOA>()
                .Property(e => e.CityID)
                .IsUnicode(false);

            modelBuilder.Entity<viewTicketDiscountAuditOA>()
                .Property(e => e.UserNote)
                .IsUnicode(false);

            modelBuilder.Entity<viewTicketDiscountAuditOA>()
                .Property(e => e.BidPrice)
                .HasPrecision(20, 10);

            modelBuilder.Entity<viewTicketDiscountAuditOA>()
                .Property(e => e.Phone)
                .IsUnicode(false);

            modelBuilder.Entity<viewTicketDiscountBidding>()
                .Property(e => e.TicketPrice)
                .HasPrecision(20, 10);

            modelBuilder.Entity<viewTicketDiscountBidding>()
                .Property(e => e.CityID)
                .IsUnicode(false);

            modelBuilder.Entity<viewTicketDiscountBidding>()
                .Property(e => e.ProvinceID)
                .IsUnicode(false);

            modelBuilder.Entity<viewTicketDiscountBidding>()
                .Property(e => e.BidPrice)
                .HasPrecision(20, 10);

            modelBuilder.Entity<viewTicketDiscountBidding>()
                .Property(e => e.TotalPrice)
                .HasPrecision(20, 10);

            modelBuilder.Entity<viewTicketDiscountPush>()
                .Property(e => e.TicketPrice)
                .HasPrecision(18, 0);

            modelBuilder.Entity<viewTicketDiscountPush>()
                .Property(e => e.ProvinceID)
                .IsUnicode(false);

            modelBuilder.Entity<viewTicketDiscountPush>()
                .Property(e => e.CityID)
                .IsUnicode(false);

            modelBuilder.Entity<viewTicketPool>()
                .Property(e => e.TicketPrice)
                .HasPrecision(20, 10);

            modelBuilder.Entity<viewTicketPool>()
                .Property(e => e.TicketFaceImg)
                .IsUnicode(false);

            modelBuilder.Entity<viewTicketPool>()
                .Property(e => e.TicketBackImg)
                .IsUnicode(false);

            modelBuilder.Entity<viewTicketPool>()
                .Property(e => e.ProvinceID)
                .IsUnicode(false);

            modelBuilder.Entity<viewTicketPool>()
                .Property(e => e.CityID)
                .IsUnicode(false);

            modelBuilder.Entity<viewTicketPool>()
                .Property(e => e.UserNote)
                .IsUnicode(false);

            modelBuilder.Entity<viewTicketPool>()
                .Property(e => e.BidPrice)
                .HasPrecision(20, 10);

            modelBuilder.Entity<viewUserDetail>()
                .Property(e => e.Phone)
                .IsUnicode(false);

            modelBuilder.Entity<viewUserDetail>()
                .Property(e => e.ProvinceID)
                .IsUnicode(false);

            modelBuilder.Entity<viewUserDetail>()
                .Property(e => e.CityID)
                .IsUnicode(false);

            modelBuilder.Entity<viewUserDetail>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<viewUserDetail>()
                .Property(e => e.FullName)
                .IsUnicode(false);

            modelBuilder.Entity<viewUserDiscountBidding>()
                .Property(e => e.TicketPrice)
                .HasPrecision(20, 10);

            modelBuilder.Entity<viewUserDiscountBidding>()
                .Property(e => e.ProvinceID)
                .IsUnicode(false);

            modelBuilder.Entity<viewUserDiscountBidding>()
                .Property(e => e.CityID)
                .IsUnicode(false);

            modelBuilder.Entity<viewUserDiscountBidding>()
                .Property(e => e.TicketFaceImg)
                .IsUnicode(false);

            modelBuilder.Entity<viewUserDiscountBidding>()
                .Property(e => e.TicketBackImg)
                .IsUnicode(false);

            modelBuilder.Entity<viewUserDiscountBidding>()
                .Property(e => e.UserNote)
                .IsUnicode(false);

            modelBuilder.Entity<viewUserDiscountBidding>()
                .Property(e => e.MaxRate)
                .HasPrecision(20, 10);

            modelBuilder.Entity<viewUserDiscountBidding>()
                .Property(e => e.MaxPrice)
                .HasPrecision(20, 10);

            modelBuilder.Entity<viewUserDiscountQuote>()
                .Property(e => e.TicketPrice)
                .HasPrecision(20, 10);

            modelBuilder.Entity<viewUserDiscountQuote>()
                .Property(e => e.BidUserName)
                .IsUnicode(false);

            modelBuilder.Entity<viewUserDiscountQuote>()
                .Property(e => e.BidPrice)
                .HasPrecision(20, 10);

            modelBuilder.Entity<viewUserDiscountQuote>()
                .Property(e => e.BidUserPhone)
                .IsUnicode(false);

            modelBuilder.Entity<viewUserDiscountQuote>()
                .Property(e => e.BidRate)
                .HasPrecision(20, 10);

            modelBuilder.Entity<viewUserListOA>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<viewUserListOA>()
                .Property(e => e.FullName)
                .IsUnicode(false);

            modelBuilder.Entity<viewUserListOA>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<viewUserListOA>()
                .Property(e => e.Avatar)
                .IsUnicode(false);

            modelBuilder.Entity<viewUserListOA>()
                .Property(e => e.ProvinceID)
                .IsUnicode(false);

            modelBuilder.Entity<viewUserListOA>()
                .Property(e => e.CityID)
                .IsUnicode(false);

            modelBuilder.Entity<viewUserListOA>()
                .Property(e => e.DistrictID)
                .IsUnicode(false);

            modelBuilder.Entity<viewUserListOA>()
                .Property(e => e.Telephone)
                .IsUnicode(false);

            modelBuilder.Entity<viewUserListOA>()
                .Property(e => e.QQOfPIC)
                .IsUnicode(false);

            modelBuilder.Entity<viewUserListOA>()
                .Property(e => e.Zip)
                .IsUnicode(false);

            modelBuilder.Entity<viewUserListOA>()
                .Property(e => e.Fax)
                .IsUnicode(false);

            modelBuilder.Entity<viewUserListOA>()
                .Property(e => e.Phone)
                .IsUnicode(false);

            modelBuilder.Entity<viewUserListOA>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<ViewUserMap>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<viewUserRecords>()
                .Property(e => e.FullName)
                .IsUnicode(false);

            modelBuilder.Entity<viewUserRecords>()
                .Property(e => e.ProvinceID)
                .IsUnicode(false);

            modelBuilder.Entity<viewUserRecords>()
                .Property(e => e.CityID)
                .IsUnicode(false);

            modelBuilder.Entity<viewUserRecords>()
                .Property(e => e.DistrictID)
                .IsUnicode(false);

            modelBuilder.Entity<viewUserRecords>()
                .Property(e => e.Phone)
                .IsUnicode(false);
        }
    }
}
