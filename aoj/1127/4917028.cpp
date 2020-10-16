// detail: https://onlinejudge.u-aizu.ac.jp/status/users/keymoon/submissions/1/1127/judge/4917028/C++14
#include <bits/stdc++.h>

using ll = long long;
const char newl = '\n';
#define var auto

using namespace std;

template<typename T1, typename T2> inline void chmin(T1& a, T2 b) { if (a > b) a = b; }
template<typename T1, typename T2> inline void chmax(T1& a, T2 b) { if (a < b) a = b; }

struct UnionFind {
    int num;
    vector<int> rs, ps;
    UnionFind() {}
    UnionFind(int n) :num(n), rs(n, 1), ps(n, 0) { iota(ps.begin(), ps.end(), 0); }
    int find(int x) {
        return (x == ps[x] ? x : ps[x] = find(ps[x]));
    }
    bool same(int x, int y) {
        return find(x) == find(y);
    }
    void unite(int x, int y) {
        x = find(x); y = find(y);
        if (x == y) return;
        if (rs[x] < rs[y]) swap(x, y);
        rs[x] += rs[y];
        ps[y] = x;
        num--;
    }
    int size(int x) {
        return rs[find(x)];
    }
    int count() const {
        return num;
    }
};

struct sphere {
	double r;
	double x;
	double y;
	double z;
    sphere(double r, double x, double y, double z) : r(r), x(x), y(y), z(z){}
};

double sq(double x) { return x * x; }

double dist(sphere a, sphere b) {
	var d = sqrt(sq(a.x - b.x) + sq(a.y - b.y) + sq(a.z - b.z));
	return max(0.0, d - a.r - b.r);
}

signed main() {
    int n;
    cin >> n;
    if (n == 0) return 0;
    vector<sphere> s{};
    for (int i = 0; i < n; i++) {
        double x, y, z, r;
        cin >> x >> y >> z >> r;
        s.emplace_back(r, x, y, z);
    }
    vector<pair<double, pair<int, int>>> es{};
    for (int i = 0; i < n; i++) {
        for (int j = i + 1; j < n; j++) {
            es.emplace_back(dist(s[i], s[j]), pair<int, int>(i, j));
        }
    }
    double res = 0;
    sort(es.begin(), es.end());
    UnionFind uf(n);
    for (auto& edge : es) {
        var i = edge.second.first, j = edge.second.second;
        if (uf.same(i, j)) continue;
        res += edge.first;
        uf.unite(i, j);
    }
    cout << fixed << setprecision(3);
    cout << res << endl;
    main();
}

