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

export class Shop<SecurityDataType = unknown> extends HttpClient<SecurityDataType> {
  /**
   * No description
   *
   * @tags Articles
   * @name ShopDetail
   * @request GET:/shop/{id}
   */
  shopDetail = (id: number, params: RequestParams = {}) =>
    this.request<void, any>({
      path: `/shop/${id}`,
      method: "GET",
      ...params,
    });
}
