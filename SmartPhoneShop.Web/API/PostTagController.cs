﻿using AutoMapper;
using SmartPhoneShop.Model.Model;
using SmartPhoneShop.Service;
using SmartPhoneShop.Web.Infrasture.Core;
using SmartPhoneShop.Web.Infrasture.Extension;
using SmartPhoneShop.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SmartPhoneShop.Web.API
{
    [RoutePrefix("api/posttag")]
    public class PostTagController : ApiControllerBase
    {
        private IPostTagService _postTagService;

        public PostTagController(IErrorService errorService, IPostTagService postTagService) :
            base(errorService)
        {
            this._postTagService = postTagService;
        }

        [Route("getall")]
        public HttpResponseMessage Get(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () =>
            {
                var listPostTag = _postTagService.GetAll();
                var listPostTagVM = Mapper.Map<List<PostTagViewModel>>(listPostTag);
                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, listPostTagVM);

                return response;
            });
        }

        [Route("add")]
        public HttpResponseMessage Post(HttpRequestMessage request, PostTagViewModel postTagVm)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (ModelState.IsValid)
                {
                    request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    PostTag newPostTag = new PostTag();
                    newPostTag.UpdatePostTag(postTagVm);
                    var category = _postTagService.Add(newPostTag);
                    _postTagService.SaveChanges();
                    response = request.CreateResponse(HttpStatusCode.Created, category);
                }
                return response;
            });
        }

        [Route("update")]
        public HttpResponseMessage Put(HttpRequestMessage request, PostTagViewModel postTagVm)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (ModelState.IsValid)
                {
                    request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    var postTagDb = _postTagService.GetByID(postTagVm.PostID, postTagVm.TagID);
                    postTagDb.UpdatePostTag(postTagVm);
                    _postTagService.Update(postTagDb);
                    _postTagService.SaveChanges();

                    response = request.CreateResponse(HttpStatusCode.OK);
                }
                return response;
            });
        }

        public HttpResponseMessage Delete(HttpRequestMessage request, int id)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (ModelState.IsValid)
                {
                    request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    _postTagService.Delete(id);
                    _postTagService.SaveChanges();

                    response = request.CreateResponse(HttpStatusCode.OK);
                }
                return response;
            });
        }
    }
}