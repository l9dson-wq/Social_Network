using Core.Application;
using Core.Application.ViewModels.Home;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Gui.Controllers;

public class CommentController : Controller
{
  private readonly ICommentService _iCommentService;

  public CommentController(ICommentService iCommentService)
  {
    _iCommentService = iCommentService;
  }

  [HttpPost]
  public async Task<IActionResult> AddComment(HomeViewModel homeViewModel)
  {
    homeViewModel.SaveCommentViewModel.ImagePath = "null";
    homeViewModel.SaveCommentViewModel.Reported = 0;

    var saveCommentVm = homeViewModel.SaveCommentViewModel;

    await _iCommentService.AddAsync(saveCommentVm);

    var returnUrl = Request.Headers["Referer"].ToString();

    return Redirect(returnUrl);
  }
}