// detail: https://codeforces.com/contest/808/submission/106361937
#include <bits/stdc++.h>
#define var auto
using ll = long long;
const char newl = '\n';
template <typename T1, typename T2> inline void chmin(T1& a, T2 b) { if (a > b) a = b; }
template <typename T1, typename T2> inline void chmax(T1& a, T2 b) { if (a < b) a = b; }

using namespace std;

using i32 = std::int32_t;
using i64 = std::int64_t;
using u32 = std::uint32_t;
using u64 = std::uint64_t;
using isize = std::ptrdiff_t;
using usize = std::size_t;
template <class Select>
std::vector<usize> smawk(const usize row_size, const usize col_size,
    const Select& select) {
    using vec_zu = std::vector<usize>;

    const std::function<vec_zu(const vec_zu&, const vec_zu&)> solve =
        [&](const vec_zu& row, const vec_zu& col) -> vec_zu {
        const usize n = row.size();
        if (n == 0)
            return {};
        vec_zu c2;
        for (const usize i : col) {
            while (!c2.empty() && select(row[c2.size() - 1], c2.back(), i))
                c2.pop_back();
            if (c2.size() < n)
                c2.push_back(i);
        }
        vec_zu r2;
        for (usize i = 1; i < n; i += 2)
            r2.push_back(row[i]);
        const vec_zu a2 = solve(r2, c2);
        vec_zu ans(n);
        for (usize i = 0; i != a2.size(); i += 1)
            ans[i * 2 + 1] = a2[i];
        usize j = 0;
        for (usize i = 0; i < n; i += 2) {
            ans[i] = c2[j];
            const usize end = i + 1 == n ? c2.back() : ans[i + 1];
            while (c2[j] != end) {
                j += 1;
                if (select(row[i], ans[i], c2[j]))
                    ans[i] = c2[j];
            }
        }
        return ans;
    };
    vec_zu row(row_size);
    std::iota(row.begin(), row.end(), 0);
    vec_zu col(col_size);
    std::iota(col.begin(), col.end(), 0);
    return solve(row, col);
}

// https://noshi91.github.io/Library/algorithm/concave_max_plus_convolution.cpp
template <class T>
std::vector<T> concave_max_plus_convolution(const std::vector<T>& a,
    const std::vector<T>& b) {
    const usize n = a.size();
    const usize m = b.size();
    const auto get = [&](const usize i, const usize j) {
        return a[j] + b[i - j];
    };
    const auto select = [&](const usize i, const usize j, const usize k) {
        if (i < k)
            return false;
        if (i - j >= m)
            return true;
        return get(i, j) <= get(i, k);
    };
    const std::vector<usize> amax = smawk(n + m - 1, n, select);
    std::vector<T> c(n + m - 1);
    for (usize i = 0; i != n + m - 1; i += 1)
        c[i] = get(i, amax[i]);
    return c;
}

template <class I>
u64 axiotis_tzamos_knapsack(const usize t, const std::vector<I>& item) {
    std::vector<std::vector<i64>> bucket(t + 1);
    for (const I& e : item) {
        assert(e.w > 0);
        assert(e.v >= 0);

        if (e.w <= t)
            bucket[e.w].push_back(e.v);
    }

    std::vector<i64> dp(t + 1, std::numeric_limits<i64>::lowest());
    dp[0] = 0;
    for (usize w = 1; w <= t; w += 1) {
        std::vector<i64>& list = bucket[w];
        if (list.empty())
            continue;
        std::sort(list.begin(), list.end(), std::greater<i64>());
        const usize m = std::min(list.size(), t / w);
        std::vector<i64> sum(m + 1);
        sum[0] = 0;
        for (usize i = 0; i != m; i += 1)
            sum[i + 1] = sum[i] + list[i];
        for (usize k = 0; k != w; k += 1) {
            const usize n = (t - k) / w + 1;
            std::vector<i64> v(n);
            for (usize i = 0; i != n; i += 1)
                v[i] = dp[i * w + k];
            const std::vector<i64> res = concave_max_plus_convolution(v, sum);
            for (usize i = 0; i != n; i += 1)
                dp[i * w + k] = res[i];
        }
    }
    return *std::max_element(dp.begin(), dp.end());
}

int main() {
    int n, w;
    cin >> n >> w;
    struct item_t {
        ll v, w;
    };
    vector<item_t> is(n);
    for (auto& e : is) {
        std::cin >> e.w >> e.v;
    }
    cout << axiotis_tzamos_knapsack(w, is) << endl;
}
