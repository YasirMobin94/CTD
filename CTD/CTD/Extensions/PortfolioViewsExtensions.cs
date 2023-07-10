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
                "GraphicDesigning" => "CitywiseGraphicDesigning",
                _ => null
            };
        }
        public static string ITStaffServicesViewNameByCity(this string source)
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
        public static string WebDevServicesViewNameByCity(this string source)
        {
            return source switch
            {
                "aberdeen" => "_WebDevelopmentInAberdeen",
                "armagh" => "_WebDevelopmentInArmagh",
                "bangor" => "_WebDevelopmentInBangor",
                "bath" => "_WebDevelopmentInBath",
                "belfast" => "_WebDevelopmentInBelfast",
                "birmingham" => "_WebDevelopmentInBirmingham",
                "bradford" => "_WebDevelopmentInBradford",
                "brighton-and-hove" => "_WebDevelopmentInBrightonAndHove",
                "bristol" => "_WebDevelopmentInBristol",
                "cambridge" => "_WebDevelopmentInCambridge",
                "canterbury" => "_WebDevelopmentInCanterbury",
                "cardiff" => "_WebDevelopmentInCardiff",
                "carlisle" => "_WebDevelopmentInCarlisle",
                "chelmsford" => "_WebDevelopmentInChelmsford",
                "chester" => "_WebDevelopmentInChester",
                "chichester" => "_WebDevelopmentInChichester",
                "colchester" => "_WebDevelopmentInColchester",
                "coventry" => "_WebDevelopmentInCoventry",
                "derby" => "_WebDevelopmentInDerby",
                "doncaster" => "_WebDevelopmentInDoncaster",
                "dundee" => "_WebDevelopmentInDundee",
                "dunfermline" => "_WebDevelopmentInDunfermline",
                "durham" => "_WebDevelopmentInDurham",
                "edinburgh" => "_WebDevelopmentInEdinburgh",
                "ely" => "_WebDevelopmentInEly",
                "exeter" => "_WebDevelopmentInExeter",
                "glasgow" => "_WebDevelopmentInGlasgow",
                "gloucester" => "_WebDevelopmentInGloucester",
                "hereford" => "_WebDevelopmentInHereford",
                "inverness" => "_WebDevelopmentInInverness",
                "kingston-upon-hull" => "_WebDevelopmentInKingstonUponHull",
                "lancaster" => "_WebDevelopmentInLancaster",
                "leeds" => "_WebDevelopmentInLeeds",
                "leicester" => "_WebDevelopmentInLeicester",
                "lichfield" => "_WebDevelopmentInLichfield",
                "lincoln" => "_WebDevelopmentInLincoln",
                "lisburn" => "_WebDevelopmentInLisburn",
                "liverpool" => "_WebDevelopmentInLiverpool",
                "london" => "_WebDevelopmentInLondon",
                "londonderry" => "_WebDevelopmentInLondonderry",
                "manchester" => "_WebDevelopmentInManchester",
                "milton-keynes" => "_WebDevelopmentInMiltonKeynes",
                "newcastle-upon-tyne" => "_WebDevelopmentInNewcastle",
                "newport" => "_WebDevelopmentInNewport",
                "newry" => "_WebDevelopmentInNewry",
                "norwich" => "_WebDevelopmentInNorwich",
                "nottingham" => "_WebDevelopmentInNottingham",
                "oxford" => "_WebDevelopmentInOxford",
                "perth" => "_WebDevelopmentInPerth",
                "peterborough" => "_WebDevelopmentInPeterborough",
                "plymouth" => "_WebDevelopmentInPlymouth",
                "portsmouth" => "_WebDevelopmentInPortsmouth",
                "preston" => "_WebDevelopmentInPreston",
                "ripon" => "_WebDevelopmentInRipon",
                "salford" => "_WebDevelopmentInSalford",
                "salisbury" => "_WebDevelopmentInSalisbury",
                "sheffield" => "_WebDevelopmentInSheffield",
                "southampton" => "_WebDevelopmentInSouthampton",
                "southend-on-sea" => "_WebDevelopmentInSouthendOnSea",
                "st-albans" => "_WebDevelopmentInStAlbans",
                "st-asaph-llanelwy" => "_WebDevelopmentInStAsaph",
                "st-davids" => "_WebDevelopmentInStDavids",
                "stirling" => "_WebDevelopmentInStirling",
                "stoke-on-trent" => "_WebDevelopmentInStokeOnTrent",
                "sunderland" => "_WebDevelopmentInSunderland",
                "swansea" => "_WebDevelopmentInSwansea",
                "truro" => "_WebDevelopmentInTruro",
                "wakefield" => "_WebDevelopmentInWakefield",
                "wells" => "_WebDevelopmentInWells",
                "westminster" => "_WebDevelopmentInWestminster",
                "winchester" => "_WebDevelopmentInWinchester",
                "wolverhampton" => "_WebDevelopmentInWolverhampton",
                "worcester" => "_WebDevelopmentInWorcester",
                "wrexham" => "_WebDevelopmentInWrexham",
                "york" => "_WebDevelopmentInYork",


                //"oxford" => "_WebDevelopmentInOxford",
                //"milton-keynes" => "_WebDevelopmentInMiltonKeynes",
                //"bristol" => "_WebDevelopmentInBristol",


                _ => null
            };
        }
        public static string GraphicDesigningServicesViewNameByCity(this string source)
        {
            return source switch
            {
                "aberdeen" => "_GraphicDesigningInAberdeen",
                "armagh" => "_GraphicDesigningInArmagh",
                "bangor" => "_GraphicDesigningInBangor",
                "bath" => "_GraphicDesigningInBath",
                "belfast" => "_GraphicDesigningInBelfast",
                "birmingham" => "_GraphicDesigningInBirmingham",
                "bradford" => "_GraphicDesigningInBradford",
                "brighton-and-hove" => "_GraphicDesigningInBrightonAndHove",
                "bristol" => "_GraphicDesigningInBristol",
                "cambridge" => "_GraphicDesigningInCambridge",
                "canterbury" => "_GraphicDesigningInCanterbury",
                "cardiff" => "_GraphicDesigningInCardiff",
                "carlisle" => "_GraphicDesigningInCarlisle",
                "chelmsford" => "_GraphicDesigningInChelmsford",
                "chester" => "_GraphicDesigningInChester",
                "chichester" => "_GraphicDesigningInChichester",
                "colchester" => "_GraphicDesigningInColchester",
                "coventry" => "_GraphicDesigningInCoventry",
                "derby" => "_GraphicDesigningInDerby",
                "doncaster" => "_GraphicDesigningInDoncaster",
                "dundee" => "_GraphicDesigningInDundee",
                "dunfermline" => "_GraphicDesigningInDunfermline",
                "durham" => "_GraphicDesigningInDurham",
                "edinburgh" => "_GraphicDesigningInEdinburgh",
                "ely" => "_GraphicDesigningInEly",
                "exeter" => "_GraphicDesigningInExeter",
                "glasgow" => "_GraphicDesigningInGlasgow",
                "gloucester" => "_GraphicDesigningInGloucester",
                "hereford" => "_GraphicDesigningInHereford",
                "inverness" => "_GraphicDesigningInInverness",
                "kingston-upon-hull" => "_GraphicDesigningInKingstonUponHull",
                "lancaster" => "_GraphicDesigningInLancaster",
                "leeds" => "_GraphicDesigningInLeeds",
                "leicester" => "_GraphicDesigningInLeicester",
                "lichfield" => "_GraphicDesigningInLichfield",
                "lincoln" => "_GraphicDesigningInLincoln",
                "lisburn" => "_GraphicDesigningInLisburn",
                "liverpool" => "_GraphicDesigningInLiverpool",
                "london" => "_GraphicDesigningInLondon",
                "londonderry" => "_GraphicDesigningInLondonderry",
                "manchester" => "_GraphicDesigningInManchester",
                "milton-keynes" => "_GraphicDesigningInMiltonKeynes",
                "newcastle-upon-tyne" => "_GraphicDesigningInNewcastle",
                "newport" => "_GraphicDesigningInNewport",
                "newry" => "_GraphicDesigningInNewry",
                "norwich" => "_GraphicDesigningInNorwich",
                "nottingham" => "_GraphicDesigningInNottingham",
                "oxford" => "_GraphicDesigningInOxford",
                "perth" => "_GraphicDesigningInPerth",
                "peterborough" => "_GraphicDesigningInPeterborough",
                "plymouth" => "_GraphicDesigningInPlymouth",
                "portsmouth" => "_GraphicDesigningInPortsmouth",
                "preston" => "_GraphicDesigningInPreston",
                "ripon" => "_GraphicDesigningInRipon",
                "salford" => "_GraphicDesigningInSalford",
                "salisbury" => "_GraphicDesigningInSalisbury",
                "sheffield" => "_GraphicDesigningInSheffield",
                "southampton" => "_GraphicDesigningInSouthampton",
                "southend-on-sea" => "_GraphicDesigningInSouthendOnSea",
                "st-albans" => "_GraphicDesigningInStAlbans",
                "st-asaph-llanelwy" => "_GraphicDesigningInStAsaph",
                "st-davids" => "_GraphicDesigningInStDavids",
                "stirling" => "_GraphicDesigningInStirling",
                "stoke-on-trent" => "_GraphicDesigningInStokeOnTrent",
                "sunderland" => "_GraphicDesigningInSunderland",
                "swansea" => "_GraphicDesigningInSwansea",
                "truro" => "_GraphicDesigningInTruro",
                "wakefield" => "_GraphicDesigningInWakefield",
                "wells" => "_GraphicDesigningInWells",
                "westminster" => "_GraphicDesigningInWestminster",
                "winchester" => "_GraphicDesigningInWinchester",
                "wolverhampton" => "_GraphicDesigningInWolverhampton",
                "worcester" => "_GraphicDesigningInWorcester",
                "wrexham" => "_GraphicDesigningInWrexham",
                "york" => "_GraphicDesigningInYork",

                _ => null
            };
        }
    }
}
