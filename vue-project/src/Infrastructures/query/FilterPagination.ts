import type {IQueryConvertible} from "@/Infrastructures/query/IQueryConvertible";

export class FilterPagination implements IQueryConvertible{
    pageSize: number = 4;
    pageToken: number = 1;

    constructor(pageSize: number, pageToken: number) {
        this.pageSize = pageSize;
        this.pageToken = pageToken;
    }

    public toQueryParams() : URLSearchParams {
        const params = new URLSearchParams();
        params.append("pageSize", this.pageSize.toString());
        params.append("pageToken", this.pageToken.toString())

        return params;
    }
}