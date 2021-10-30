// detail: https://onlinejudge.u-aizu.ac.jp/status/users/keymoon/submissions/1/2962/judge/6015572/C++17
#include<bits/stdc++.h>
using ll = long long;
#define var auto
const char newl = '\n';

using namespace std;

template<typename T1, typename T2> inline void chmin(T1& a, T2 b) { if (a > b) a = b; }
template<typename T1, typename T2> inline void chmax(T1& a, T2 b) { if (a < b) a = b; }

const ll inf = INT32_MAX;

struct Symbol {
  static Symbol Zero;
  static Symbol One;
  static Symbol Wildcard;

  ll zero_cost = INT32_MAX;
  ll one_cost = INT32_MAX;

  Symbol(ll z, ll o):zero_cost(z), one_cost(o){}

  Symbol operator |(Symbol a){
    return Symbol(
      zero_cost + a.zero_cost,
      min(one_cost, zero_cost + a.one_cost)
    );
  }
  Symbol operator &(Symbol a) {
    return Symbol(
      min(zero_cost, one_cost + a.zero_cost),
      one_cost + a.one_cost
    );
  }
};
Symbol Symbol::Zero = Symbol(0, INT32_MAX);
Symbol Symbol::One = Symbol(INT32_MAX, 0);
Symbol Symbol::Wildcard = Symbol(1, 1);

Symbol parse(string& s, int& ind) {
  if (s[ind] == '1') {
    ind++;
    return Symbol::One;
  }
  if (s[ind] == '0') {
    ind++;
    return Symbol::Zero;
  }
  if (s[ind] == '?') {
    ind++;
    return Symbol::Wildcard;
  }

  assert(s[ind] == '(');
  ind++;
  queue<Symbol> symbols;
  char prev_op = '^';
  while (true) {
    var parsed = parse(s, ind);
    if (prev_op == '&') {
      symbols.back() = symbols.back() & parsed;
    }
    else {
      symbols.emplace(parsed);
    }
    if (s[ind] == ')') break;
    prev_op = s[ind];
    ind++;
  }
  assert(s[ind] == ')');
  ind++;

  var res = symbols.front(); symbols.pop();
  while (!symbols.empty()) {
    res = res | symbols.front(); symbols.pop();
  }

  return res;
}

int main() {
  ios::sync_with_stdio(false);
  cin.tie(nullptr);

  string s;
  cin >> s;
  
  s = '(' + s + ')';
    
  int ind = 0;
  var res = parse(s, ind);

  assert(res.zero_cost < s.size());
  assert(res.one_cost < s.size());

  cout << res.zero_cost << " " << res.one_cost << endl;
}


