// detail: https://codeforces.com/contest/808/submission/106367708
#include <bits/stdc++.h>
#define var auto
using ll = long long;
const char newl = '\n';
template <typename T1, typename T2> inline void chmin(T1& a, T2 b) { if (a > b) a = b; }
template <typename T1, typename T2> inline void chmax(T1& a, T2 b) { if (a < b) a = b; }

using namespace std;

template<typename Flow, bool directed>
struct Dinic {
    struct Edge {
        int dst;
        Flow cap;
        int rev;
        Edge(int dst, Flow cap, int rev) :dst(dst), cap(cap), rev(rev) {}
    };

    vector< vector<Edge> > G;
    vector<int> level, iter;

    Dinic(int n) :G(n), level(n), iter(n) {}

    int add_edge(int src, int dst, Flow cap) {
        int e = G[src].size();
        int r = (src == dst ? e + 1 : G[dst].size());
        G[src].emplace_back(dst, cap, r);
        G[dst].emplace_back(src, directed ? 0 : cap, e);
        return e;
    }

    void bfs(int s) {
        fill(level.begin(), level.end(), -1);
        queue<int> que;
        level[s] = 0;
        que.emplace(s);
        while (!que.empty()) {
            int v = que.front(); que.pop();
            for (Edge& e : G[v]) {
                if (e.cap > 0 and level[e.dst] < 0) {
                    level[e.dst] = level[v] + 1;
                    que.emplace(e.dst);
                }
            }
        }
    }

    Flow dfs(int v, int t, Flow f) {
        if (v == t) return f;
        for (int& i = iter[v]; i < (int)G[v].size(); i++) {
            Edge& e = G[v][i];
            if (e.cap > 0 and level[v] < level[e.dst]) {
                Flow d = dfs(e.dst, t, min(f, e.cap));
                if (d == 0) continue;
                e.cap -= d;
                G[e.dst][e.rev].cap += d;
                return d;
            }
        }
        return 0;
    }

    Flow flow(int s, int t, Flow lim) {
        Flow fl = 0;
        while (1) {
            bfs(s);
            if (level[t] < 0 or lim == 0) break;
            fill(iter.begin(), iter.end(), 0);

            while (1) {
                Flow f = dfs(s, t, lim);
                if (f == 0) break;
                fl += f;
                lim -= f;
            }
        }
        return fl;
    }

    Flow flow(int s, int t) {
        return flow(s, t, numeric_limits<Flow>::max() / 2);
    }

    Flow cut(int s, int t, int x, int a) {
        static_assert(directed, "must be directed");
        auto& e = G[x][a];
        int y = e.dst;
        Flow cr = G[y][e.rev].cap;
        if (cr == 0) return e.cap = 0;
        e.cap = G[y][e.rev].cap = 0;
        Flow cap = cr - flow(x, y, cr);
        if (x != s and cap != 0) flow(x, s, cap);
        if (t != y and cap != 0) flow(t, y, cap);
        return cap;
    }

    Flow link(int s, int t, int x, int a, Flow f) {
        auto& e = G[x][a];
        e.cap += f;
        return flow(s, t, f);
    }
};
//END CUT HERE

struct Card {
    int Power;
    int Magic;
    int Level;
    Card(){}
    Card(int p, int c, int l): Power(p), Magic(c), Level(l){}
};

int main() {
    vector<bool> is_prime(200001, true);
    for (int i = 2; i < (int)is_prime.size(); i++){
        if (!is_prime[i]) continue;
        for (int j = i * 2; j < (int)is_prime.size(); j += i){
            is_prime[j] = false;
        }
    }

    int n, k;
    cin >> n >> k;
    vector<Card> cards{};
    for (int i = 0; i < n; i++){
        int p, c, l;
        cin >> p >> c >> l;
        cards.emplace_back(p, c, l);
    }
    vector<vector<int>> cantUse(n, vector<int>());
    for (int i = 0; i < n; i++){
        for (int j = 0; j < n; j++){
            if (i == j) continue;
            if (!is_prime[cards[i].Magic + cards[j].Magic]) continue;
            cantUse[i].emplace_back(j);
        }
    }
    int valid = 101;
    int invalid = 0;
    while (valid - invalid > 1){
        var mid = (valid + invalid) / 2;
        int maxOneInd = -1;
        int maxOnePower = -1;
        for (int i = 0; i < n; i++){
            if (cards[i].Magic != 1 || maxOnePower >= cards[i].Power) continue;
            maxOneInd = i;
            maxOnePower = cards[i].Power;
        }
        ll totalEdge = 0;
        Dinic<ll, true> dinic(1 + n + 1);
        for (int i = 0; i < n; i++) {
            if (mid < cards[i].Level) continue;
            if (cards[i].Magic == 1 && i != maxOneInd) continue;
            totalEdge += cards[i].Power;
            if (cards[i].Magic % 2 == 0) dinic.add_edge(0, 1 + i, cards[i].Power);
            else dinic.add_edge(1 + i, 1 + n, cards[i].Power);

            if (cards[i].Magic % 2 != 0) continue;
            for (var&& item : cantUse[i]){
                dinic.add_edge(1 + i, 1 + item, INT32_MAX);
            }
        }
        var res = totalEdge - dinic.flow(0, 1 + n, totalEdge);
        if (k <= res) valid = mid;
        else invalid = mid;
    }
    if (valid > 100) valid = -1;
    cout << valid << endl;
}


