// detail: https://atcoder.jp/contests/abc210/submissions/24311451
#include<bits/stdc++.h>
#include<atcoder/all>
using ll = long long;
#define var auto
const char newl = '\n';

using namespace std;

template<typename T1, typename T2> inline void chmin(T1& a, T2 b) { if (a > b) a = b; }
template<typename T1, typename T2> inline void chmax(T1& a, T2 b) { if (a < b) a = b; }

template<typename T>
vector<T> factorize(T x) {
  vector<T> res;
  for (int i = 2; i * i <= x; i++) {
    if (x % i == 0) {
      res.push_back(i);
      while (x % i == 0) x /= i;
    }
  }
  if (x != 1) res.push_back(x);
  return res;
}

int main() {
  ios::sync_with_stdio(false);
  cin.tie(nullptr);
  int n;
  cin >> n;

  map<int, int> prime_cnts{};

  vector<pair<vector<int>, vector<int>>> cards{};
  vector<pair<vector<int>, vector<int>>> prime_ind{};
  for (int i = 0; i < n; i++) {
    int a, b;
    cin >> a >> b;
    var a_fact = factorize(a);
    var b_fact = factorize(b);
    cards.emplace_back(a_fact, b_fact);

    vector<int> a_ind(a_fact.size());
    vector<int> b_ind(b_fact.size());
    for (int i = 0; i < a_fact.size(); i++) {
      a_ind[i] = prime_cnts[a_fact[i]]++;
    }
    for (int i = 0; i < b_fact.size(); i++) {
      b_ind[i] = prime_cnts[b_fact[i]]++;
    }
    prime_ind.emplace_back(a_ind, b_ind);
  }

  vector<int> cnt_table(1 << 16);
  for (int i = 0; i < 16; i++) {
    for (int j = (1 << i); j < (1 << (i + 1)); j++) {
      cnt_table[j] = i + 1;
    }
  }

  int node_num = n;
  map<int, vector<int>> prime_nodes{};
  for (var [p, cnt] : prime_cnts) {
    prime_nodes[p] = vector<int>(cnt_table[cnt]);
    for (var&& cnt : prime_nodes[p]) {
      cnt = node_num++;
    }
  }

  atcoder::two_sat sat(node_num);
  for (int i = 0; i < n; i++) {
    var [a_fact, b_fact] = cards[i];
    var [a_ind, b_ind] = prime_ind[i];

    for (int j = 0; j < a_fact.size(); j++) {
      var ind = a_ind[j];
      var& nodes = prime_nodes[a_fact[j]];
      for (int k = 0; k < nodes.size(); k++) {
        sat.add_clause(i, true, nodes[k], ind >> k & 1);
      }
    }
    for (int j = 0; j < b_fact.size(); j++) {
      var ind = b_ind[j];
      var& nodes = prime_nodes[b_fact[j]];
      for (int k = 0; k < nodes.size(); k++) {
        sat.add_clause(i, false, nodes[k], ind >> k & 1);
      }
    }
  }

  cout << (sat.satisfiable() ? "Yes" : "No") << endl;
}
