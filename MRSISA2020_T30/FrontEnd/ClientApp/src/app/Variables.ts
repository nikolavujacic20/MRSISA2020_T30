import { environment } from "../environments/environment";

export class Variables {
  static getApiEndpoint():string {
    return environment.apiUrl;
  }
}
