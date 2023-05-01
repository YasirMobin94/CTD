namespace CTD.Extensions
{
    public static class PortfolioViewsExtensions
    {
        public static string ToPortfolioViewName(this string source)
        {
            return source switch
            {
                "banner-designs" => "_Index",
                //"banner-designs" => "_BannerDesigns",
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
                _ => null
            };
        }
        
    }
}
