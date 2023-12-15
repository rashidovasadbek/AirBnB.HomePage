import type {AxiosError, AxiosInstance, AxiosRequestConfig, AxiosResponse} from "axios";
import axios from "axios";
import {ApiResponse} from "@/Infrastructures/ApiClientBase/ApiResponse";
import type {ProblemDetails} from "@/Infrastructures/ApiClientBase/ProblemDetails";

export default class ApiClientBase{
    public readonly  client : AxiosInstance;

    constructor(config: AxiosRequestConfig) {
        this.client = axios.create(config);

        this.client.interceptors.response.use(<TResponse>(response: AxiosResponse) =>{
            return {
                ...response,
                data: new ApiResponse(response.data as TResponse, null, response.status)
            }
        },
        (error: AxiosError) => {
                return {
                    ...error,
                    data: new ApiResponse(null, error.response?.data as ProblemDetails, error.response?.status ?? 500)
                };
            }
        );
    }

    public async getAsync<T>(url: string, config?: AxiosRequestConfig): Promise<ApiResponse<T>> {
        return (await this.client.get<ApiResponse<T>>(url, config)).data;
    }

    public async postAsync<T>(url: string, data?:any, config?: AxiosRequestConfig): Promise<ApiResponse<T>> {
        return  (await this.client.post<ApiResponse<T>>(url, data, config)).data;
    }

    public  async putAsync<T>(url: string, data?: any, config?: AxiosRequestConfig): Promise<ApiResponse<T>> {
        return (await this.client.put<ApiResponse<T>>(url, data, config)).data;
    }

    public async deleteAsync<T>(url: string, config?: AxiosRequestConfig): Promise<ApiResponse<T>> {
        return (await this.client.delete<ApiResponse<T>>(url, config)).data;
    }
}