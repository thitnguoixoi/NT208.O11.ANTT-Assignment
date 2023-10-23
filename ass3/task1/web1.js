document.addEventListener("DOMContentLoaded", function() 
{
    var viewMoreText = document.querySelector(".show-more1");
    var moreText = document.querySelector(".more-text1");
    moreText.style.display = "none";

    viewMoreText.addEventListener("click", function(e) 
    {
        e.preventDefault();
        if (moreText.style.display === "none") {
            moreText.style.display = "block";
            viewMoreText.textContent = "View less >";
        } else 
        {
            moreText.style.display = "none";
            viewMoreText.textContent = "View more >";
        }
    });
});
document.addEventListener("DOMContentLoaded", function() 
{
    var viewMoreText = document.querySelector(".show-more2");
    var moreText = document.querySelector(".more-text2");
    moreText.style.display = "none";

    viewMoreText.addEventListener("click", function(e) 
    {
        e.preventDefault();
        if (moreText.style.display === "none") {
            moreText.style.display = "block";
            viewMoreText.textContent = "View less >";
        } else 
        {
            moreText.style.display = "none";
            viewMoreText.textContent = "View more >";
        }
    });
});