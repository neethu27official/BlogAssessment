using BlogAssessment.Constants;
using BlogAssessment.Context;
using BlogAssessment.Models;
using BlogAssessment.Repository;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogAssessment.Controllers
{
    public class ArticleController:Controller
    {
        #region variables
        private IGenericRepository<ArticleEntity> _genericRepository;
        List<ArticleEntity> articleList = new List<ArticleEntity>();
        #endregion

        #region Constructor
        public ArticleController()
        {
            _genericRepository = new GenericRepository<ArticleEntity>();
        }
        #endregion

        #region Actions
        #region GETActions
        /// <summary>
        /// To display all the article details
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public string DisplayArticle()
        {
            try
            {
                List<ArticleEntity> articleList = new List<ArticleEntity>(_genericRepository.GetAll().ToList());
                return JsonConvert.SerializeObject(articleList);
            }catch (Exception)
            { return BlogConstants.EXCEPTION; }
        }
        #endregion

        #region POSTActions
        /// <summary>
        /// Insert new article
        /// Assuming the authentication token passed from the Front end team
        /// auth = true - authenticated user
        /// </summary>
        /// <param name="article"></param>
        /// <returns></returns>
        [HttpPost]
        public string CreateArticle(ArticleEntity article, bool auth)
        {
            try
            {
                if (auth)
                {
                    article.LastUpdated = DateTime.Now;
                    _genericRepository.Insert(article);
                    _genericRepository.Save();
                    return BlogConstants.SUCCESS;
                }
            }catch (Exception)
            { return BlogConstants.EXCEPTION;}
            return BlogConstants.FAILURE;
        }

        /// <summary>
        /// Update Article
        /// </summary>
        /// <param name="article"></param>
        /// <returns></returns>
        [HttpPost]
        public string UpdateArticle(ArticleEntity article, bool auth)
        {
            try
            { 
                if (auth)
                {
                    article.LastUpdated = DateTime.Now;
                    _genericRepository.Update(article);
                    _genericRepository.Save();
                    return BlogConstants.SUCCESS;
                }
            }
            catch (Exception)
            { return BlogConstants.EXCEPTION; }
            return BlogConstants.FAILURE;
        }

        /// <summary>
        /// Delete Article from DB
        /// </summary>
        /// <param name="articleID"></param>
        /// <returns></returns>
        [HttpPost]
        public string DeleteArticle(Guid articleID, bool auth)
        {
            try
            {
                if (auth)
                {
                    _genericRepository.Delete(articleID);
                    _genericRepository.Save();
                    return BlogConstants.SUCCESS;
                }
            }
            catch (Exception)
            { return BlogConstants.EXCEPTION; }
            return BlogConstants.FAILURE;
        }
        #endregion
        #endregion
    }
}