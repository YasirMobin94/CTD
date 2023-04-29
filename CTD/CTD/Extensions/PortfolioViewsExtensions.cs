namespace CTD.Extensions
{
    public static class PortfolioViewsExtensions
    {
        public static string ToPortfolioViewName(this string source)
        {
            return source switch
            {
                "app-designs" => "_AppDesigns",
                "banner-designs" => "_BannerDesigns",
                "logo-designs" => "_LogoDesigns",
                "social-media-posts-designs" => "_SocialMediaPostsDesigns",
                "web-designs" => "_WebDesigns",
                "c-maxi-seo-and-google-adwords" => "_CMaxiSEOAndGoogleAdword",
                _ => null
            };
        }
        
    }
}
