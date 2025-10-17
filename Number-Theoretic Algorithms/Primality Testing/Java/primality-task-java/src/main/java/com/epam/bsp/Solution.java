package com.epam.bsp;

import java.util.ArrayList;
import java.util.LinkedHashMap;
import java.util.List;
import java.util.Map;

public class Solution {

    /**
     * Возвращает список простых p, где 2 <= p < n.
     * Реализация: сегментированное решето по нечётным числам.
     * Память O(S) на сегмент (малый), время близко к обычному решету.
     */
    public static List<Integer> getPrimes(int n) {
        List<Integer> primes = new ArrayList<>();
        if (n <= 2) return primes;

        // 2 — единственное чётное простое
        primes.add(2);

        // Базовые простые до sqrt(n) обычным решетом по нечётным
        int limit = (int) Math.sqrt(n);
        List<Integer> basePrimes = sieveBasePrimes(limit);

        // Сегментированный проход по отрезкам [low, high)
        // Делаем размер сегмента ~1 млн чисел (подходит под большинство ограничений)
        final int SEGMENT_SIZE = 1 << 20; // ~1,048,576
        int low = 3;
        if ((low & 1) == 0) low++; // стартуем с нечётного

        while (low < n) {
            int high = low + SEGMENT_SIZE;
            if (high > n) high = n;
            // работаем только с нечётными: индекс i соответствует числу num = low + 2*i
            int len = ((high - low) + 1) / 2;
            boolean[] composite = new boolean[len];

            // вычёркиваем кратные базовым простым (тоже нечётным)
            for (int p : basePrimes) {
                if (p == 2) continue; // чётных в сегменте нет
                long p2 = 1L * p * p;
                if (p2 >= high) break;

                // первое кратное в сегменте >= low
                long start = Math.max(p2, ((low + p - 1L) / p) * 1L * p);
                // сместим старт на нечётное кратное (если нужно)
                if ((start & 1L) == 0L) start += p;

                // помечаем composite[(start - low) / 2], step = p
                for (long m = start; m < high; m += 2L * p) {
                    int idx = (int) ((m - low) >> 1);
                    composite[idx] = true;
                }
            }

            // собираем простые из сегмента
            for (int i = 0; i < len; i++) {
                if (!composite[i]) {
                    int num = low + (i << 1); // low + 2*i
                    // num — нечётное и простое
                    primes.add(num);
                }
            }

            low = high;
            if ((low & 1) == 0) low++; // держим low нечётным
        }

        return primes;
    }

    // Решето для получения базовых простых до limit (включая), по нечётным
    private static List<Integer> sieveBasePrimes(int limit) {
        List<Integer> base = new ArrayList<>();
        if (limit >= 2) base.add(2);
        if (limit < 3) return base;

        int m = ((limit - 3) / 2) + 1; // количество нечётных в [3..limit]
        boolean[] composite = new boolean[m]; // false = потенциально простое
        int root = (int) Math.sqrt(limit);

        for (int i = 0; (2 * i + 3) <= root; i++) {
            if (!composite[i]) {
                int p = 2 * i + 3;        // текущий нечётный простой
                long start = 1L * p * p;  // всегда нечётное
                // индекс в массиве для start: (start - 3)/2
                int j = (int) ((start - 3) / 2);
                for (long k = j; k < m; k += p) {
                    composite[(int) k] = true;
                }
            }
        }

        for (int i = 0; i < m; i++) {
            if (!composite[i]) {
                base.add(2 * i + 3);
            }
        }
        return base;
    }

    /**
     * Факторизация n >= 2.
     * Возвращает LinkedHashMap<prime, power> в порядке возрастания множителей.
     */
    public static Map<Integer, Integer> getFactors(int n) {
        if (n < 2) throw new IllegalArgumentException("n must be >= 2");
        Map<Integer, Integer> factors = new LinkedHashMap<>();

        // отделяем фактор 2
        int c2 = 0;
        while ((n & 1) == 0) {
            n >>= 1;
            c2++;
        }
        if (c2 > 0) factors.put(2, c2);

        // нечётные делители
        for (int p = 3; (long) p * p <= n; p += 2) {
            if (n % p == 0) {
                int cnt = 0;
                while (n % p == 0) {
                    n /= p;
                    cnt++;
                }
                factors.put(p, cnt);
            }
        }

        // если остался простой множитель
        if (n > 1) {
            factors.put(n, 1);
        }

        return factors;
    }
}