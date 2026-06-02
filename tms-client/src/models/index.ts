export interface Student {
  id: string;   // or number, depending on your choice
  name: string;
  gpa?: number;
}

export function isStudent(obj: any): obj is Student {
  return (
    typeof obj === "object" &&
    obj !== null &&
    typeof obj.id === "string" &&
    typeof obj.name === "string"
  );
}

function processStudent(raw: unknown) {
  if (isStudent(raw)) {
    const gpaDisplay = raw.gpa?.toFixed(2) ?? "Not yet graded";
    console.log(`Student ${raw.name} GPA: ${gpaDisplay}`);
  } else {
    console.error("Invalid student data received");
  }
}

processStudent({ id: "STU-001", name: "Hana", gpa: 3.7 });
// → Student Hana GPA: 3.70

processStudent(42);
// → Invalid student data received
