using Core.Application;
using Core.Application.ViewModels.Comments;
using Core.Application.ViewModels.Home;
using Core.Application.ViewModels.Partial;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Gui.Controllers;

public class CommentController : Controller
{
  private readonly ICommentService _iCommentService;
  private readonly UserProfileViewModel _userProfileViewModel;
  private readonly IHttpContextAccessor _iHttpContextAccessor;

  public CommentController(ICommentService iCommentService, IHttpContextAccessor iHttpContextAccessor)
  {
    _iCommentService = iCommentService;
    _iHttpContextAccessor = iHttpContextAccessor;
    _userProfileViewModel = iHttpContextAccessor.HttpContext.Session.Get<UserProfileViewModel>("userProfile");
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

  [HttpPost]
  public async Task<IActionResult> AddReply(
    HomeViewModel? homeViewModel, 
    int commentId,
    int? principalCommentId,
    CommentPartialViewModel? commentViewModel)
  {
    // almaceno la url de la vista en la que se encontraba el usuario antes de llegar aqui.
    var returnUrl = Request.Headers["Referer"].ToString();

    // almaceno la descripcion dependiendo de cual de mis ViewModels sea nulo el valor. 
    var replyDescription = homeViewModel.ReplyDescription ?? commentViewModel.SaveComment.Description;
    var UserId = _userProfileViewModel.Id;
    var postId = commentViewModel.SaveComment.PostId;
    
    // Verifico si la respuesta es nula, si es asi regreso al usuario a la vista anterior sin enviar nada.
    if (string.IsNullOrEmpty(replyDescription))
    {
      return Redirect(returnUrl);
    }
    
    // Creo la respuesta para el comentario
    var reply = new SaveCommentViewModel
    {
      Reported = 0,
      ImagePath = "null",
      Description = replyDescription,
      ParentCommentId = commentId,
      UserId = UserId,
      PrincipalPostCommentId = principalCommentId,
      PostId = postId,
    };
    
    // Guardo la respusta
    await _iCommentService.AddAsync(reply);
    
    //redirigo al usuario a la vista anterior
    return Redirect(returnUrl);
  }
}