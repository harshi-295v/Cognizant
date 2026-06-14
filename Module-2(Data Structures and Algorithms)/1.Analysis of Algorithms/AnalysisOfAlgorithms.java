public class AnalysisOfAlgorithms {

    // O(1)
    static void constantTime() {
        System.out.println("Constant Time O(1)");
    }

    // O(n)
    static void linearTime(int n) {
        System.out.println("\nLinear Time O(n)");
        for (int i = 1; i <= n; i++) {
            System.out.print(i + " ");
        }
        System.out.println();
    }

    // O(n²)
    static void quadraticTime(int n) {
        System.out.println("\nQuadratic Time O(n²)");
        for (int i = 1; i <= n; i++) {
            for (int j = 1; j <= n; j++) {
                System.out.print("* ");
            }
            System.out.println();
        }
    }

    // O(log n)
    static void logarithmicTime(int n) {
        System.out.println("\nLogarithmic Time O(log n)");
        for (int i = 1; i <= n; i *= 2) {
            System.out.print(i + " ");
        }
        System.out.println();
    }

    // Recursive Example
    static void recursion(int n) {
        if (n == 0)
            return;

        System.out.print(n + " ");
        recursion(n - 1);
    }

    public static void main(String[] args) {

        constantTime();

        linearTime(5);

        logarithmicTime(16);

        System.out.println("\nRecursion Example:");
        recursion(5);

        System.out.println("\n");
        quadraticTime(3);
    }
}