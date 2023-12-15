using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Core.Application;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WebApp.Gui.Controllers
{
  public class LikesController : Controller
  {
    private readonly ILikeService _iLikeService;

    public LikesController(ILikeService iLikeService)
    {
      _iLikeService = iLikeService;
    }

    public async Task<IActionResult> Like(int? postId, int? commentId)
    {
      SaveLikeViewModel saveLikeViewModel = new SaveLikeViewModel();

      //if we send the user here it means is a like and not a dislike
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
      return RedirectToRoute(new { controller = "Home", action = "Index" });
    }

    public async Task<IActionResult> Dislike(int id)
    {
      await _iLikeService.Delete(id);

      return RedirectToRoute(new { controller = "Home", action = "Index" });
    }
  }
}