import { Temporal } from "@js-temporal/polyfill";

export interface Student {
  id: string;
  name: string;
  gpa?: number;
}

export interface EnrolledStudent extends Student {
  enrollmentDate: Date;
}


export function isStudent(obj: any): obj is Student {
  return (
    typeof obj === "object" &&
    obj !== null &&
    typeof obj.id === "number" &&
    typeof obj.name === "string"
  );
}
export function parseStudent(raw: unknown): Student {
if (typeof raw !== "object" || raw === null) {
throw new TypeError(
`Expected an object, received ${raw === null ? "null" : typeof raw}`,
);
}
const obj = raw as Record<string, unknown>;
if (typeof obj.id !== "string") {
throw new TypeError(
`Expected id to be a string, received ${typeof obj.id}`,
);
}
if (typeof obj.name !== "string") {
throw new TypeError(
`Expected name to be a string, received ${typeof obj.name}`,
);
}

return {
  id: obj.id,
  name: obj.name,
 //enrollmentDate: Temporal.Now.instant(),
};}