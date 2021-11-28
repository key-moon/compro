// detail: https://atcoder.jp/contests/arc130/submissions/27574564
#include<bits/stdc++.h>
#include<atcoder/maxflow.hpp>
using ll = long long;
#define var auto
const char newl = '\n';

using namespace std;
using namespace atcoder;

template<typename T1, typename T2> inline void chmin(T1& a, T2 b) { if (a > b) a = b; }
template<typename T1, typename T2> inline void chmax(T1& a, T2 b) { if (a < b) a = b; }

int get_digsum(long cur) {
  int digsum = 0;
  while (cur != 0) {
    digsum += cur % 10;
    cur /= 10;
  }
  return digsum;
}

pair<string, string> solve(string a, string b) {
  bool swapped = false;
  if (a.size() < b.size()) {
    swapped = true;
    swap(a, b);
  }

  vector<int> cnts_a(10, 0);
  vector<int> cnts_b(10, 0);
  for (auto& c : a) cnts_a[c - '0']++;
  for (auto& c : b) cnts_b[c - '0']++;

  int max_i = -1;
  int max_j = -1;
  int max_flow_cost = -1;
  int max_used_nine = INT_MAX;
  mf_graph<ll> optimal(1);

  for (int i = 0; i < 10; i++) {
    for (int j = 0; j < 10; j++) {
      if (i + j < 10) continue;
      if (cnts_a[i] == 0) continue;
      if (cnts_b[j] == 0) continue;
      cnts_a[i]--;
      cnts_b[j]--;

      mf_graph<ll> flow(10 * 2 + 2);
      var s = 10 * 2;
      var t = 10 * 2 + 1;

      for (int i = 0; i < 10; i++) {
        for (int j = 0; j < 10; j++) {
          if (i + j < 9) continue;
          flow.add_edge(i, 10 + j, INT_MAX);
        }
      }
      for (int i = 0; i < 10; i++) {
        flow.add_edge(s, i, cnts_a[i]);
        flow.add_edge(10 + i, t, cnts_b[i]);
      }

      var cur_max_flow_cost = flow.flow(s, t);
      var edges = flow.edges();
      int used_nine = 0;
      for (auto& edge : edges) {
        if (edge.to != 9) continue;
        used_nine += edge.flow;
      }

      if (max_flow_cost < cur_max_flow_cost || (max_flow_cost == cur_max_flow_cost && used_nine < max_used_nine)) {
        max_i = i;
        max_j = j;
        optimal = move(flow);
        max_used_nine = used_nine;
        max_flow_cost = cur_max_flow_cost;
      }

      cnts_a[i]++;
      cnts_b[j]++;
    }
  }

  if (max_flow_cost == -1) {
    if (swapped) swap(a, b);
    return make_pair(a, b);
  }

  string res_a = "";
  string res_b = "";
  var add_a = [&](int i) { char c = i + '0'; assert(cnts_a[i] != 0); cnts_a[i]--; res_a += c;  };
  var add_b = [&](int i) { char c = i + '0'; assert(cnts_b[i] != 0); cnts_b[i]--; res_b += c;  };
  add_a(max_i);
  add_b(max_j);

  var edges = optimal.edges();
  int total_match = 0;
  for (auto& edge : edges) {
    if (10 <= edge.from) continue;
    if (edge.to < 10 || 20 <= edge.to) continue;
    total_match += edge.flow;
  }
  for (auto& edge : edges) {
    if (10 <= edge.from) continue;
    if (edge.to < 10 || 20 <= edge.to) continue;
    var i = edge.from;
    var j = edge.to - 10;
    for (int k = 0; k < edge.flow; k++) {
      add_a(i);
      add_b(j);
    }
  }

  string tail_a = "";
  string tail_b = "";
  while (res_b.size() + tail_b.size() < b.size()) {
    for (int i = 1; i <= 9; i++) {
      if (cnts_a[i] != 0) {
        cnts_a[i]--;
        tail_a += (char)(i + '0');
        break;
      }
    }

    for (int i = 1; i <= 9; i++) {
      if (cnts_b[i] != 0) {
        cnts_b[i]--;
        tail_b += (char)(i + '0');
        break;
      }
    }
  }

  res_a = tail_a + res_a;
  res_b = tail_b + res_b;

  for (int i = 9; i >= 0; i--) {
    while (cnts_a[i] != 0) add_a(i);
    while (cnts_b[i] != 0) add_b(i);
  }

  reverse(res_a.begin(), res_a.end());
  reverse(res_b.begin(), res_b.end());
  if (swapped) swap(res_a, res_b);
  return make_pair(res_a, res_b);
}

pair<string, string> naive(string a, string b) {
  int min_digsum = INT_MAX;
  string max_a;
  string max_b;
  sort(a.begin(), a.end());
  do
  {
    sort(b.begin(), b.end());
    do
    {
      var la = stol(a);
      var lb = stol(b);
      var cur = la + lb;
      int digsum = get_digsum(cur);
      if (digsum < min_digsum) {
        min_digsum = digsum;
        max_a = a;
        max_b = b;
      }
    } while (next_permutation(b.begin(), b.end()));
  } while (next_permutation(a.begin(), a.end()));
  return make_pair(max_a, max_b);
}

int main() {
  /*int cnt = 0;
  while (true) {
    cnt++;
    string a = "";
    for (int i = 0; i < 3; i++) {
      a += rand() % 9 + '1';
    }
    string b = "";
    for (int i = 0; i < 5; i++) {
      b += rand() % 9 + '1';
    }
    var [na, nb] = naive(a, b);
    var [ra, rb] = solve(a, b);
    var ans = get_digsum(stol(na) + stol(nb));
    var res = get_digsum(stol(ra) + stol(rb));
    if (ans != res) {
      cout << a << endl;
      cout << b << endl;
    }
    if (cnt % 100 == 0) cout << cnt << endl;
  }*/

  string a, b;
  cin >> a >> b;
  
  var [res_a, res_b] = solve(a, b);
  cout << res_a << endl;
  cout << res_b << endl;
}
