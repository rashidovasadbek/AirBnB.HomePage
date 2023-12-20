import type ApiClientBase from "@/Infrastructures/ApiClientBase/ApiClientBase";
import config from "tailwindcss/defaultConfig";
import type {LocationFilter} from "@/modules/locations/models/LocationFilter";

export class LocationEndpointsClient {
    private client: ApiClientBase;

    constructor(client: ApiClientBase) {
        this.client = client;
    }

    public async getAsync(filter: LocationFilter){
        const queryParams = filter.toQueryParams();

        return await this.client.getAsync<Array<Location>>(`api/locations?${queryParams}`);
    }
}