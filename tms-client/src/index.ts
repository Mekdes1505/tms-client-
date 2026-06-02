import { Student, isStudent } from "./models/student.model";

function processStudent(raw: unknown) {
  if (isStudent(raw)) {
    const gpaDisplay = raw.gpa?.toFixed(2) ?? "Not yet graded";
    console.log(`Student ${raw.name} GPA: ${gpaDisplay}`);
  } else {
    console.error("Invalid student data received");
  }
}

// ✅ Test calls
processStudent({ id: 1, name: "Hana", gpa: 3.7 });
// → Student Hana GPA: 3.70

processStudent(42);
// → Invalid student data received
import { parseStudent } from "./models/student.model";
console.log(parseStudent({ id: "STU-001", name: "Hana" }));
// Prints a valid Student object
parseStudent({ id: 42, name: "Test" });
// Throws: TypeError: Expected id to be a string, received numbe

import { AssessmentItem, calculateGrade } from "./models/assessment.model";
const quiz: AssessmentItem = {
 id: "QUIZ-001",
kind: "quiz",
title: "SQL Basics",
correctAnswers: 8,
totalQuestions: 10,
};
const lab: AssessmentItem = {
 id: "LAB-001",
kind: "lab",
title: "REST API Project",
functionalityScore: 85,
codeQualityScore: 90,
};
console.log(`Quiz grade: ${calculateGrade(quiz)}%`); // 80
console.log(`Lab grade: ${calculateGrade(lab)}%`); // 87
// Verify readonly try this line and check the compiler error:
 quiz.id ="quiz-002";
// ERROR: Cannot assign to 'id' because it is a read-only property