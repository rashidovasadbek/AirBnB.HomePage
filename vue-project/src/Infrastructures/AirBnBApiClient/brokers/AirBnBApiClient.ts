import ApiClientBase from "@/Infrastructures/ApiClientBase/ApiClientBase";
import {LocationEndpointsClient} from "@/Infrastructures/AirBnBApiClient/brokers/LocationEndpointsClient";
import {
    LocationCategoriesEndPointsClients
} from "@/Infrastructures/AirBnBApiClient/brokers/LocationCategoriesEndPointsClients";


export class AirBnBApiClient {
    private readonly  client: ApiClientBase;
    private readonly baseUrl: string;

    constructor() {
        this.baseUrl = "https://localhost:7134";

        this.client = new ApiClientBase({
            baseURL: this.baseUrl
        });

        this.locations = new LocationEndpointsClient(this.client);
        this.locationCategories = new LocationCategoriesEndPointsClients(this.client)
    }

    public locations: LocationEndpointsClient;

    public  locationCategories: LocationCategoriesEndPointsClients;
}