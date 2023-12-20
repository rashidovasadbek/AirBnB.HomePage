import type ApiClientBase from "@/Infrastructures/ApiClientBase/ApiClientBase";
import type {LocationCategory} from "@/modules/locations/models/LocationCategory";


export class LocationCategoriesEndPointsClients {
    private client: ApiClientBase;

    constructor(client: ApiClientBase) {
        this.client = client;
    }


    public async getAsync(){
        return await this.client.getAsync<Array<LocationCategory>>("api/locationCategories",
        {
            params: {
                "PageSize": 15,
                "PageToken": 1
            }
        });
    }
}