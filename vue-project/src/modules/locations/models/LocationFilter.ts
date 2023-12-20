import {FilterPagination} from "@/Infrastructures/query/FilterPagination";
import type {Guid} from "guid-typescript";

export class LocationFilter extends FilterPagination {

    public categoryId: string | null;

    constructor(categoryId: string | null, pageSize: number, pageToken: number) {
        super(pageSize, pageToken);

        this.categoryId = categoryId;
    }

    public override toQueryParams(): URLSearchParams {
        const params = super.toQueryParams()
        if(this.categoryId != null){
            params.append("categoryId", this.categoryId);
        }

        return params;
    }
}