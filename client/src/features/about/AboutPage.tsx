import { Button, ButtonGroup, Container, Typography } from "@mui/material";
import agent from "../../app/api/agent";

export default function AboutPage() {
  return (
    <Container>
      <Typography gutterBottom variant={"h2"}>
        Errors for testing purposes
      </Typography>
      <ButtonGroup fullWidth>
        <Button
          onClick={() =>
            agent.TestErrors.get400Error().catch((error) => console.log(error))
          }
          variant={"contained"}
        >
          Test 400 error
        </Button>
        <Button
          onClick={() =>
            agent.TestErrors.get401Error().catch((error) => console.log(error))
          }
          variant={"contained"}
        >
          Test 401 error
        </Button>
        <Button
          onClick={() =>
            agent.TestErrors.get404Error().catch((error) => console.log(error))
          }
          variant={"contained"}
        >
          Test 404 error
        </Button>
        <Button
          onClick={() =>
            agent.TestErrors.get500Error().catch((error) => console.log(error))
          }
          variant={"contained"}
        >
          Test 500 error
        </Button>
        <Button
          onClick={() =>
            agent.TestErrors.getValidationError().catch((error) =>
              console.log(error)
            )
          }
          variant={"contained"}
        >
          Test validation error
        </Button>
      </ButtonGroup>
    </Container>
  );
}
