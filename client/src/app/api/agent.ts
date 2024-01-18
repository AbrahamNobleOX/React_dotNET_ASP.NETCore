import axios, { AxiosError, AxiosResponse } from "axios";
import { toast } from "react-toastify";
import { router } from "../router/Routes";

// set the base url for the api
axios.defaults.baseURL = "http://localhost:3001/api/";

// get the response body
const responseBody = (response: AxiosResponse) => response.data;

// intercept the response and log the error to the console
axios.interceptors.response.use(
  (response) => {
    return response;
  },
  (error: AxiosError) => {
    // destructure the data and status from the error response
    const { data, status } = error.response as AxiosResponse;

    switch (status) {
      case 400: // there's two 400 errors in the api, one is for bad request and the other is for validation errors
        // check if there's any "errors" object in the data
        if (data.errors) {
          const modelStateErrors: string[] = []; // create an array of strings

          // loop through the errors object and push the errors to the string array
          for (const key in data.errors) {
            if (data.errors[key]) {
              modelStateErrors.push(data.errors[key]);
            }
          }

          // throw the array of strings
          throw modelStateErrors.flat();
        }
        toast.error(data.title);
        break;
      case 401:
        toast.error(data.title);
        break;
      // case 403:
      //   toast.error("You are not allowed to do that!");
      //   break;
      case 500:
        router.navigate("/server-error", { state: { error: data } }); // navigate to the server error page and pass the error data
        break;
      default:
        break;
    }

    return Promise.reject(error.response);
  }
);

// define the requests object with the get, post, put, and delete methods
const requests = {
  get: (url: string) => axios.get(url).then(responseBody), // get the url and return the response body
  post: (url: string, body: {}) => axios.post(url, body).then(responseBody), // post the url and body and return the response body
  put: (url: string, body: {}) => axios.put(url, body).then(responseBody), // put the url and body and return the response body
  delete: (url: string) => axios.delete(url).then(responseBody), // delete the url and return the response body
};

// define the Catalog object with the list and details methods
const Catalog = {
  list: () => requests.get("products"), // get the list of products
  details: (id: number) => requests.get(`products/${id}`), // get the product details
};

// define the TestErrors object with methods
const TestErrors = {
  get400Error: () => requests.get("buggy/bad-request"),
  get401Error: () => requests.get("buggy/unauthorised"),
  get404Error: () => requests.get("buggy/not-found"),
  get500Error: () => requests.get("buggy/server-error"),
  getValidationError: () => requests.get("buggy/validation-error"),
};

const agent = {
  Catalog,
  TestErrors,
};

export default agent;
