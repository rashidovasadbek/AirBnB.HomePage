import {FilterPagination} from "@/Infrastructures/query/FilterPagination";

export class LocationFilter extends FilterPagination {
    public category: string;

    constructor(category: string, pageSize: number, pageToken: number) {
        super(pageSize, pageToken);

        this.category = category;
    }

    public override toQueryParams(): URLSearchParams {
        const params = super.toQueryParams()
        params.append("category", this.category);

        return params;
    }
}