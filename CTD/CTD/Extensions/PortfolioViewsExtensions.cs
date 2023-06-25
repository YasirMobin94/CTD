namespace CTD.Extensions
{
    public static class PortfolioViewsExtensions
    {
        public static string PortfolioViewName(this string source)
        {
            return source switch
            {
                "banner-designs" => "_BannerDesigns",
                "logo-designs" => "_LogoDesigns",
                "social-media-posts-designs" => "_SocialMediaPostsDesigns",
                "web-designs" => "_WebDesigns",
                "c-maxi-seo-and-google-adwords" => "_CMaxiSEOAndGoogleAdword",
                "seo-for-live-training-lab-2" => "_SEOForLiveTrainingLab",
                "ranking-1-blockchain-business-directory-2" => "_RankingNo1BlockchaiBusinesDirectory",
                "beat-competitors-of-a-1-courier-in-seo-2" => "_BeatCompetitorsOfA1CourierInSEO",
                "suninme-org-seo-work-2" => "_SuninmeOrgSEOWork",
                "seo-for-canadian-institute-of-international-business-2" => "_SEOForCanadianInstituteOfInternationalBusiness",
                "website-mobile-app-development-2" => "_WebsiteAndMobileAppDevelopment",
                "web-development-football365" => "_WebDevelopmentForViewsLiveMatches",
                "web-development-for-stainless-steel-railing-kits" => "_WebDevelopmentForStainlessSteelRailingKits",
                "seo-for-admiral-farragut-academy" => "_SEOForAdmiralFarragutAcademy",
                "seo-for-think-up-themes" => "_SEOForThinkUpThemes",
                "seo-for-eiksmarka" => "_SEOForEiksmarka",
                "seo-for-mgbtechnik" => "_SEOForMGbtechnik",
                _ => null
            };
        }

        public static string BlogViewName(this string source)
        {
            return source switch
            {
                "define-world-best-it-solution" => "_DefineWorldBestITSolutions",
                "why-blogging-is-important-for-sacramento-seo" => "_BloggingIsImportantForSacramentoSEO",
                _ => null
            };
        }

    }
    public static class ServicesViewsExtensions
    {
        public static string ActionName(this string source)
        {
            return source switch
            {
                "ITStaffAugmentation" => "CitywiseITStaffAugumentation",
                "WebDevelopment" => "CitywiseWebDevelopment",
                _ => null
            };
        }
        public static string ServicesViewNameByCity(this string source)
        {
            return source switch
            {
                "aberdeen" => "_ITStaffAugumentationInAberdeen",
                "armagh" => "_ITStaffAugumentationInArmagh",
                "bangor" => "_ITStaffAugumentationInBangor",
                "bath" => "_ITStaffAugumentationInBath",
                "belfast" => "_ITStaffAugumentationInBelfast",
                "birmingham" => "_ITStaffAugumentationInBirmingham",
                "bradford" => "_ITStaffAugumentationInBradford",
                "brighton-and-hove" => "_ITStaffAugumentationInBrighton",
                "bristol" => "_ITStaffAugumentationInBristol",
                "cambridge" => "_ITStaffAugumentationInCambridge",
                "canterbury" => "_ITStaffAugumentationInCanterbury",
                "cardiff" => "_ITStaffAugumentationInCardiff",
                "carlisle" => "_ITStaffAugumentationInCarlisle",
                "chelmsford" => "_ITStaffAugumentationInChelmsford",
                "chester" => "_ITStaffAugumentationInChester",
                "chichester" => "_ITStaffAugumentationInChichester",
                "colchester" => "_ITStaffAugumentationInColchester",
                "coventry" => "_ITStaffAugumentationInCoventry",
                "derby" => "_ITStaffAugumentationInDerby",
                "doncaster" => "_ITStaffAugumentationInDoncaster",
                "dundee" => "_ITStaffAugumentationInDundee",
                "dunfermline" => "_ITStaffAugumentationInDunfermline",
                "durham" => "_ITStaffAugumentationInDurham",
                "edinburgh" => "_ITStaffAugumentationInEdinburgh",
                "ely" => "_ITStaffAugumentationInEly",
                "exeter" => "_ITStaffAugumentationInExeter",
                "glasgow" => "_ITStaffAugumentationInGlasgow",
                "gloucester" => "_ITStaffAugumentationInGloucester",
                "hereford" => "_ITStaffAugumentationInHereford",
                "inverness" => "_ITStaffAugumentationInInverness",
                "kingston-upon-hull" => "_ITStaffAugumentationInKingston",
                "lancaster" => "_ITStaffAugumentationInLancaster",
                "leeds" => "_ITStaffAugumentationInLeeds",
                "lichfield" => "_ITStaffAugumentationInLichfield",
                "lincoln" => "_ITStaffAugumentationInLincoln",
                "lisburn" => "_ITStaffAugumentationInLisburn",
                "liverpool" => "_ITStaffAugumentationInLiverpool",
                "london" => "_ITStaffAugumentationInLondon",
                "londonderry" => "_ITStaffAugumentationInLondonderry",
                "manchester" => "_ITStaffAugumentationInManchester",
                "milton-keynes" => "_ITStaffAugumentationInMiltonKeynes",
                _ => null
            };
        }
    }
}
