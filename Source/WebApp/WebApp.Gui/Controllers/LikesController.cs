using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Core.Application;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApp.Gui.Middlewares;

namespace WebApp.Gui.Controllers
{
  public class LikesController : Controller
  {
    private readonly ILikeService _iLikeService;
    private readonly ValidateUserSession _validateUserSession;

    public LikesController(ILikeService iLikeService, ValidateUserSession validateUserSession)
    {
      _iLikeService = iLikeService;
      _validateUserSession = validateUserSession;
    }
    
    public async Task<IActionResult> Like(int? postId, int? commentId)
    {
      if (!_validateUserSession.HasUser())
      {
        return RedirectToRoute(new { controller = "Login", action = "Index"});
      }
      
      // almaceno la url de la vista en la que se encontraba el usuario antes de llegar aqui.
      var returnUrl = Request.Headers["Referer"].ToString();
      
      SaveLikeViewModel saveLikeViewModel = new SaveLikeViewModel();

      //if we send the user here it means is a like
      //lets set the isLike to true
      saveLikeViewModel.IsLike = true;

      // if the commentId is not null means that the user liked a comment and not a post
      if (commentId != null)
      {
        saveLikeViewModel.CommentId = commentId;

        await _iLikeService.AddAsync(saveLikeViewModel);
      }

      // if the commentId is null means the user gave a like to a post
      saveLikeViewModel.PostId = postId;

      await _iLikeService.AddAsync(saveLikeViewModel);

      // return the user to the Home route
      return Redirect(returnUrl);
    }

    public async Task<IActionResult> Dislike(int id, int? postId, int? commentId)
    {
      //First I delete the like from the table
      await _iLikeService.Delete(id);

      return RedirectToRoute(new { controller = "Home", action = "Index" });
    }
  }
}