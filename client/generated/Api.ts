/* eslint-disable */
/* tslint:disable */
/*
 * ---------------------------------------------------------------
 * ## THIS FILE WAS GENERATED VIA SWAGGER-TYPESCRIPT-API        ##
 * ##                                                           ##
 * ## AUTHOR: acacode                                           ##
 * ## SOURCE: https://github.com/acacode/swagger-typescript-api ##
 * ---------------------------------------------------------------
 */

import { HttpClient, RequestParams } from "./http-client";

export class Api<SecurityDataType = unknown> extends HttpClient<SecurityDataType> {
  /**
   * No description
   *
   * @tags Articles
   * @name ArticlesList
   * @request GET:/api/Articles
   */
  articlesList = (
    query?: {
      name?: string;
    },
    params: RequestParams = {},
  ) =>
    this.request<void, any>({
      path: `/api/Articles`,
      method: "GET",
      query: query,
      ...params,
    });
  /**
   * No description
   *
   * @tags Articles
   * @name ArticlesShopDetail
   * @request GET:/api/Articles/shop/{id}
   */
  articlesShopDetail = (id: number, params: RequestParams = {}) =>
    this.request<void, any>({
      path: `/api/Articles/shop/${id}`,
      method: "GET",
      ...params,
    });
}
